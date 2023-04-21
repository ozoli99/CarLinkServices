using System.ComponentModel.DataAnnotations;

namespace CarLinkServices.Web.Models
{
    public class GuestViewModel
    {
        [Required(ErrorMessage = "A név megadása kötelező.")]
        [StringLength(60, ErrorMessage = "A foglaló neve maximum 60 karakter lehet.")]
        public string GuestName { get; set; } = null!;

        [Required(ErrorMessage = "E-mail cím megadása kötelező.")]
        [EmailAddress(ErrorMessage = "Az e-mail cím nem megfelelő formátumú.")]
        [DataType(DataType.EmailAddress)]
        public string GuestEmail { get; set; } = null!;

        [Required(ErrorMessage = "Az autó típusának megadása kötelező.")]
        public string GuestCarType { get; set; } = null!;

        [Required(ErrorMessage = "Az autó rendszámának megadása kötelező.")]
        public string GuestCarPlate { get; set; } = null!;
    }
}
