using SMIS.Entities.Models;

namespace SMIS.BLL.Interface
{
    public interface IAttendanceService
    {
        List<Attendance> GetByStudentId(int studentId);
        void Add(Attendance attendance);
    }
}
