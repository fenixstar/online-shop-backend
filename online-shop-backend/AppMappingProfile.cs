using AutoMapper;
using online_shop_backend.Models.DTO;
using online_shop_backend.Models.Entities;

namespace online_shop_backend;

public class AppMappingProfile : Profile
{
    public AppMappingProfile()
    {			
        CreateMap<Category, CategoryDto>().ReverseMap();
        CreateMap<Subcategory, SubcategoryDto>().ReverseMap();
    }
}