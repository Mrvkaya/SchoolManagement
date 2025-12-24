using Microsoft.AspNetCore.Mvc;
using SMIS.DAL.Context;

namespace SMIS.UI.Controllers
{
    public class StudentController : Controller
    {
        private readonly SchoolManagementDbContext _context;

        public StudentController(SchoolManagementDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Grades()
        {
            var userIdString = HttpContext.Session.GetString("UserId");

            if (string.IsNullOrEmpty(userIdString))
            {
                return RedirectToAction("Login", "Account");
            }

            int studentId = int.Parse(userIdString);

            var grades = _context.Grades
                .Where(x => x.StudentId == studentId)
                .ToList();

            return View(grades);
        }

        public IActionResult Schedule()
        {
            return View();
        }

        public IActionResult Announcements()
        {
            return View();
        }
    }
}
