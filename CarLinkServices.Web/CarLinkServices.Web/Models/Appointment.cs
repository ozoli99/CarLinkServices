using System.ComponentModel.DataAnnotations.Schema;

namespace CarLinkServices.Web.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        [ForeignKey("Guest")]
        public int UserId { get; set; }
        public int ServiceId { get; set; }
        public DateTime StartTime { get; set; }
        public bool IsBooked { get; set; }

        public Service Service { get; set; }
    }
}
