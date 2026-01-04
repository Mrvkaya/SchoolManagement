using Microsoft.AspNetCore.Mvc;
using SMIS.DAL.Context;
using SMIS.Entities.Enums;
using SMIS.Entities.Models;
using SMIS.UI.Models;

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

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            var user = new User
            {
                FullName = model.FullName,
                Password = model.Password,
                Role = model.Role
            };

            _context.Users.Add(user);
            _context.SaveChanges();

            HttpContext.Session.SetString("UserId", user.Id.ToString());
            HttpContext.Session.SetString("Role", user.Role.ToString());

            if (user.Role == UserRole.Student)
                return RedirectToAction("Index", "Student");

            if (user.Role == UserRole.Teacher)
                return RedirectToAction("Index", "Teacher");

            return RedirectToAction("Login");
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            var user = _context.Users.Where(x => x.FullName == username && x.Password == password).OrderBy(x => x.Id)
                .LastOrDefault();

            if (user == null)
            {
                return Content("Kullanıcı bulunamadı");
            }

            HttpContext.Session.SetString("UserId", user.Id.ToString());
            HttpContext.Session.SetString("Role", user.Role.ToString());

            if (user.Role == UserRole.Admin)
                return RedirectToAction("Index", "Admin");
            else if (user.Role == UserRole.Student)
                return RedirectToAction("Index", "Student");
            else if (user.Role == UserRole.Teacher)
                return RedirectToAction("Index", "Teacher");

            return Content("Rol tanımlı değil");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Account");
        }
    }
}
