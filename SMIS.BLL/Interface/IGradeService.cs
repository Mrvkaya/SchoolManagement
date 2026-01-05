using SMIS.Entities.Models;

namespace SMIS.BLL.Interface
{
    public interface IGradeService
    {
        void SaveGrades(
            Dictionary<int, string> lessonNames,
            Dictionary<int, int> scores);
    }
}

