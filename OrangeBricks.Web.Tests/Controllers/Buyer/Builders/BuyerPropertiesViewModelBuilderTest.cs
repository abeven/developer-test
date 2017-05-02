using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using NSubstitute;
using NUnit.Framework;
using OrangeBricks.Web.Controllers.Buyer.Builders;
using OrangeBricks.Web.Models;
using System;

namespace OrangeBricks.Web.Tests.Controllers.Buyer.Builders
{

    [TestFixture]
    public class BuyerPropertiesViewModelBuilderTest
    {
        private IOrangeBricksContext _context;

        [SetUp]
        public void SetUp()
        {
            _context = Substitute.For<IOrangeBricksContext>();
        }

        [Test]
        public void BuildShouldReturnPropertiesThatBuyerHasMadeOffersOn()
        {
            // Arrange
            var builder = new BuyerPropertiesViewModelBuilder(_context);

            var properties = new List<Models.Property>{
                new Models.Property{ StreetName = "Smith Street", Description = "", IsListedForSale = true },
                new Models.Property{ StreetName = "Jones Street", Description = "", IsListedForSale = true}
            };

            var offers = new List<Models.Offer>
            {
                new Models.Offer { Amount = 100, BuyerUserId = "1", CreatedAt = DateTime.UtcNow, Property = properties[0], Status = OfferStatus.Pending }
            };

            var mockSet = Substitute.For<IDbSet<Models.Offer>>()
                .Initialize(offers.AsQueryable());

            _context.Offers.Returns(mockSet);
            
            // Act
            var viewModel = builder.Build("1");

            // Assert
            Assert.That(viewModel.Properties.Count, Is.EqualTo(1));
        }
    }
}
