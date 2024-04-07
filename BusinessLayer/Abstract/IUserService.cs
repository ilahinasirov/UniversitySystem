using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IUserService
    {
        List<User> GetList();
        User GetUserById(string id);
        List<User> GetUsersByRole(int roleId);
        string Add(User user);
        string Update(User user);
        string Delete(User user);
        string SoftDelete(string id);

        string AssignRole(string userId, int roleId);
        Task<string> AddUserWithRole(User user, string roleName);
    }
}
