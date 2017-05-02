using System.Data.Entity;
using NSubstitute;
using NUnit.Framework;
using OrangeBricks.Web.Tests.Controllers.Property.Commands;
using OrangeBricks.Web.Controllers.Property.Commands;
using OrangeBricks.Web.Models;

namespace OrangeBricks.Web.Tests.Controllers.Property.Commands
{
    [TestFixture]
    public class BookAppointmentCommandHandlerTest
    {
        private IOrangeBricksContext _context;
        private BookAppointmentCommandHandler _handler;

        [SetUp]
        public void SetUp()
        {
            _context = Substitute.For<IOrangeBricksContext>();
            _context.Properties.Returns(Substitute.For<IDbSet<Models.Property>>());
            _handler = new BookAppointmentCommandHandler(_context);
        }

        [Test]
        public void HandleShouldAddAppointment()
        {
            // Arrange
            var command = new BookAppointmentCommand();

            // Act
            _handler.Handle(command);

            // Assert
            _context.Appointments.Received(1).Add(Arg.Any<Models.Appointment>());
        }

        [Test]
        public void HandleShouldAddAppointmentWithCorrectBuyer()
        {
            // Arrange
            const string buyerUserId = "123";
            var command = new BookAppointmentCommand
            {
                BuyerUserId = buyerUserId
            };

            // Act
            _handler.Handle(command);

            // Assert
            _context.Appointments.Received(1).Add(Arg.Is<Models.Appointment>(x => x.BuyerUserId == buyerUserId));
        }

        [Test]
        public void HandleShouldAddAppointmentWithCorrectPropertyId()
        {
            // Arrange
            const int propertyId = 99001;
            var command = new BookAppointmentCommand
            {
                PropertyId = propertyId
            };

            // Act
            _handler.Handle(command);

            // Assert
            _context.Appointments.Received(1).Add(Arg.Is<Models.Appointment>(x => x.PropertyId == propertyId));
        }
    }
}