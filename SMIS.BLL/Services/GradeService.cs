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

        public List<Grade> GetGradesByStudentId(int studentId)
        {
            return _context.Grades
                .Where(x => x.StudentId == studentId)
                .ToList();
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

        string? IGradeService.GetByStudentId(int studentId)
        {
            throw new NotImplementedException();
        }
    }
}
