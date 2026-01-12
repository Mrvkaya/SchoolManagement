using Microsoft.AspNetCore.Mvc;
using SMIS.BLL.Interface;
using SMIS.BLL.Services;

namespace SMIS.UI.Controllers
{
    public class TeacherController : Controller
    {
        private readonly IGradeService _gradeService;
        private readonly IAttendanceService _attendanceService;
        private readonly IUserService _userService;

        public TeacherController(
            IGradeService gradeService,
            IAttendanceService attendanceService,
            IUserService userService)
        {
            _gradeService = gradeService;
            _attendanceService = attendanceService;
            _userService = userService;
        }

        [HttpPost]
        public IActionResult SaveGrades(
            Dictionary<int, string> LessonName,
            Dictionary<int, int> Score)
        {
            _gradeService.SaveGrades(LessonName, Score);
            return RedirectToAction("Index");
        }
    }
}
