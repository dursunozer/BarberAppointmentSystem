using Microsoft.EntityFrameworkCore;
using BarberAppointmentSystem.Models;

namespace BarberAppointmentSystem.Data
{
    public class BarberContext : DbContext
    {
        public BarberContext(DbContextOptions<BarberContext> options) : base(options) { }

        // Müşteri Tablosu
        public DbSet<Customer> Customers { get; set; }

        // Çalışan Tablosu
        public DbSet<Employee> Employees { get; set; }

        // Yönetici Tablosu
        public DbSet<Admin> Admins { get; set; }

        // Randevu Tablosu
        public DbSet<Appointment> Appointments { get; set; }

        // Hizmet Tablosu
        //public DbSet<Service> Services { get; set; }
    }
}
