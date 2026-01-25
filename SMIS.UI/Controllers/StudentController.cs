using Microsoft.AspNetCore.Mvc;
using SMIS.BLL.Interface;
using SMIS.BLL.Services;

namespace SMIS.UI.Controllers
{
    public class StudentController : Controller
    {
        private readonly IGradeService _gradeService;
        private readonly ILessonScheduleService _lessonScheduleService;
        private readonly IAnnouncementService _announcementService;
        private readonly ILessonAttendanceService _lessonAttendanceService;

        public StudentController(
            IGradeService gradeService,
            ILessonScheduleService lessonScheduleService,
            IAnnouncementService announcementService,
            ILessonAttendanceService lessonAttendanceService)
        {
            _gradeService = gradeService;
            _lessonScheduleService = lessonScheduleService;
            _announcementService = announcementService;
            _lessonAttendanceService = lessonAttendanceService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Grades()
        {
            int? studentId = HttpContext.Session.GetInt32("UserId");

            if (studentId == null)
                return RedirectToAction("Login", "Account");

            var grades = _gradeService.GetByStudentId(studentId.Value);
            var absences = _lessonAttendanceService.GetByStudentId(studentId.Value);

            var model = grades.Select(g => new StudentLessonStatusVM
            {
                LessonName = g.LessonName,
                Score = g.Score,
                AbsenceCount = absences
        .FirstOrDefault(a =>
            a.LessonName.ToLower().Trim() ==
            g.LessonName.ToLower().Trim()
        )
        ?.AbsenceCount ?? 0
            }).ToList();

            return View(model);
        }

        public IActionResult Schedule()
        {
            var list = _lessonScheduleService.GetAll();
            return View(list);
        }

        public IActionResult Announcements()
        {
            var list = _announcementService.GetAll()
                .OrderByDescending(x => x.CreatedDate)
                .ToList();

            return View(list);
        }
    }
}
