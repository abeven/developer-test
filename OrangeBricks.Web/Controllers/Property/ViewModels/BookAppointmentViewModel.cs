using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OrangeBricks.Web.Controllers.Property.ViewModels
{
    public class BookAppointmentViewModel
    {
        public string PropertyType { get; set; }

        public string StreetName { get; set; }

        public int PropertyId { get; set; }

        [DisplayFormat(ApplyFormatInEditMode=true,DataFormatString = "{0:d}")]
        public DateTime? RequestedFor { get; set; }
    }
}