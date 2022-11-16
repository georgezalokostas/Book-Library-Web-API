using BookLibrary_API.Models;
using AutoMapper;

namespace BookLibrary_API.Profiles;

public class Mapper  : Profile
{
	public Mapper()
	{
        CreateMap<Book, BookDTO>();
        CreateMap<BookDTO, Book>();
    }
}
