using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OrangeBricks.Web.Controllers.Property.Commands
{
    public class BookAppointmentCommand
    {
        [Required]
        public int PropertyId { get; set; }

        public string BuyerUserId { get; set; }

        [Required]
        public DateTime RequestedFor { get; set; }
    }
}