using CarLinkServices.Web.Models;

namespace CarLinkServices.Web.Services
{
    public interface IAccountService
    {
        Guest? GetGuest(string userName);

        bool Login(LoginViewModel user);

        bool Logout();

        bool Register(RegisterViewModel guest);

        bool Create(GuestViewModel guest, out string userName);
    }
}
