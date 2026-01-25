using Microsoft.AspNetCore.Mvc;
using SMIS.BLL.Interface;
using SMIS.Entities.Models;

namespace SMIS.UI.Controllers
{
    public class ParentController : Controller
    {
        private readonly IGradeService _gradeService;
        private readonly IAttendanceService _attendanceService;
        private readonly IAnnouncementService _announcementService;
        private readonly IParentStudentService _parentStudentService;
        private readonly ILessonAttendanceService _lessonAttendanceService;


        public ParentController(
            IGradeService gradeService,
            IAttendanceService attendanceService,
            IAnnouncementService announcementService,
            IParentStudentService parentStudentService,
            ILessonAttendanceService lessonAttendanceService)
        {
            _gradeService = gradeService;
            _attendanceService = attendanceService;
            _announcementService = announcementService;
            _parentStudentService = parentStudentService;
            _lessonAttendanceService = lessonAttendanceService;

        }

        public IActionResult Index()
        {
            return View();
        }

        // Çocuğun Notları
        public IActionResult Grades()
        {
            int? parentId = HttpContext.Session.GetInt32("UserId");
            if (parentId == null)
                return RedirectToAction("Login", "Account");

            var children = _parentStudentService.GetStudentsByParentId(parentId.Value);
            if (!children.Any())
                return View(new List<StudentLessonStatusVM>());

            int studentId = children.First().StudentId;

            var grades = _gradeService.GetByStudentId(studentId);
            var absences = _lessonAttendanceService.GetByStudentId(studentId);

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

        //  Duyurular
        public IActionResult Announcements()
        {
            var list = _announcementService.GetAll();
            return View(list);
        }
    }
}
