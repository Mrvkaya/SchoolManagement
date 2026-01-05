using SMIS.Entities.Models;

namespace SMIS.BLL.Interface
{
    public interface IAttendanceService
    {
        void SaveAttendance(List<int> presentIds);
    }
}
