using System.ComponentModel.DataAnnotations;

namespace Amazon_Api.Dtos.AccountModel
{
    public class AdressDto
    {
        [Required] 
        public string? firstName { get; set; }

        [Required]
        public string? lastName { get; set; }

        [Required]
        public string? street { get; set; }

        [Required]
        public string? city { get; set; }

        [Required]
        public string? country { get; set; }
    }
}
