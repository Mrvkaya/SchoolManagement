using Microsoft.AspNetCore.Mvc;
using SMIS.BLL.Interface;
using SMIS.Entities.Enums;
using SMIS.Entities.Models;

namespace SMIS.UI.Controllers
{
    public class TeacherController : Controller
    {
        private readonly IGradeService _gradeService;
        private readonly IAttendanceService _attendanceService;
        private readonly IAnnouncementService _announcementService;
        private readonly IUserService _userService;

        public TeacherController(
            IGradeService gradeService,
            IAttendanceService attendanceService,
            IAnnouncementService announcementService,
            IUserService userService)
        {
            _gradeService = gradeService;
            _attendanceService = attendanceService;
            _announcementService = announcementService;
            _userService = userService;
        }

        // Öğretmen Paneli
        public IActionResult Index()
        {
            return View();
        }

        // Yoklama
        public IActionResult Attendance()
        {
            var students = _userService.GetAll()
                .Where(x => x.Role == UserRole.Student)
                .ToList();

            return View(students);
        }

        //  Not Listesi
        public IActionResult Grades()
        {
            var grades = _gradeService.GetAll();
            return View(grades);
        }

        //  Yeni Not Ekle
        [HttpPost]
        public IActionResult AddGrade(int studentId, string lessonName, int score)
        {
            var grade = new Grade
            {
                StudentId = studentId,
                LessonName = lessonName,
                Score = score
            };

            _gradeService.Add(grade);
            return RedirectToAction("Grades");
        }

        // Not Düzenle (GET)
        [HttpGet]
        public IActionResult EditGrade(int id)
        {
            var grade = _gradeService.GetById(id);
            return View(grade);
        }

        //  Not Düzenle (POST)
        [HttpPost]
        public IActionResult EditGrade(Grade model)
        {
            _gradeService.Update(model);
            return RedirectToAction("Grades");
        }

        //  Duyurular
        public IActionResult Announcements()
        {
            var announcements = _announcementService.GetAll();
            return View(announcements);
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

            _announcementService.Add(announcement);
            return RedirectToAction("Announcements");
        }
    }
}
