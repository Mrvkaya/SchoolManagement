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

        //  LOGIN 

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

            if (user.Role == UserRole.Parent && user.ChildStudentId.HasValue)
                HttpContext.Session.SetString("ChildStudentId", user.ChildStudentId.Value.ToString());

            if (user.Role == UserRole.Admin)
                return RedirectToAction("Index", "Admin");

            if (user.Role == UserRole.Student)
                return RedirectToAction("Index", "Student");

            if (user.Role == UserRole.Teacher)
                return RedirectToAction("Index", "Teacher");

            if (user.Role == UserRole.Parent)
                return RedirectToAction("Index", "Parent");

            return Content("Rol tanımlı değil");
        }

        // REGISTER 

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(string fullName, string password, UserRole role)
        {
            var success = _userService.Register(fullName, password, role);

            if (!success)
                return Content("Kayıt sırasında hata oluştu");

            return RedirectToAction("Login");
        }

        //  LOGOUT 

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Account");
        }
    }
}
