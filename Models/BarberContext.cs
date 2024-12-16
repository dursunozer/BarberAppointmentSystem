using Microsoft.EntityFrameworkCore;
using BarberAppointmentSystem.Models;

namespace BarberAppointmentSystem.Data
{
    public class BarberContext : DbContext
    {
        public BarberContext(DbContextOptions<BarberContext> options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Services> Services { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Özel ilişki tanımlamaları yapılabilir
            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Customer)
                .WithMany(c => c.Appointments)
                .HasForeignKey(a => a.CustomerId);

            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Employee)
                .WithMany(e => e.Appointments)
                .HasForeignKey(a => a.EmployeeId);

            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Service)
                .WithMany(s => s.Appointments)
                .HasForeignKey(a => a.ServiceId);

            modelBuilder.Entity<Services>().HasKey(s => s.ServiceId); // Eğer bir primary key varsa
            base.OnModelCreating(modelBuilder);
        }
    }

}
