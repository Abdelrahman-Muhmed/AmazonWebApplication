﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon_Core.Model
{
    public class Products : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string PictureUrl { get; set; } = null!;
        public decimal Price { get; set; }

        public int BrandId { get; set; } // FK ProductBrand
        public ProductBrand ProductBrand { get; set; } //Navigational Prop (One) ==> For Table ProductBrand

        public int CategoryId { get; set; } // FK ProdactCategory 
        public ProductCategory CategoryName { get; set; }  //Navigational Prop (One) ==> For Table ProdactCategory 

        //I will Handle FK By Fluint Api 

    }
}
