using System.ComponentModel.DataAnnotations;

namespace BarberAppointmentSystem.Models
{
    public class Admin
    {
        [Key]
        public int AdminId { get; set; }
        public string AdminNo { get; set; }
        public string Password { get; set; }
    }
}
