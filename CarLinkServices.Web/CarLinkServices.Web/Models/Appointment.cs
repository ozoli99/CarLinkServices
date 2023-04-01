namespace CarLinkServices.Web.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public int Duration { get; set; }
        public bool IsBooked { get; set; }
        public int ServiceId { get; set; }

        public Service Service { get; set; }
    }
}
