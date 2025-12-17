using Microsoft.AspNetCore.Mvc;

namespace SchoolManagement.Controllers
{
    public class TeacherController : Controller // Burada öğretmenlerle ilgili işlemleri yönetecek controller'ı oluşturdum
    {
        public IActionResult Index()  // Öğretmen ana sayfasını döndüren aksiyon metodu. Yani sadece "Teacher" olanlar bu sayfaya yönlendirilecek.
        {
            return View(); 
        }
    }
}
