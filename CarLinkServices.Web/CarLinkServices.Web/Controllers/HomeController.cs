using CarLinkServices.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace CarLinkServices.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly CarLinkServicesDbContext _context;

        public HomeController(CarLinkServicesDbContext context)
        {
            _context = context;
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            base.OnActionExecuted(context);

            ViewBag.Cities = _context.Cities.ToArray();
        }

        public IActionResult Index()
        {
            return View("Index", _context.CarServices.Include(carService => carService.City));
        }

        public IActionResult List(int cityId)
        {
            if (!_context.Cities.Any(city => city.Id == cityId))
                return NotFound();

            return View("Index", _context.CarServices.Include(carService => carService.City).Where(carService => carService.CityId == cityId));
        }

        public IActionResult Details(int carServiceId)
        {
            CarService? carService = _context.CarServices.Include(carservice => carservice.City).FirstOrDefault(carservice => carservice.Id == carServiceId);

            if (carService == null)
                return NotFound();

            ViewBag.Title = $"Szerviz részletei: {carService.Name} ({carService.City.Name})";

            return View("Details", carService);
        }
    }
}