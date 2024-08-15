using Amazon_Core.Model.IdentityModel;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon_EF.IdentityData.DataSeedingFile
{
    public class ApplicationDataSeeding
    {

        public static async Task SeedData(UserManager<ApplictionUser> userManager)
        {
            if(!userManager.Users.Any())
            {
                var user = new ApplictionUser()
                {
                    Name = "Abdelrahman Gomaa",
                    Email = "abdogomaa98@gmail.com",
                    UserName = "AbdoGomaa18",
                    PhoneNumber = "+201142796388"
                  
                };
                await userManager.CreateAsync(user , "Abdo@18");
            }
           
        }
    }
}
