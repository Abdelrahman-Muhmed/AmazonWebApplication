using System.ComponentModel.DataAnnotations;

namespace Amazon_Api.Dtos.AccountModel
{
    public class RegisterDto
    {
        [Required]
        public string Name { get; set; } = null;

        [Required]
        public string Email { get; set; } = null;

        [Required]
        public string Password { get; set; } = null;

        [Required]
        public string phoneNumber { get; set; } = null;

    }
}
