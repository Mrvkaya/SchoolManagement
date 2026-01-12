using SMIS.BLL.Interface;
using SMIS.DAL.Context;
using SMIS.Entities.Enums;
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

        public User Login(string fullName, string password)
        {
            return _context.Users
                .FirstOrDefault(x => x.FullName == fullName && x.Password == password); //BU KISIM TEKRAR DÜZELTİLECEK!!!!
        }

        public void Add(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public List<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public bool Register(string fullName, string password, UserRole role)
        {
            var user = new User
            {
                FullName = fullName,
                Password = password,
                Role = role
            };

            _context.Users.Add(user);
            _context.SaveChanges();

            return true;
        }
    }
}
