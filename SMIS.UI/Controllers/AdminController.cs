using Microsoft.AspNetCore.Mvc;
using SMIS.BLL.Interface;
using SMIS.Entities.Enums;
using SMIS.Entities.Models;
using SMIS.UI.Models;


namespace SMIS.UI.Controllers
{
    public class AdminController : Controller
    {
        private readonly IUserService _userService;
        private readonly IAnnouncementService _announcementService;
        private readonly ITeacherLessonService _teacherLessonService;
        private readonly ILessonScheduleService _lessonScheduleService;

        public AdminController(
            IUserService userService,
            IAnnouncementService announcementService,
            ITeacherLessonService teacherLessonService,
            ILessonScheduleService lessonScheduleService)
        {
            _userService = userService;
            _announcementService = announcementService;
            _teacherLessonService = teacherLessonService;
            _lessonScheduleService = lessonScheduleService;  
        }

        //  KULLANICI LİSTESİ
        public IActionResult Index()
        {
            var users = _userService.GetAll();
            return View(users);
        }

        //  ÖĞRETMEN EKLE
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

            _userService.Add(teacher);
            return RedirectToAction("Index");
        }

        // ÖĞRENCİ GÜNCELLE
        [HttpGet]
        public IActionResult EditStudent(int id)
        {
            var student = _userService.GetById(id);
            return View(student);
        }

        [HttpPost]
        public IActionResult Edit(User model)
        {
            _userService.Update(model);
            return RedirectToAction("Index");
        }

        // ÖĞRENCİ SİL
        public IActionResult Delete(int id)
        {
            _userService.Delete(id);
            return RedirectToAction("Index");
        }

        // DUYURULAR
        [HttpGet]
        public IActionResult Announcements()
        {
            var list = _announcementService.GetAll();
            return View(list);
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

        //  ÖĞRETMEN ATAMA
        [HttpGet]
        public IActionResult TeacherAssignments()
        {
            var model = new TeacherAssignmentViewModel
            {
                Teachers = _userService.GetAll()
                                       .Where(x => x.Role == UserRole.Teacher)
                                       .ToList(),

                Assignments = _teacherLessonService.GetAll()
            };

            return View(model);
        }


        [HttpPost]
        public IActionResult TeacherAssignments(int teacherId, string className, string lessonName)
        {
            _teacherLessonService.Assign(teacherId, lessonName, className);
            return RedirectToAction(nameof(TeacherAssignments));
        }

        //  DERS PROGRAMI YÖNETİMİ 
        [HttpGet]
        public IActionResult LessonSchedule()
        {
            var list = _lessonScheduleService.GetAll();
            return View(list);
        }

        [HttpPost]
        public IActionResult LessonSchedule(LessonSchedule model)
        {
            _lessonScheduleService.Add(model);
            return RedirectToAction(nameof(LessonSchedule));
        }
    }
}
