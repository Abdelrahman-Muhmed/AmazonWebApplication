using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Amazon_Core.Model.IdentityModel
{
    public class Adress 

    {
        public int Id { get; set; }
        public string? firstName { get; set; }   
        public string? lastName { get; set; }

        public string? street { get; set; }
        public string? city { get; set; }
        public string? country { get; set; }

        //Dont forgate to make forgin key here string becuse the id inside in IdentityUser is string 
        //public int ApplicationUserId { get; set; } 

        public string? ApplicationUserId { get; set; }

        /*[JsonIgnore]*/ // For Ignor Data but there are other way it's Create AdressDto
        public ApplictionUser ApplictionUser { get; set; } = null!;

    }
}