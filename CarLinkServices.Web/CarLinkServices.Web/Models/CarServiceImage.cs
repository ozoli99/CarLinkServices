namespace CarLinkServices.Web.Models
{
    public class CarServiceImage
    {
        public int Id { get; set; }
        public int CarServiceId { get; set; }
        public byte[] ImageSmall { get; set; } = null!;
        public byte[] ImageLarge { get; set; } = null!;

        public CarService CarService { get; set; }
    }
}
