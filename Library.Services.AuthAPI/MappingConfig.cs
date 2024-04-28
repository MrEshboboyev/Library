using AutoMapper;
using Library.Services.AuthAPI.Models;
using Library.Services.AuthAPI.Models.Dto;

namespace Library.Services.AuthAPI
{
    public static class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(option =>
            {
                option.CreateMap<ApplicationUser, UserDto>().ReverseMap();
            });

            return mappingConfig;
        }
    }
}
