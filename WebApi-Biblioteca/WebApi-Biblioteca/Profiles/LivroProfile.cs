using AutoMapper;
using WebApi_Biblioteca.Data.Dtos.LivrosDtos;
using WebApi_Biblioteca.Models;

namespace WebApi_Biblioteca.Profiles;

public class LivroProfile : Profile
{
    public LivroProfile()
    {
        CreateMap<CreateLivroDto, Livro>();
        CreateMap<ReadLivroDto, Livro>().ReverseMap();
    }
}
