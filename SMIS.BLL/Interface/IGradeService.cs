using SMIS.Entities.Models;

namespace SMIS.BLL.Interface
{
    public interface IGradeService
    {
        void SaveGrades(
            Dictionary<int, string> lessonNames,
            Dictionary<int, int> scores);

        List<Grade> GetGradesByStudentId(int studentId);
        string? GetByStudentId(int studentId);
    }
}

