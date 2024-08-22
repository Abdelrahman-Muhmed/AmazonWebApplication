using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon_Core.Model.OrderModel
{
    public class AdressModel
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
