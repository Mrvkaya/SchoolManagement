using Microsoft.AspNetCore.Mvc;
using SMIS.DAL.Context;
using SMIS.Entities.Enums;
using SMIS.Entities.Models;

namespace SMIS.UI.Controllers
{
    public class TeacherController : Controller
    {
        private readonly SchoolManagementDbContext _context;

        public TeacherController(SchoolManagementDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Grades()
        {
            var students = _context.Users
                .Where(x => x.Role == UserRole.Student)
                .ToList();

            return View(students);
        }

        [HttpPost]
        public IActionResult SaveGrades(
            Dictionary<int, string> LessonName,
            Dictionary<int, int> Score)
        {
            foreach (var item in Score)
            {
                var grade = new Grade
                {
                    StudentId = item.Key,
                    LessonName = LessonName[item.Key],
                    Score = item.Value
                };

                _context.Grades.Add(grade);
            }

            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Attendance()
        {
            var students = _context.Users
                .Where(x => x.Role == UserRole.Student)
                .ToList();

            return View(students);
        }

        [HttpPost]
        public IActionResult Attendance(List<int> presentIds)
        {
            var students = _context.Users
                .Where(x => x.Role == UserRole.Student)
                .ToList();

            foreach (var student in students)
            {
                var attendance = new Attendance
                {
                    StudentId = student.Id,
                    Date = DateTime.Today,
                    IsPresent = presentIds != null && presentIds.Contains(student.Id)
                };

                _context.Attendances.Add(attendance);
            }

            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Announcements()
        {
            return View();
        }
    }
}
