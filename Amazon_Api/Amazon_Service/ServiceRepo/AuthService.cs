using Amazon_Core.Model.IdentityModel;
using Amazon_Core.Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Amazon_Service.ServiceRepo
{
    public class AuthService : IAuthServic
    {
        private readonly IConfiguration _configuration;
        public AuthService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<string> CreateTokenAsync(ApplictionUser user , UserManager<ApplictionUser> userManager)
        {
            // Start Create Token By Claim 
            //1- Create New Claim 

            var authCliam = new List<Claim>
            {
                new Claim(ClaimTypes.Name , user.Name),
                new Claim(ClaimTypes.Email , user.Email)  

            };

            // 2- Create Roles For Users 
            var userRoles = await userManager.GetRolesAsync(user);

            // 3- Get Roles With By Forech For Add Roles For Claim 
            foreach (var Role in userRoles)
            {
                authCliam.Add(new Claim (ClaimTypes.Role, Role));
            }


            // 4- Create SymmtricKey 
            //var SymmetricKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("dsfsfda6666adf6daffafadddddd6fad45afd"));
            //Or We Can create it in appsetting 
            var authKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:AuthKey"] ?? string.Empty));


            // 5- Create RegisterClaim 

            var token = new JwtSecurityToken(
                
                audience : _configuration["JWT:audience"],
                issuer : _configuration["JWT:issure"],
                expires: DateTime.Now.AddDays(double.Parse( _configuration["JWT:TokenEx"]?? "0")),
                claims: authCliam,
                signingCredentials: new SigningCredentials(authKey , SecurityAlgorithms.HmacSha256Signature)
                );
       
            // 6- Return 
            return new JwtSecurityTokenHandler().WriteToken(token);

        }
    }
}
