using Microsoft.AspNetCore.Mvc;
using SMIS.BLL.Interface;
using SMIS.BLL.Services;

namespace SMIS.UI.Controllers
{
    public class TeacherController : Controller
    {
        private readonly IGradeService _gradeService;
        private readonly IAttendanceService _attendanceService;

        public TeacherController(
            IGradeService gradeService,
            IAttendanceService attendanceService)
        {
            _gradeService = gradeService;
            _attendanceService = attendanceService;
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
