using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IAuthorizationService
    {
        Task<bool> IsUserInRole(ClaimsPrincipal user, string roleName);
    }
}
