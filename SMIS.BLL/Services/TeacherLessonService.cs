using SMIS.BLL.Interface;
using SMIS.DAL.Context;
using SMIS.Entities.Models;

namespace SMIS.BLL.Services
{
    public class TeacherLessonService : ITeacherLessonService
    {
        private readonly SchoolManagementDbContext _context;

        public TeacherLessonService(SchoolManagementDbContext context)
        {
            _context = context;
        }

        public void Assign(int teacherId, string lessonName, string className)
        {
            var entity = new TeacherLesson
            {
                TeacherId = teacherId,
                LessonName = lessonName,
                ClassName = className
            };

            _context.TeacherLessons.Add(entity);
            _context.SaveChanges();
        }

        public List<TeacherLesson> GetAll()
        {
            return _context.TeacherLessons.ToList();
        }
    }
}
