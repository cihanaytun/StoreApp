using AutoMapper;
using storeAPI.Dtos;
using storeCore.Entities;
using storeCore.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace storeAPI.Helpers
{
    public class MappingProfiles : Profile // profile auto mapperden geldi 
    {
        public MappingProfiles()
        {
            CreateMap<Product, ProductToReturnDto>()
                .ForMember(d => d.ProductBrand, o => o.MapFrom(s => s.ProductBrand.Name))
                .ForMember(d => d.ProductType, o => o.MapFrom(s => s.ProductType.Name))
                .ForMember(d => d.PictureUrl, o => o.MapFrom<ProductUrlResolver>());


            CreateMap<Address, AddressDto>().ReverseMap();
        }
    }
}
