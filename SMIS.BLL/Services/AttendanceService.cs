using SMIS.BLL.Interface;
using SMIS.DAL.Context;
using SMIS.Entities.Models;

namespace SMIS.BLL.Services
{
    public class AttendanceService : IAttendanceService
    {
        private readonly SchoolManagementDbContext _context;

        public AttendanceService(SchoolManagementDbContext context)
        {
            _context = context;
        }

        public List<Attendance> GetByStudentId(int studentId)
        {
            return _context.Attendances
                           .Where(x => x.StudentId == studentId)
                           .ToList();
        }

        public void Add(Attendance attendance)
        {
            _context.Attendances.Add(attendance);
            _context.SaveChanges();
        }
    }
}
