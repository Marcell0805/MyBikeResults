using Microsoft.EntityFrameworkCore;
using MyBikeResults.Domain.Entities;
using System.Threading.Tasks;

namespace MyBikeResults.Persistence
{
    public interface IApplicationDbContext
    {
        //The interface for the DB set for bikes
        public DbSet<Bike> Bikes { get; set; }
        Task<int> SaveChangesAsync();
    }
}
