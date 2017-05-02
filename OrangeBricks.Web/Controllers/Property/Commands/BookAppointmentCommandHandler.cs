using OrangeBricks.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrangeBricks.Web.Controllers.Property.Commands
{
    public class BookAppointmentCommandHandler
    {
        readonly IOrangeBricksContext _context;
        public BookAppointmentCommandHandler(IOrangeBricksContext context)
        {
            _context = context;
        }

        public void Handle(BookAppointmentCommand command)
        {
            _context.Appointments.Add(new Models.Appointment
            {
                BuyerUserId = command.BuyerUserId,
                PropertyId = command.PropertyId,
                CreatedAt = DateTime.UtcNow,
                RequestedFor = command.RequestedFor
            });

            _context.SaveChanges();
        }
    }
}