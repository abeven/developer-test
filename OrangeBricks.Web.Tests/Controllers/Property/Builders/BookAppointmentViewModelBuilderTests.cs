using NSubstitute;
using NUnit.Framework;
using OrangeBricks.Web.Controllers.Property.Builders;
using OrangeBricks.Web.Controllers.Property.ViewModels;
using OrangeBricks.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeBricks.Web.Tests.Controllers.Property.Builders
{

    [TestFixture]
    public class BookAppointmentViewModelBuilderTest
    {
        private IOrangeBricksContext _context;
        private Models.Property _selectedProperty;
        private BookAppointmentViewModel _viewModel;

        [SetUp]
        public void SetUp()
        {
            _context = Substitute.For<IOrangeBricksContext>();

            // Arrange
            _selectedProperty = new Models.Property { Id = 100, StreetName = "", Description = "Great location", IsListedForSale = true };

            _context.Properties.Returns(Substitute.For<IDbSet<Models.Property>>());
            _context.Properties.Find(_selectedProperty.Id).Returns(_selectedProperty);

            var builder = new BookAppointmentViewModelBuilder(_context);
            _viewModel = builder.Build(_selectedProperty.Id);
        }
        
        [Test]
        public void BuildShouldReturnViewModelForProperty()
        {
            // Assert
            Assert.That(_viewModel.PropertyId, Is.EqualTo(_selectedProperty.Id));
            Assert.That(_viewModel.StreetName, Is.EqualTo(_selectedProperty.StreetName));
            Assert.That(_viewModel.PropertyType, Is.EqualTo(_selectedProperty.PropertyType));
        }

        [Test]
        public void BuildShouldReturnViewModelWithTomorrowAsDefaultViewingDate()
        {
            // Assert
            Assert.That(_viewModel.RequestedFor, Is.EqualTo(DateTime.UtcNow.Date.AddDays(1)));
        }
    }
}
