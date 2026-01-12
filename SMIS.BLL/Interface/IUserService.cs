using SMIS.Entities.Enums;
using SMIS.Entities.Models;

namespace SMIS.BLL.Interface
{
    public interface IUserService
    {
        User Login(string fullName, string password);
        void Add(User user);
        List<User> GetAll();
        bool Register(string fullName, string password, UserRole role);
    }
}


