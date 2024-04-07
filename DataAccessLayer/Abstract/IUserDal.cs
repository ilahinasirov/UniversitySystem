using Core.DataAccess;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IUserDal:IEntityRepository<User>
    {
        void SoftDelete(string id);
        void AssignRole(string userId,int RoleId);
        Task AddUserWithRole(User user, string roleName);
    }
}
