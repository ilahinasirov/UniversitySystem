using BusinessLayer.Abstract;
using BusinessLayer.Constants;
using DataAccessLayer.Abstract;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class UserService : IUserService
    {
        private readonly IUserDal _userDal;
        public UserService(IUserDal userDal)
        {
            _userDal = userDal;   
        }
        public string Add(User user)
        {
            _userDal.Add(user);
            return Messages.UserAdded;
        }

        public async Task<string> AddUserWithRole(User user, string roleName)
        {
            await _userDal.AddUserWithRole(user, roleName);
            return  Messages.UserAddedWithRole;
        }

        public string AssignRole(string userId, int roleId)
        {
            _userDal.AssignRole(userId, roleId);
            return Messages.RoleAssigned;
        }

        public string Delete(User user)
        {
            _userDal.Delete(user);
            return Messages.UserDeleted;
        }

        public List<User> GetList()
        {
            return _userDal.GetList().ToList();
        }

        public User GetUserById(string id)
        {
           return _userDal.Get(x=>x.Id == id);
        }

        public List<User> GetUsersByRole(int roleId)
        {
            //return _userDal.GetList(x=>x.RoleId == roleId).ToList();
            return null;
        }

        public string SoftDelete(string id)
        {
            _userDal.SoftDelete(id);
            return Messages.UserDeleted;
        }

        public string Update(User user)
        {
            _userDal.Update(user);
            return Messages.UserUpdated;
        }
    }
}
