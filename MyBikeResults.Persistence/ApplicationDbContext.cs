using Microsoft.EntityFrameworkCore;
using MyBikeResults.Domain.Entities;
using MyBikeResults.Persistence.Seeds;
using System.Threading.Tasks;

namespace MyBikeResults.Persistence
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        // This constructor is used of runit testing
        public ApplicationDbContext()
        {

        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public DbSet<Bike> Bikes{ get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Seed();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                 .UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB; Initial Catalog=BikeResponseDb");
            }

        }

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }
    }
}
