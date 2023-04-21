using CarLinkServices.Web.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CarLinkServices.Web.Services
{
    public class CarLinkServicesService : ICarLinkServicesService
    {
        private readonly CarLinkServicesDbContext _context;

        public CarLinkServicesService(CarLinkServicesDbContext context)
        {
            _context = context;
        }

        public IEnumerable<City> Cities => _context.Cities;

        public IEnumerable<CarService> CarServices => _context.CarServices.Include(carService => carService.City);

        public CarService? GetCarService(int carServiceId)
        {
            return _context.CarServices
                .Include(carService => carService.City)
                .Include(carService => carService.Services)
                .FirstOrDefault(carService => carService.Id == carServiceId);
        }
        public IEnumerable<CarService> GetCarServices(int cityId)
        {
            return _context.CarServices.Where(carService => carService.CityId == cityId);
        }
        public CarService? GetCarServiceWithServices(int carServiceId)
        {
            return _context.CarServices
                .Include(carService => carService.City)
                .Include(carService => carService.Services)
                .FirstOrDefault(carService => carService.Id == carServiceId);
        }
        public IEnumerable<int> GetCarServiceImageIds(int carServiceId)
        {
            return _context.CarServiceImages
                .Where(image => image.CarServiceId == carServiceId)
                .Select(image => image.Id);
        }
        public byte[]? GetCarServiceMainImage(int carServiceId)
        {
            return _context.CarServiceImages
                .Where(image => image.CarServiceId == carServiceId)
                .Select(image => image.ImageSmall)
                .FirstOrDefault();
        }

        public byte[]? GetCarServiceImage(int imageId, bool large)
        {
            return _context.CarServiceImages
                .Where(image => image.Id == imageId)
                .Select(image => large ? image.ImageLarge : image.ImageSmall)
                .FirstOrDefault();
        }

        public Service? GetService(int serviceId)
        {
            return _context.Services
                .Include(service => service.CarService)
                .ThenInclude(carService => carService.City)
                .FirstOrDefault(service => service.Id == serviceId);
        }

        public AppointmentViewModel? NewAppointment(int serviceId)
        {
            Service? service = _context.Services
                .Include(service => service.CarService)
                .ThenInclude(carService => carService.City)
                .FirstOrDefault(service => service.Id == serviceId);

            if (service == null)
                return null;

            AppointmentViewModel appointment = new AppointmentViewModel { Service = service };
            // TODO: Set StartTime correct
            appointment.AppointmentStartTime = DateTime.Now.AddMinutes(30);

            return appointment;
        }

        public bool SaveAppointment(int serviceId, string userName, AppointmentViewModel appointment)
        {
            if (appointment.Service == null)
                return false;

            if (!Validator.TryValidateObject(appointment, new ValidationContext(appointment, null, null), null))
                return false;

            // TODO: Validate appointment

            Guest? guest = _context.Guests.FirstOrDefault(guest => guest.UserName == userName);
            if (guest == null)
                return false;

            _context.Appointments.Add(new Appointment
            {
                ServiceId = appointment.Service.Id,
                UserId = guest.Id,
                StartTime = appointment.AppointmentStartTime
            });

            try
            {
                _context.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public AppointmentError ValidateAppointment(DateTime startTime, int serviceId)
        {
            throw new NotImplementedException();
        }
    }
}
