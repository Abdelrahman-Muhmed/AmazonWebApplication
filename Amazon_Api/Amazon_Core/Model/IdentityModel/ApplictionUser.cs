using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon_Core.Model.IdentityModel
{
    public class ApplictionUser : IdentityUser
    {
        public string? Name { get; set; }
        public Adress? userAdress { get; set; }
    }
}
