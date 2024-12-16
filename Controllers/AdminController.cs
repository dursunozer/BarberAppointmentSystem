using System;
using System.Linq;
using System.Threading.Tasks;
using BarberAppointmentSystem.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace YourProjectNamespace.Controllers
{
    public class AdminController : Controller
    {
        private readonly BarberContext _context;

        public AdminController(BarberContext context)
        {
            _context = context;
        }

        // GET: Admin/CustomerList
        public async Task<IActionResult> CustomerList()
        {
            return View(await _context.Customers.ToListAsync());
        }

        // GET: Admin/EmployeeList
        public async Task<IActionResult> EmployeeList()
        {
            return View(await _context.Employees.ToListAsync());
        }

        // GET: Admin/AssignRole
        public IActionResult AssignRole()
        {
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AssignRole(int employeeId, string role)
        {
            var employee = await _context.Employees.FindAsync(employeeId);
            if (employee == null)
            {
                return NotFound();
            }

            employee.Role = role;
            _context.Update(employee);
            await _context.SaveChangesAsync();

            TempData["Message"] = $"{employee.FirstName} is now assigned the role '{role}'";
            return RedirectToAction(nameof(EmployeeList));
        }

        // Admin Dashboard
        public IActionResult Dashboard()
        {
            ViewBag.DailyEarnings = _context.Appointments
                                            .Where(a => a.AppointmentDate == DateTime.Today)
                                            .Sum(a => a.Service.Price);

            // Çalışan durumları (örnek veri)
            ViewBag.Employees = _context.Employees.Select(e => new
            {
                e.EmployeeId,
                e.FirstName,
                e.LastName,
                e.Role,
                //Status = e.IsAvailable ? "Uygun" : "Meşgul"
            }).ToList();

            //ViewData["CustomerCount"] = customerCount;
            //ViewData["EmployeeCount"] = employeeCount;
            //ViewData["AppointmentCount"] = appointmentCount;

            return View();
        }
    }
}
