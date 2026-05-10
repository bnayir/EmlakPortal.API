using AutoMapper;
using EmlakPortal.API.DTOs;
using EmlakPortal.API.Models;

namespace EmlakPortal.API.Mappings
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            
            CreateMap<Property, PropertyDto>().ReverseMap();
            CreateMap<PropertyCreateDto, Property>();

            CreateMap<Property, PropertyUpdateDto>().ReverseMap();


           

             CreateMap<Category, CategoryCreateDto>().ReverseMap();

            CreateMap<City, CityDto>().ReverseMap();


        }
    }
}