using AutoMapper;
using WebApi_Biblioteca.Data.Dtos.EditoraDtos;
using WebApi_Biblioteca.Models;

namespace WebApi_Biblioteca.Profiles;

public class EditoraProfile : Profile
{
    public EditoraProfile()
    {
        CreateMap<CreateEditoraDto, Editora>();
        CreateMap<ReadEditoraDto, Editora>().ReverseMap();
        CreateMap<UpdateEditoraDto, Editora>().ReverseMap();
    }
}
