using Microsoft.AspNetCore.Mvc;

namespace SchoolManagement.Controllers
{
    public class StudentController : Controller // Burada öğrencilerle ilgili işlemleri yönetecek controller'ı oluşturdum
    {
        public IActionResult Index() 
        {
            return View();
        }
    }
}
