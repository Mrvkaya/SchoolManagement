using Microsoft.AspNetCore.Mvc;
using SMIS.BLL.Interface;
using SMIS.Entities.Enums;

namespace SMIS.UI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            var user = _userService.Login(username, password);

            if (user == null)
                return Content("Kullanıcı bulunamadı");

            HttpContext.Session.SetString("UserId", user.Id.ToString());
            HttpContext.Session.SetString("Role", user.Role.ToString());

            if (user.Role == UserRole.Admin)
                return RedirectToAction("Index", "Admin");

            if (user.Role == UserRole.Student)
                return RedirectToAction("Index", "Student");

            if (user.Role == UserRole.Teacher)
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
