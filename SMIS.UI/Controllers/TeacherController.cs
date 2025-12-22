using Microsoft.AspNetCore.Mvc;

namespace SMIS.UI.Controllers
{
    public class TeacherController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

