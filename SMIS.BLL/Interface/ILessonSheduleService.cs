using SMIS.Entities.Models;

namespace SMIS.BLL.Interface
{
    public interface ILessonScheduleService
    {
        List<LessonSchedule> GetAll();
        void Add(LessonSchedule model);
    }
}
