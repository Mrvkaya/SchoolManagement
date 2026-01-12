using SMIS.DAL.Context;
using SMIS.DAL.Repositories.Interfaces;
using SMIS.Entities.Models;

namespace SMIS.DAL.Repositories.Ef
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(SchoolManagementDbContext context) : base(context) { }

        public User Login(string fullName, string password)
        {
            return _context.Users.FirstOrDefault(x => x.FullName == fullName && x.Password == password);
        }
    }
}

