using System.ComponentModel.DataAnnotations;

namespace CarLinkServices.Web.Models
{
    public class AppointmentViewModel : GuestViewModel
    {
        public Service? Service { get; set; }

        [Required(ErrorMessage = "A kezdő időpont megadása kötelező.")]
        [DataType(DataType.Time)]
        public DateTime AppointmentStartTime { get; set; }
    }
}
