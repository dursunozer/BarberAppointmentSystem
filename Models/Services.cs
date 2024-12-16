using System.ComponentModel.DataAnnotations;

namespace BarberAppointmentSystem.Models
{
    public class Services
    {
        [Key]
        public int ServiceId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public ICollection<Appointment> Appointments { get; set; }
    }
}
