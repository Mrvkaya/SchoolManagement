using Microsoft.EntityFrameworkCore;
using SMIS.BLL.Interface;
using SMIS.DAL.Context;
using SMIS.Entities.Models;

namespace SMIS.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly SchoolManagementDbContext _context;

        public UserService(SchoolManagementDbContext context)
        {
            _context = context;
        }

        public User? Login(string fullName, string password)
        {
            return _context.Users
                .FirstOrDefault(x => x.FullName == fullName && x.Password == password);
        }

        public List<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        public void AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }
    }
}
