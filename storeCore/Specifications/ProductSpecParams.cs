﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace storeCore.Specifications
{
    public class ProductSpecParams
    {
        // Pagining Page

        private const int MaxPageSize = 50;

        public int PageIndex { get; set; } = 1;
        private int _pagesize = 6;

        public int PageSize
        {
            get => _pagesize;
            set => _pagesize = (value > MaxPageSize) ? MaxPageSize : value;
        }

        public int? BrandId { get; set; }
        public int? TypeId { get; set; }
        public string Sort { get; set; }


        //Search
        private string _search;
        public  string Search
        {
            get => _search;
            set => _search = value.ToLower();
        }
    
    
    
    
    }
}
