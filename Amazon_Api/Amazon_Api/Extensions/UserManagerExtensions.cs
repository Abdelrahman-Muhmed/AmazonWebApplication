using Amazon_Core.Model.IdentityModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Amazon_Api.Extensions
{
    public static class UserManagerExtensions
    {
        public static async Task<ApplictionUser?> findAdressByEmailAsync(this UserManager<ApplictionUser> userManager , ClaimsPrincipal User)
        {
            var email = User.FindFirstValue(ClaimTypes.Email) ?? string.Empty;
            var user = await userManager.Users.Include(u => u.userAdress).FirstOrDefaultAsync(e => e.NormalizedEmail == email.ToUpper());
            return user;
        }
    }
}
