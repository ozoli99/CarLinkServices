using CarLinkServices.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;

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
            return View("Index", _context.CarServices
                                            .Include(carService => carService.City)
                                            .Include(carService => carService.Services));
        }

        public IActionResult List(int cityId)
        {
            if (!_context.Cities.Any(city => city.Id == cityId))
                return NotFound();

            return View("Index", _context.CarServices
                                            .Include(carService => carService.City)
                                            .Include(carService => carService.Services)
                                            .Where(carService => carService.CityId == cityId));
        }

        public IActionResult Search(string search)
        {
            var carServices = _context.CarServices
                                        .Include(carService => carService.City)
                                        .Include(carService => carService.Services)
                                        .ToList();
            if (!string.IsNullOrWhiteSpace(search))
            {
                carServices = carServices.Where(carService => carService.City.Name.ToLower().Contains(search.ToLower())).ToList();
            }
            return PartialView("_CarServiceList", carServices);
        }

        [HttpGet]
        [Route("Home/CarServiceDetailsPartial/{carServiceId}")]
        public IActionResult CarServiceDetailsPartial(int carServiceId)
        {
            CarService? carService = _context.CarServices
                                                .Include(carservice => carservice.City)
                                                .Include(carservice => carservice.Services)
                                                .FirstOrDefault(carservice => carservice.Id == carServiceId);
            if (carService == null)
            {
                return NotFound();
            }
            return PartialView("_CarServiceDetailsPartial", carService);
        }

        public FileResult ImageForCarService(int? carServiceId)
        {
            if (carServiceId == null)
                return File("~/images/NoImage.png", "image/png");

            byte[]? imageContent = _context.CarServiceImages
                                            .Where(image => image.CarServiceId == carServiceId)
                                            .Select(image => image.ImageSmall)
                                            .FirstOrDefault();

            if (imageContent == null)
                return File("~/images/NoImage.png", "image/png");

            return File(imageContent, "image/png");
        }

        public FileResult Image(int? imageId, bool large = false)
        {
            if (imageId == null)
                return File("~/images/NoImage.png", "image/png");

            byte[]? imageContent = _context.CarServiceImages
                                            .Where(image => image.Id == imageId)
                                            .Select(image => large ? image.ImageLarge : image.ImageSmall)
                                            .FirstOrDefault();

            if (imageContent == null)
                return File("~/images/NoImage.png", "image/png");

            return File(imageContent, "image/png");
        }
    }
}