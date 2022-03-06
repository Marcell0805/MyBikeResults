using Microsoft.EntityFrameworkCore;
using MyBikeResults.Domain.Entities;
using MyBikeResults.Persistence;
using NUnit.Framework;

namespace MyBikeResults.Test.Unit.Persistence
{
    public class ApplicationDbContextTest
    {
        [Test]
        public void CanInsertCustomerIntoDatabasee()
        {

            using var context = new ApplicationDbContext();
            var bike = new Bike();
            context.Bikes.Add(bike);
            Assert.AreEqual(EntityState.Added, context.Entry(bike).State);
        }
    }
}
