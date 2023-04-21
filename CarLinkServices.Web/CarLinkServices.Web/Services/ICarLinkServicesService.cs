using CarLinkServices.Web.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;

namespace CarLinkServices.Web.Services
{
    public interface ICarLinkServicesService
    {
        IEnumerable<City> Cities { get; }
        
        IEnumerable<CarService> CarServices { get; }

        CarService? GetCarService(int carServiceId);

        IEnumerable<CarService> GetCarServices(int cityId);

        CarService? GetCarServiceWithServices(int carServiceId);

        IEnumerable<int> GetCarServiceImageIds(int carServiceId);

        byte[]? GetCarServiceMainImage(int carServiceId);

        byte[]? GetCarServiceImage(int imageId, bool large);

        Service? GetService(int serviceId);

        AppointmentViewModel? NewAppointment(int serviceId);

        bool SaveAppointment(int serviceId, string userName, AppointmentViewModel appointment);

        AppointmentError ValidateAppointment(DateTime startTime, int serviceId);
    }
}
