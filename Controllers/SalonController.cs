using BarberAppointmentSystem.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BarberAppointmentSystem.Controllers
{
    public class SalonController : Controller
    {
        static List<Customer> customers = new List<Customer>() {
        new Customer(){Id=1, Email = "Dursun", FirstName = "Dursun", LastName = "Özer",TelNo="000",Password="123" },
        new Customer(){Id=2, Email = "Kudret", FirstName = "kudret", LastName = "Özer",TelNo="000",Password="123" },
        new Customer(){Id=3, Email = "Samed", FirstName = "samed", LastName = "Özer",TelNo="000",Password="123" }
        };
        static List<Employee> employees = new List<Employee>() {
        new Employee(){Id=1, Email = "Dursun", FirstName = "Dursun", LastName = "Özer",TelNo="000",Password="123" },
        new Employee(){Id=2, Email = "Kudret", FirstName = "kudret", LastName = "Özer",TelNo="000",Password="123" },
        new Employee(){Id=3, Email = "Samed", FirstName = "samed", LastName = "Özer",TelNo="000",Password="123" }
        };
        Admin adm = new Admin()
        {
            AdminNo = "admin",
            Password = "admin"
        };
        public IActionResult CustomerLogin(Customer customer)
        {
            foreach (var cust in customers)
            {
                if (cust.Email == customer.Email && cust.Password == customer.Password)
                {
                    HttpContext.Session.SetString("SessionUser", cust.FirstName);
                    var cookie = new CookieOptions()
                    {
                        Expires = DateTime.Now.AddMinutes(1)
                    };
                    //HttpContext.Response.Cookies.Append("CookieColor", u.UserColor, cookie);
                    return RedirectToAction("CustomerDashboard");
                }
            }
            TempData["Hata"] = "Kullanıcı adı veya parola hatalı!";
            return RedirectToAction("Index");
        }
        public IActionResult EmployeeLogin(Employee employee)
        {    
            foreach (var emp in employees)
            {
                if (emp.Email == employee.Email && emp.Password == employee.Password)
                {
                    HttpContext.Session.SetString("SessionUser", emp.FirstName);
                    var cookie = new CookieOptions()
                    {
                        Expires = DateTime.Now.AddMinutes(1)
                    };
                    //HttpContext.Response.Cookies.Append("CookieColor", u.UserColor, cookie);
                    return RedirectToAction("EmployeeDashboard");
                }
            }
            TempData["Hata"] = "Kullanıcı adı veya parola hatalı!";
            return RedirectToAction("Index");
        }
        public IActionResult AdminLogin(Admin admin)
        {
            if (adm.AdminNo == admin.AdminNo && adm.Password == admin.Password)
            {
                HttpContext.Session.SetString("SessionUser", "Admin");
                var cookie = new CookieOptions()
                {
                    Expires = DateTime.Now.AddMinutes(1)
                };
                //HttpContext.Response.Cookies.Append("CookieColor", u.UserColor, cookie);
                return RedirectToAction("AdminDashboard");
            }
            TempData["Hata"] = "Kullanıcı adı veya parola hatalı!";
            return RedirectToAction("Index");
        }
        public IActionResult Logout()
        {
            TempData["Hata"] = "Oturum Başarılı Bir Şekilde Sonlandırıldı!";
            HttpContext.Session.Clear();
            //HttpContext.Response.Cookies.Delete("CookieColor");
            return RedirectToAction("Index");
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
