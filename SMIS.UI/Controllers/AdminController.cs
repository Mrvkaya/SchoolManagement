using Microsoft.AspNetCore.Mvc;
using SMIS.DAL.Context;

namespace SMIS.UI.Controllers
{
    public class AdminController : Controller
    {
        private readonly SchoolManagementDbContext _context;

        public AdminController(SchoolManagementDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var users = _context.Users.ToList();
            return View(users);
        }

        //[HttpPost]
        //public IActionResult SaveRoles(Dictionary<int, string> Username, Dictionary<int, int> Role)
        //{

        //}
    }
}