using BikesResponse.Service.Contract;
using Microsoft.EntityFrameworkCore;
using MyBikeResults.Domain.Entities;
using MyBikeResults.Persistence;
using MyBikeResults.Service.Contract;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace MyBikeResults.Service.Implementation
{
    public class BikeService : IBikeService
    {
        private readonly IGenericRepo<Bike> _repository;
        private readonly DbSet<Bike> _entity;
        public BikeService(IGenericRepo<Bike> repository, ApplicationDbContext context)
        {
            _repository = repository;
            _entity = context.Set<Bike>();
        }

        public void AddBike(Bike bikeValues)
        {
            if (_entity != null)
            {
                _repository.Insert(bikeValues);
                _repository.SaveChanges();
            }
        }

        public Task DeleteBike(int bikeId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Bike>> GetAll()
        {
            List<Bike> tests = new();
            string bikeJson = File.ReadAllText(@"Seeds" + Path.DirectorySeparatorChar + "bikes_response.json");
            tests = JsonConvert.DeserializeObject<List<Bike>>(bikeJson);
            return tests;
            //return await _repository.GetAll();
        }

        public Task<IEnumerable<Bike>> GetByCriteria(object a)
        {
            throw new NotImplementedException();
        }
    }
}
