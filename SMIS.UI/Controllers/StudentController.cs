using Microsoft.AspNetCore.Mvc;
using SMIS.BLL.Interface;

namespace SMIS.UI.Controllers
{
    public class StudentController : Controller
    {
        private readonly IGradeService _gradeService;
        private readonly ILessonScheduleService _lessonScheduleService;
        private readonly IAnnouncementService _announcementService;

        public StudentController(
            IGradeService gradeService,
            ILessonScheduleService lessonScheduleService,
            IAnnouncementService announcementService)
        {
            _gradeService = gradeService;
            _lessonScheduleService = lessonScheduleService;
            _announcementService = announcementService;
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

            var grades = _gradeService.GetByStudentId(studentId);
            return View(grades);
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
