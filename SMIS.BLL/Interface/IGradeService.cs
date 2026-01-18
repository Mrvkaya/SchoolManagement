using SMIS.Entities.Models;
using System.Collections.Generic;

namespace SMIS.BLL.Interface
{
    public interface IGradeService
    {
        List<Grade> GetAll();

        List<Grade> GetByStudentId(int studentId);

        Grade GetById(int id);
        void Add(Grade grade);

        void Update(Grade grade);

        void SaveGrades(
            Dictionary<int, string> lessonName,
            Dictionary<int, int> score
        );
    }
}
