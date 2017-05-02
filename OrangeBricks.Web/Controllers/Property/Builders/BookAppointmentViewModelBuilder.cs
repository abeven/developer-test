using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OrangeBricks.Web.Models;
using OrangeBricks.Web.Controllers.Property.ViewModels;

namespace OrangeBricks.Web.Controllers.Property.Builders
{
    public class BookAppointmentViewModelBuilder
    {
        private readonly IOrangeBricksContext _context;

        public BookAppointmentViewModelBuilder(IOrangeBricksContext context)
        {
            _context = context;
        }

        public BookAppointmentViewModel Build(int id)
        {
            var property = _context.Properties.Find(id);

            return new BookAppointmentViewModel
            {
                PropertyId = property.Id,
                PropertyType = property.PropertyType,
                StreetName = property.StreetName,
                RequestedFor = DateTime.UtcNow.Date.AddDays(1)
            };
        }
    }
}