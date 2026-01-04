using Microsoft.AspNetCore.Mvc;
using SMIS.DAL.Context;
using SMIS.Entities.Enums;
using SMIS.Entities.Models;

namespace SMIS.UI.Controllers
{
    public class AdminController : Controller
    {
        private readonly SchoolManagementDbContext _context;

        public AdminController(SchoolManagementDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult AddTeacher()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddTeacher(string fullName, string password)
        {
            var teacher = new User
            {
                FullName = fullName,
                Password = password,
                Role = UserRole.Teacher
            };

            _context.Users.Add(teacher);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        public IActionResult Index()
        {
            var users = _context.Users.ToList();
            return View(users);
        }
        public IActionResult LessonSchedule()
        {
            if (HttpContext.Session.GetString("Role") != "Admin")
                return RedirectToAction("Login", "Account");

            var list = _context.LessonSchedules.ToList();
            return View(list);
        }
        public IActionResult Announcements()
        {
            var list = _context.Announcements
                .OrderByDescending(x => x.CreatedDate)
                .ToList();

            return View(list);
        }
        public IActionResult Schedule()
        {
            var list = _context.LessonSchedules.ToList();
            return View(list);
        }

        [HttpPost]
        public IActionResult Schedule(string day, string lesson, string time)
        {
            var schedule = new LessonSchedule
            {
                Day = day,
                LessonName = lesson,
                Hour = time
            };

            _context.LessonSchedules.Add(schedule);
            _context.SaveChanges();

            return RedirectToAction("Schedule");
        }

        [HttpPost]
        public IActionResult Announcements(string title, string content)
        {
            var announcement = new Announcement
            {
                Title = title,
                Content = content,
                CreatedDate = DateTime.Now
            };

            _context.Announcements.Add(announcement);
            _context.SaveChanges();

            return RedirectToAction("Announcements");
        }

        [HttpPost]
        public IActionResult LessonSchedule(LessonSchedule model)
        {
            if (HttpContext.Session.GetString("Role") != "Admin")
                return RedirectToAction("Login", "Account");

            _context.LessonSchedules.Add(model);
            _context.SaveChanges();

            return RedirectToAction("LessonSchedule");
        }
    }
}
