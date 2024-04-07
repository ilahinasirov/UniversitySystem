using Core.DataAccess.EntityFramework;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.EntityFramework.Contexts;
using Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class EfUserDal : EfEntityRepositoryBase<User, ProjectUSContext>, IUserDal
    {
        public async Task AddUserWithRole(User user, string roleName)
        {
            using (var context = new ProjectUSContext())
            {
                var userManager = new UserManager<User>(new UserStore<User>(context), null, null, null, null, null, null, null, null);

                context.Users.Add(user);
                await context.SaveChangesAsync();

                await userManager.AddToRoleAsync(user, roleName);
            }
        }

        public void AssignRole(string userId, int RoleId)
        {
            using (var context = new ProjectUSContext())
            {
                var user = context.Set<User>().SingleOrDefault(x => x.Id == userId);
                // heleki qalsin
                //user.RoleId= RoleId;
                context.SaveChanges();
            }

        }



        public void SoftDelete(string id)
        {
            using (var context = new ProjectUSContext())
            {
                var entity = context.Set<User>().SingleOrDefault(x => x.Id == id);
                entity.IsDeleted = true;
                context.SaveChanges();

            }
        }


    }
}
