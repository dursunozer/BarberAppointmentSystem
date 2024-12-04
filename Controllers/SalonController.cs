using BarberAppointmentSystem.Extensions;
using BarberAppointmentSystem.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BarberAppointmentSystem.Controllers
{
    public class SalonController : Controller
    {
        static List<Customer> customers = new List<Customer>() {
            new Customer(){Id=1, Email = "Dursun", FirstName = "Dursun", LastName = "Özer",TelNo="000",Password="123" },
            new Customer(){Id=2, Email = "Kudret", FirstName = "Kudret", LastName = "Özer",TelNo="000",Password="123" },
            new Customer(){Id=3, Email = "Samed", FirstName = "Samed", LastName = "Özer",TelNo="000",Password="123" }
        };

        static List<Employee> employees = new List<Employee>() {
            new Employee(){Id=1, Email = "ali", FirstName = "ali", LastName = "Özer",TelNo="000",Password="123" },
            new Employee(){Id=2, Email = "Veli", FirstName = "Kudret", LastName = "Özer",TelNo="000",Password="123" },
            new Employee(){Id=3, Email = "Deli", FirstName = "Samed", LastName = "Özer",TelNo="000",Password="123" }
        };

        Admin admin = new Admin()
        {
            AdminNo = "admin",
            Password = "admin"
        };

        public IActionResult AdminLogin()
        {
            var sessionAdmin = HttpContext.Session.Get<Admin>("AdminSession");
            if (sessionAdmin != null)
            {
                return View("AdminSession");
            }

            TempData["Hata"] = "Oturum bilgisi bulunamadı!";
            return RedirectToAction("Login");
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            // Admin kontrolü
            if (email == admin.AdminNo && password == admin.Password)
            {
                HttpContext.Session.Set("AdminSession", admin);
                return RedirectToAction("AdminLogin");
            }

            // Customer kontrolü
            var matchingCustomer = customers.FirstOrDefault(c => c.Email == email && c.Password == password);
            if (matchingCustomer != null)
            {
                HttpContext.Session.SetString("SessionRole", "Customer");
                HttpContext.Session.SetString("SessionUser", matchingCustomer.FirstName);
                return RedirectToAction("CustomerSession");
            }

            // Employee kontrolü
            var matchingEmployee = employees.FirstOrDefault(e => e.Email == email && e.Password == password);
            if (matchingEmployee != null)
            {
                HttpContext.Session.SetString("SessionRole", "Employee");
                HttpContext.Session.SetString("SessionUser", matchingEmployee.FirstName);
                return RedirectToAction("EmployeeSession");
            }

            TempData["Hata"] = "Kullanıcı bilgileri hatalı. Lütfen kontrol ediniz.";
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
            TempData["Hata"] = "Oturum Başarılı Bir Şekilde Sonlandırıldı!";
            return RedirectToAction("Login");
        }

        public IActionResult Details()
        {
            return View();
        }

        // GET: SalonController
        public ActionResult Index()
        {
            return View();
        }

        // GET: SalonController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SalonController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SalonController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SalonController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SalonController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SalonController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SalonController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
