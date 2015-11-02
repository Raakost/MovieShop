using System;
using NUnit.Framework;
using MoviesShopProxy.DomainModel;
using Movieshop.Models;

namespace ShopTest
{
    [TestFixture]
    public class UnitTest1
    {
        [Test]
        public void orderline_properties_set_test()
        {
            OrderLineViewModel line = new OrderLineViewModel();
            var movie = new Movie() { Id = 1, Title = "The Ring", Price = 200 };
            line.Movie = movie;
            line.Amount = 10;

            Assert.AreEqual(line.Movie, movie, "Movies are the same");
            Assert.AreEqual(line.Amount, 10, "Movie amount is wrong");

        }
    }
}
