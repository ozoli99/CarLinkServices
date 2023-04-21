using CarLinkServices.Web.Models;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;

namespace CarLinkServices.Web.Services
{
    public class AccountService : IAccountService
    {
        private readonly CarLinkServicesDbContext _context;

        public AccountService(CarLinkServicesDbContext context)
        {
            _context = context;
        }

        public Guest? GetGuest(string userName)
        {
            return _context.Guests.FirstOrDefault(guest => guest.UserName == userName);
        }

        public bool Login(LoginViewModel user)
        {
            if (!Validator.TryValidateObject(user, new ValidationContext(user, null, null), null))
                return false;

            Guest? guest = _context.Guests.FirstOrDefault(guest => guest.UserName == user.UserName);
            if (guest == null)
                return false;

            byte[] passwordBytes;
            using (var alg = SHA512.Create())
            {
                passwordBytes = alg.ComputeHash(Encoding.UTF8.GetBytes(user.UserPassword));
            }

            if (!passwordBytes.SequenceEqual(guest.UserPassword))
                return false;

            return true;
        }

        public bool Logout()
        {
            return true;
        }

        public bool Register(RegisterViewModel newGuest)
        {
            if (!Validator.TryValidateObject(newGuest, new ValidationContext(newGuest, null, null), null))
                return false;

            if (_context.Guests.Count(guest => guest.UserName == newGuest.UserName) != 0)
                return false;

            byte[] passwordBytes;
            using (var alg = SHA512.Create())
            {
                passwordBytes = alg.ComputeHash(Encoding.UTF8.GetBytes(newGuest.UserPassword));
            }

            _context.Guests.Add(new Guest
            {
                Name = newGuest.GuestName,
                Email = newGuest.GuestEmail,
                UserName = newGuest.UserName,
                UserPassword = passwordBytes,
                CarType = newGuest.GuestCarType,
                CarPlate = newGuest.GuestCarPlate
            });

            try
            {
                _context.SaveChanges();
            }
            catch
            {
                return false;
            }

            return true;
        }

        public bool Create(GuestViewModel guest, out string userName)
        {
            userName = "user" + Guid.NewGuid();

            if (!Validator.TryValidateObject(guest, new ValidationContext(guest, null, null), null))
                return false;

            _context.Guests.Add(new Guest
            {
                Name = guest.GuestName,
                Email = guest.GuestEmail,
                UserName = userName,
                CarType = guest.GuestCarType,
                CarPlate = guest.GuestCarPlate
            });

            try
            {
                _context.SaveChanges();
            }
            catch
            {
                return false;
            }

            return true;
        }
    }
}
