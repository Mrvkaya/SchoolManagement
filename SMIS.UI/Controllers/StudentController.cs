using Microsoft.AspNetCore.Mvc;

namespace SMIS.UI.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

