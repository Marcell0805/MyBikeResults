using BikesResponse.Service.Contract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBikeResults.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBikeResults.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BikeResultsController : ControllerBase
    {
        private readonly IBikeService _bikeService;
        public BikeResultsController(IBikeService bikeService)
        {
            this._bikeService = bikeService;
        }
        [HttpGet("GetAllData", Name = "getData")]
        public async Task<IEnumerable<Bike>> GetAll()
        {
            var result = await _bikeService.GetAll();
            result=result.OrderBy(x => x.Make).ThenBy(x => x.Model);
            return result;
        }
    }
}
