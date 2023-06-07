using AutoMapper;
using ProductProject.Models.Dto;
using ProductProject.Models.Entities;

namespace ProductProject.Models.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateProductDto, Product>();
            CreateMap<UpdateProductDto, Product>();
            CreateMap<Product,GetProductDto > ()
                .ForMember(dest => dest.PriceWithTax,opt => opt.MapFrom(src => src.Tax + src.Price))
                .ReverseMap();//reverse funtion
        }
        
    }
}
