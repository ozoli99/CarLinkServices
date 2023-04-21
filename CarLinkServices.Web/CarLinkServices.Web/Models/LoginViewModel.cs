using System;
using System.ComponentModel.DataAnnotations;

namespace CarLinkServices.Web.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "A felhasználónév megadása kötelező.")]
        public string UserName { get; set; } = null!;

        [Required(ErrorMessage = "A jelszó megadása kötelező.")]
        [DataType(DataType.Password)]
        public string UserPassword { get; set; } = null!;
    }
}
