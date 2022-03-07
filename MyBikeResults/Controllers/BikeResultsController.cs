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
    /// <summary>
    /// API controller for bikes
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class BikeResultsController : ControllerBase
    {
        private readonly IBikeService _bikeService;
        public BikeResultsController(IBikeService bikeService)
        {
            this._bikeService = bikeService;
        }
        /// <summary>
        /// Retrieves all bike details from JSON file
        /// </summary>
        /// <remarks>Awesomeness!</remarks>
        /// <param name="id" example="123">The product id</param>
        /// <response code="200">Bike retrieved</response>
        /// <response code="404">Bike not found</response>
        /// <response code="500">Oops! Can't lookup your bike right now</response>
        [ProducesResponseType(typeof(Bike), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        [HttpGet("GetAllData", Name = "getData")]
        public async Task<IEnumerable<Bike>> GetAll()
        {
            var result = await _bikeService.GetAll();
            result=result.OrderBy(x => x.Make).ThenBy(x => x.Model);
            return result;
        }
    }
}
