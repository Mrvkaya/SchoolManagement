using SMIS.BLL.Interface;
using SMIS.DAL.Context;
using SMIS.Entities.Enums;
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

        public void SaveAttendance(List<int> presentIds)
        {
            var students = _context.Users
                .Where(x => x.Role == UserRole.Student)
                .ToList();

            foreach (var student in students)
            {
                var attendance = new Attendance
                {
                    StudentId = student.Id,
                    Date = DateTime.Today,
                    IsPresent = presentIds != null && presentIds.Contains(student.Id)
                };

                _context.Attendances.Add(attendance);
            }

            _context.SaveChanges();
        }
    }
}
