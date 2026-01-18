using SMIS.BLL.Interface;
using SMIS.DAL.Context;
using SMIS.Entities.Models;

namespace SMIS.BLL.Services
{
    public class GradeService : IGradeService
    {
        private readonly SchoolManagementDbContext _context;

        public GradeService(SchoolManagementDbContext context)
        {
            _context = context;
        }

        public List<Grade> GetByStudentId(int studentId)
        {
            return _context.Grades
                .Where(x => x.StudentId == studentId)
                .ToList();
        }
        public Grade GetById(int id)
        {
            return _context.Grades.FirstOrDefault(x => x.Id == id);
        }
        public List<Grade> GetAll()
        {
            return _context.Grades.ToList();
        }

        public void Update(Grade grade)
        {
            var entity = _context.Grades.FirstOrDefault(x => x.Id == grade.Id);
            if (entity == null) return;

            entity.LessonName = grade.LessonName;
            entity.Score = grade.Score;

            _context.SaveChanges();
        }

        public void SaveGrades(
            Dictionary<int, string> lessonNames,
            Dictionary<int, int> scores)
        {
            foreach (var item in scores)
            {
                var grade = new Grade
                {
                    StudentId = item.Key,
                    LessonName = lessonNames[item.Key],
                    Score = item.Value
                };

                _context.Grades.Add(grade);
            }

            _context.SaveChanges();
        }
        public void Add(Grade grade)
        {
            _context.Grades.Add(grade);
            _context.SaveChanges();
        }
    }
}
