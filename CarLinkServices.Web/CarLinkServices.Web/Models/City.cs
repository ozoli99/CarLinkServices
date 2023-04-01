namespace CarLinkServices.Web.Models
{
    public class City
    {
        public City()
        {
            CarServices = new HashSet<CarService>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<CarService> CarServices { get; set; }
    }
}
