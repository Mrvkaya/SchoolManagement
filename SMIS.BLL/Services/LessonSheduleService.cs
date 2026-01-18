using SMIS.BLL.Interface;
using SMIS.DAL.Context;
using SMIS.Entities.Models;

namespace SMIS.BLL.Services
{
    public class LessonScheduleService : ILessonScheduleService
    {
        private readonly SchoolManagementDbContext _context;

        public LessonScheduleService(SchoolManagementDbContext context)
        {
            _context = context;
        }

        public List<LessonSchedule> GetAll()
        {
            return _context.LessonSchedules.ToList();
        }

        public void Add(LessonSchedule model)
        {
            _context.LessonSchedules.Add(model);
            _context.SaveChanges();
        }
    }
}
