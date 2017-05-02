using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrangeBricks.Web.Models
{
    public class Appointment
    {
        [Key]
        public int Id { get; set; }
        
        public Property Property { get; set; }

        [ForeignKey("Property")]
        [Required]
        public int? PropertyId { get; set; }

        [Required]
        public string BuyerUserId { get; set; }

        public DateTime RequestedFor { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}