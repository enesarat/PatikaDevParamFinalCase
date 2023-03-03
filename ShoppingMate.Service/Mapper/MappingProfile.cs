using AutoMapper;
using ShoppingMate.Core.DTO.Concrete;
using ShoppingMate.Core.Model.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingMate.Service.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<ProductUpdateDto, Product>();
            CreateMap<ProductCreateDto, Product>();
            CreateMap<Product, ProductWithCategoryDto>();
            CreateMap<Item, ItemDto>().ReverseMap();
            CreateMap<ShoppingList, ShoppingListDto>().ReverseMap();
        }
    }
}
