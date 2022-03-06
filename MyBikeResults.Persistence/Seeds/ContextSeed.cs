using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyBikeResults.Domain.Entities;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace MyBikeResults.Persistence.Seeds
{
    public static class ContextSeed
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            ReadJsonData(modelBuilder);
        }

        private static void ReadJsonData(ModelBuilder modelBuilder)
        {
            /*List<IdentityRole> roles = DefaultRoles.IdentityRoleList();
            modelBuilder.Entity<IdentityRole>().HasData(roles);*/
            List<Bike> tests = new();
            string bikeJson = File.ReadAllText(@"Seeds" + Path.DirectorySeparatorChar + "bikes_response.json");
            tests = JsonConvert.DeserializeObject<List<Bike>>(bikeJson);
        }

       
    }
}
