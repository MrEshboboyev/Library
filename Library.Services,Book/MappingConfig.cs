using AutoMapper;
using Library.Services.Book.Models;
using Library.Services.Book.Models.Dto;

namespace Library.Services.Book
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
