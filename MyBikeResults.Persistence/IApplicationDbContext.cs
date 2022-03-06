using Microsoft.EntityFrameworkCore;
using MyBikeResults.Domain.Entities;
using System.Threading.Tasks;

namespace MyBikeResults.Persistence
{
    public interface IApplicationDbContext
    {
        public DbSet<Bike> Bikes { get; set; }

        Task<int> SaveChangesAsync();
    }
}
