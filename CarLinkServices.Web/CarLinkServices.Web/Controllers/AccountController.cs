using CarLinkServices.Web.Models;
using CarLinkServices.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CarLinkServices.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly ICarLinkServicesService _carLinkServicesService;

        public AccountController(IAccountService accountService, ICarLinkServicesService carLinkServicesService)
        {
            _accountService = accountService;
            _carLinkServicesService = carLinkServicesService;
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            base.OnActionExecuted(context);

            ViewBag.Cities = _carLinkServicesService.Cities.ToArray();
        }

        public IActionResult Index()
        {
            return RedirectToAction("Login");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View("Login");
        }

        public IActionResult Login(LoginViewModel user)
        {
            if (!ModelState.IsValid)
                return View("Login", user);

            if (!_accountService.Login(user))
            {
                ModelState.AddModelError("", "Hibás felhasználónév, vagy jelszó.");
                return View("Login", user);
            }

            HttpContext.Session.SetString("user", user.UserName);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View("Register");
        }

        public IActionResult Register(RegisterViewModel guest)
        {
            if (!ModelState.IsValid)
                return View("Register", guest);

            if(!_accountService.Register(guest))
            {
                ModelState.AddModelError("UserName", "A megadott felhasználónév már létezik.");
                return View("Register", guest);
            }

            ViewBag.Information = "A regisztráció sikeres volt. Kérjük, jelentkezzen be.";

            if (HttpContext.Session.GetString("user") != null)
                HttpContext.Session.Remove("user");

            return RedirectToAction("Login");
        }

        public IActionResult Logout()
        {
            if (HttpContext.Session.GetString("user") != null)
                HttpContext.Session.Remove("user");

            return RedirectToAction("Index", "Home");
        }
    }
}
