using Microsoft.AspNetCore.Mvc;

namespace SchoolManagement.Controllers
{
    public class AdminController : Controller // Burada yöneticilerle ilgili işlemleri yönetecek controller'ı oluşturdum
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
