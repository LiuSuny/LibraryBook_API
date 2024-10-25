using AutoMapper;
using LibraryBook_TaskAPI.DTO;
using LibraryBook_TaskAPI.Models;

namespace LibraryBook_TaskAPI.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Book, BookDTO>().ReverseMap();
            CreateMap<Author, AuthorDTO>().ReverseMap();
        }
    }
}
