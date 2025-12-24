using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SMIS.DAL.Context;
using SMIS.Entities.Enums;

namespace SMIS.UI.Controllers
{
    public class AccountController : Controller
    {
        private readonly SchoolManagementDbContext _context;

        public AccountController(SchoolManagementDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            var user = _context.Users
                .FirstOrDefault(x => x.Username == username && x.Password == password);
            HttpContext.Session.SetString("UserId", user.Id.ToString());
            HttpContext.Session.SetString("Role", user.Role.ToString());

            if (user == null)
            {
                return Content("Kullanıcı bulunamadı");
            }

            if (user.Role == UserRole.Admin)
            {
                return RedirectToAction("Index", "Admin");
            }
            else if (user.Role == UserRole.Student)
            {
                return RedirectToAction("Index", "Student");
            }
            else if (user.Role == UserRole.Teacher)
            {
                return RedirectToAction("Index", "Teacher");
            }

            return Content("Rol tanımlı değil");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Account");
        }

    }
}