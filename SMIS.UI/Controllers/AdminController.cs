using Microsoft.AspNetCore.Mvc;

namespace SMIS.UI.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
