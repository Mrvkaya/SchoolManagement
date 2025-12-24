using Microsoft.AspNetCore.Mvc;

namespace SMIS.UI.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Schedule()
        {
            return View();
        }

        public IActionResult Grades()
        {
            return View();
        }

        public IActionResult Announcements()
        {
            return View();
        }
    }
}


