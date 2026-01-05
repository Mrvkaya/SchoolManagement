using System;
using System.Collections.Generic;
using System.Text;
using SMIS.Entities.Models;

namespace SMIS.BLL.Interface
{
    public interface IUserService
    {
        User? Login(string fullName, string password);

        List<User> GetAllUsers();

        void AddUser(User user);
    }
}
