using AutoMapper;
using Library.Services_Book.Models;
using Library.Services_Book.Models.Dto;

namespace Library.Services_Book
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
