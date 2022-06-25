using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace storeCore.Entities
{
   public class Product : BaseEntity
   {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string PictureUrl { get; set; }


        //ProductType.cs
        public ProductType ProductType { get; set; }
        public int ProductTypeId { get; set; }

        //ProductBrand.cs
        public ProductBrand ProductBrand { get; set; }
        public int ProductBrandId { get; set; }

    }
}
