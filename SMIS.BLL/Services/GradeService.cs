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
    }
}
