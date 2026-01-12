using SMIS.Entities.Models;

namespace SMIS.DAL.Repositories.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        User Login(string fullName, string password);
    }
}

