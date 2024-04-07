using BusinessLayer.Abstract;
using Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AuthorizationManager : IAuthorizationService
    {
        private readonly UserManager<User> _userManager;

        public async Task<bool> IsUserInRole(ClaimsPrincipal user, string roleName)
        {
            var loggeInUser = await _userManager.GetUserAsync(user);
            if(loggeInUser != null)
            {
                return await _userManager.IsInRoleAsync(loggeInUser, roleName);
            }
            
            return false;
        }


       
    }
}
