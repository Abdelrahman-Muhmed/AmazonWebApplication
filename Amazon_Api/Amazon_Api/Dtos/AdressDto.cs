using System.ComponentModel.DataAnnotations;

namespace Amazon_Api.Dtos
{
    public class AdressDto
    {
        [Required]
        public string firstName { get; set; } = null!;

        [Required]
        public string lastName { get; set; } = null!;

        [Required]
        public string street { get; set; } = null!;

        [Required]
        public string city { get; set; } = null!;

        [Required]
        public string country { get; set; } = null!;
    }
}
