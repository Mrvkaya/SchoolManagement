using Microsoft.AspNetCore.Mvc;

namespace SchoolManagement.Controllers
{
    public class AccountController : Controller // Burada kullanıcıların giriş işlemlerini yönetecek controller'ı oluşturdum
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
    }
}
