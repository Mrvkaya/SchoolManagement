using Microsoft.AspNetCore.Mvc;
using SMIS.BLL.Interface;

namespace SMIS.UI.Controllers
{
    public class ParentController : Controller
    {
        private readonly IGradeService _gradeService;
        private readonly IAttendanceService _attendanceService;
        private readonly IAnnouncementService _announcementService;

        public ParentController(
            IGradeService gradeService,
            IAttendanceService attendanceService,
            IAnnouncementService announcementService)
        {
            _gradeService = gradeService;
            _attendanceService = attendanceService;
            _announcementService = announcementService;
        }

        public IActionResult Index()
        {
            return View();
        }

        // Çocuğun notları
        public IActionResult Grades()
        {
            var childIdString = HttpContext.Session.GetString("ChildStudentId");

            if (string.IsNullOrEmpty(childIdString))
                return RedirectToAction("Login", "Account");

            int studentId = int.Parse(childIdString);

            var grades = _gradeService.GetByStudentId(studentId);
            return View(grades);
        }

        // Devamsızlık
        public IActionResult Attendance()
        {
            var childIdString = HttpContext.Session.GetString("ChildStudentId");

            if (string.IsNullOrEmpty(childIdString))
                return RedirectToAction("Login", "Account");

            int studentId = int.Parse(childIdString);

            var list = _attendanceService.GetByStudentId(studentId);
            return View(list);
        }

        // Duyurular
        public IActionResult Announcements()
        {
            var childIdString = HttpContext.Session.GetString("ChildStudentId");

            if (string.IsNullOrEmpty(childIdString))
                return RedirectToAction("Login", "Account");

            int studentId = int.Parse(childIdString);

            var list = _attendanceService.GetByStudentId(studentId);
            return View(list);
        }
    }
}
