using System.ComponentModel.DataAnnotations;

namespace BarberAppointmentSystem.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string TelNo { get; set; }
        public string Password { get; set; }

        public ICollection<Appointment> Appointments { get; set; }

    }
}
