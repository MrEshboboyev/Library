using AutoMapper;
using Library.Services.BookAPI.Models;
using Library.Services.BookAPI.Models.Dto;

namespace Library.Services.BookAPI
{
    public static class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(option =>
            {
                option.CreateMap<Book, BookDto>().ReverseMap();
            });

            return mappingConfig;
        }
    }
}
