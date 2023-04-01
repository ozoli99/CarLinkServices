namespace CarLinkServices.Web.Models
{
    public enum ServiceType
    {
        TireChange = 0,
        ClimateCharge = 1,
        DefectRepair = 2,
        SuspensionAdjustment = 4
    }

    public class Service
    {
        public Service()
        {
            Appointments = new HashSet<Appointment>();
        }

        public int Id { get; set; }
        public ServiceType Type { get; set; }
        public string Description { get; set; }
        public int CarServiceId { get; set; }

        public CarService CarService { get; set; }
        public ICollection<Appointment> Appointments { get; set; }
    }
}
