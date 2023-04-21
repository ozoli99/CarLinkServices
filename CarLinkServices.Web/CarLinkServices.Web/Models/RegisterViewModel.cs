using System;
using System.ComponentModel.DataAnnotations;

namespace CarLinkServices.Web.Models
{
    public class RegisterViewModel : GuestViewModel
    {
        [Required(ErrorMessage = "A felhasználónév megadása kötelező.")]
        [RegularExpression("^[A-Za-z0-9_-]{5,40}$", ErrorMessage = "A felhasználónév formátuma, vagy hossza nem megfelelő.")]
        public string UserName { get; set; } = null!;

        [Required(ErrorMessage = "A jelszó megadása kötelező.")]
        [RegularExpression("^[A-Za-z0-9_-]{5,40}$", ErrorMessage = "A jelszó formátuma, vagy hossza nem megfelelő.")]
        [DataType(DataType.Password)]
        public string UserPassword { get; set; } = null!;

        [Required(ErrorMessage = "A jelszó ismételt megadása kötelező.")]
        [Compare(nameof(UserPassword), ErrorMessage = "A két jelszó nem egyezik.")]
        [DataType(DataType.Password)]
        public string UserConfirmPassword { get; set; } = null!;

        [Required(ErrorMessage = "Az autó típusának megadása kötelező.")]
        [RegularExpression("^[A-Za-z0-9_-]{5,40}$", ErrorMessage = "A autó típusának formátuma, vagy hossza nem megfelelő.")]
        public string UserCarType { get; set; } = null!;

        [Required(ErrorMessage = "Az autó rendszámának megadása kötelező.")]
        [RegularExpression("^[a-zA-Z]{3}-\\d{3}$", ErrorMessage = "A autó rendszámának formátuma, vagy hossza nem megfelelő.")]
        public string UserCarPlate { get; set; } = null!;
    }
}
