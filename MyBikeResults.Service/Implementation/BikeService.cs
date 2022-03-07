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


//This is the implementation of the bike interface
//These methods will cater for most CRUD functions
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
        //This method is responsible for reading the JSON file and returning the results
        public async Task<IEnumerable<Bike>> GetAll()
        {
            try
            {
                List<Bike> tests = new();
                string bikeJson = await File.ReadAllTextAsync(@"Seeds" + Path.DirectorySeparatorChar + "bikes_response.json");
                tests = JsonConvert.DeserializeObject<List<Bike>>(bikeJson);
                return tests;
            }
            catch (IOException e)
            {
                throw e;
            }
            catch(Exception e)
            {
                throw;
            }
        }

        public Task<IEnumerable<Bike>> GetByCriteria(object a)
        {
            throw new NotImplementedException();
        }
    }
}
