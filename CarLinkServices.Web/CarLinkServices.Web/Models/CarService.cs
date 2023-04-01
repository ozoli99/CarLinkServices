namespace CarLinkServices.Web.Models
{
    public class CarService
    {
        public CarService()
        {
            Services = new HashSet<Service>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int CityId { get; set; }

        public City City { get; set; }
        public ICollection<Service> Services { get; set; }
    }
}
