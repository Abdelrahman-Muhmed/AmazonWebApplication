using System.ComponentModel.DataAnnotations;

namespace Amazon_Api.Dtos
{
    public class UserDto
    {
        [Required]
        public string? Name { get; set; }

        [Required]
        public string? Email { get; set; }

        [Required]
        public string? Token { get; set; }
    }
}
