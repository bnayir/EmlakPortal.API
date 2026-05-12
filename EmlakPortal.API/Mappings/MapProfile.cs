using AutoMapper;
using EmlakPortal.API.DTOs;
using EmlakPortal.API.Models;

namespace EmlakPortal.API.Mappings
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {

            CreateMap<Property, PropertyDto>()
                .ForMember(dest => dest.CityName, opt => opt.MapFrom(src => src.City.CityName))
                .ForMember(dest => dest.DistrictName, opt => opt.MapFrom(src => src.District.DistrictName))
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.CategoryName)); CreateMap<PropertyCreateDto, Property>();

            CreateMap<Property, PropertyUpdateDto>().ReverseMap();


           

             CreateMap<Category, CategoryCreateDto>().ReverseMap();

            CreateMap<City, CityDto>().ReverseMap();


        }
    }
}