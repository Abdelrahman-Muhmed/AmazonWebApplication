using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon_Core.Specifications.ProductSpec
{
    public class ProductSpecParameter
    {
        public const int MaxPageSize = 10;
        private int pageSize = 5;
        public string? sorting { get; set; }
        public int? brandId { get; set; }
        public int? categoryId { get; set; }
          
     
        public int PageIndex { get; set; } = 1;

        //here I Have Handle pageSize becuse stoped take big Number 

        public int PageSize
        {
            get { return pageSize; }
            set { pageSize = value > MaxPageSize ? MaxPageSize : value; }

        }


    }
}
