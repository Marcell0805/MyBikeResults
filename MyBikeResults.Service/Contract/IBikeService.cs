using MyBikeResults.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BikesResponse.Service.Contract
{
    //The interfaces that are curently availble to be used
    public interface IBikeService
    {
        Task<IEnumerable<Bike>> GetAll();
        Task<IEnumerable<Bike>> GetByCriteria(object a);
        void AddBike(Bike bikeData);
        Task DeleteBike(int bikeId);
    }
}
