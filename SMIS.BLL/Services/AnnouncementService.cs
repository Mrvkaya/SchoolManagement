using SMIS.BLL.Interface;
using SMIS.DAL.Context;
using SMIS.Entities.Models;

namespace SMIS.BLL.Services
{
    public class AnnouncementService : IAnnouncementService
    {
        private readonly SchoolManagementDbContext _context;

        public AnnouncementService(SchoolManagementDbContext context)
        {
            _context = context;
        }

        public List<Announcement> GetAll()
        {
            return _context.Announcements.ToList();
        }
    }
}
