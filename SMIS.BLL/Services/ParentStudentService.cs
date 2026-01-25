using SMIS.BLL.Interface;
using SMIS.DAL.Context;
using SMIS.Entities.Models;

namespace SMIS.BLL.Services
{
    public class ParentStudentService : IParentStudentService
    {
        private readonly SchoolManagementDbContext _context;

        public ParentStudentService(SchoolManagementDbContext context)
        {
            _context = context;
        }

        public List<ParentStudent> GetStudentsByParentId(int parentId)
        {
            return _context.ParentStudents
                .Where(x => x.ParentId == parentId)
                .ToList();
        }
    }
}
