using SMIS.Entities.Models;

namespace SMIS.BLL.Interface
{
    public interface IAnnouncementService
    {
        List<Announcement> GetAll();
    }
}

