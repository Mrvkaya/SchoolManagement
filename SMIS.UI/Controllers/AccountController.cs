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

            if (user == null)
            {
                return Content("Kullanıcı bulunamadı");
            }

            return user.Role switch
            {
                UserRole.Admin => RedirectToAction("Index", "Admin"),
                UserRole.Teacher => RedirectToAction("Index", "Teacher"),
                UserRole.Student => RedirectToAction("Index", "Student"),
                _ => Content("Geçersiz rol")
            };
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Account");
        }

    }
}