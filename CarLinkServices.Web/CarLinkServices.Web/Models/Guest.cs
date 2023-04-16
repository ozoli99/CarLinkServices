namespace CarLinkServices.Web.Models
{
    public class Guest
    {
        public Guest()
        {
            Appointments = new HashSet<Appointment>();
        }

        public int Id { get; set; }
        public string UserName { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string Email { get; set; } = null!;
        public byte[] UserPassword { get; set; } = null!;

        public ICollection<Appointment> Appointments { get; set; }
    }
}
