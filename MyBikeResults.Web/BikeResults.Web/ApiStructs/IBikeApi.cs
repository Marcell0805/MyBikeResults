using MyBikeResults.Domain.Entities;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeResults.Web.ApiStructs
{
    public interface IBikeApi
    {
        [Get("/BikeResults/GetAllData")]
        Task<IEnumerable<Bike>> GetAll();
    }
}
