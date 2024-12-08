using BarberAppointmentSystem.Data;
using BarberAppointmentSystem.Extensions;
using BarberAppointmentSystem.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BarberAppointmentSystem.Controllers
{
    public class SalonController : Controller
    {
        private readonly BarberContext _context;

        public SalonController(BarberContext context)
        {
            _context = context;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            // Admin kontrolü
            var admin = _context.Admins.FirstOrDefault(a => a.AdminNo == email && a.Password == password);
            if (admin != null)
            {
                HttpContext.Session.Set("AdminSession", admin);
                return RedirectToAction("AdminSession");
            }

            // Customer kontrolü
            var matchingCustomer = _context.Customers.FirstOrDefault(c => c.Email == email && c.Password == password);
            if (matchingCustomer != null)
            {
                HttpContext.Session.SetString("SessionRole", "Customer");
                HttpContext.Session.SetString("SessionUser", matchingCustomer.FirstName);
                return RedirectToAction("CustomerSession");
            }

            // Employee kontrolü
            var matchingEmployee = _context.Employees.FirstOrDefault(e => e.Email == email && e.Password == password);
            if (matchingEmployee != null)
            {
                HttpContext.Session.SetString("SessionRole", "Employee");
                HttpContext.Session.SetString("SessionUser", matchingEmployee.FirstName);
                return RedirectToAction("EmployeeSession");
            }

            TempData["Hata"] = "Kullanıcı bilgileri hatalı. Lütfen kontrol ediniz.";
            return RedirectToAction("Login");
        }

        public IActionResult AdminSession()
        {
            var sessionAdmin = HttpContext.Session.Get<Admin>("AdminSession");
            if (sessionAdmin != null)
            {
                return View();
            }

            TempData["Hata"] = "Oturum bilgisi bulunamadı!";
            return RedirectToAction("Login");
        }

        public IActionResult CustomerSession()
        {
            var sessionUser = HttpContext.Session.GetString("SessionUser");
            if (!string.IsNullOrEmpty(sessionUser))
            {
                return View();
            }

            TempData["Hata"] = "Oturum bulunamadı!";
            return RedirectToAction("Login");
        }

        public IActionResult EmployeeSession()
        {
            var sessionUser = HttpContext.Session.GetString("SessionUser");
            if (!string.IsNullOrEmpty(sessionUser))
            {
                return View();
            }

            TempData["Hata"] = "Oturum bulunamadı!";
            return RedirectToAction("Login");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            TempData["Mesaj"] = "Oturum Başarılı Bir Şekilde Sonlandırıldı!";
            return RedirectToAction("Login");
        }
    }
}
