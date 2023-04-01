using Microsoft.EntityFrameworkCore;

namespace CarLinkServices.Web.Models
{
    public class CarLinkServicesDbContext : DbContext
    {
        public CarLinkServicesDbContext(DbContextOptions<CarLinkServicesDbContext> options) : base(options) {}

        public DbSet<CarService> CarServices { get; set; } = null!;
        public DbSet<Service> Services { get; set; } = null!;
        public DbSet<Appointment> Appointments { get; set; } = null!;
        public DbSet<City> Cities { get; set; } = null!;
    }
}
