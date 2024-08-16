using Amazon_Core.Model.IdentityModel;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon_Core.Service
{
    public interface IAuthServic
    {
        Task<string> CreateTokenAsync(ApplictionUser user , UserManager<ApplictionUser> userManager);
    }
}
