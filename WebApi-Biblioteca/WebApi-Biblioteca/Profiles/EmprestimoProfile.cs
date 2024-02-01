using AutoMapper;
using WebApi_Biblioteca.Data.Dtos.EmprestimoDtos;
using WebApi_Biblioteca.Models;

namespace WebApi_Biblioteca.Profiles;

public class EmprestimoProfile : Profile
{
    public EmprestimoProfile()
    {
        CreateMap<PostEmprestimoDto, Emprestimo>();
        CreateMap<PostItemEmprestimoDto, ItemEmprestimo>();


        CreateMap<ItemEmprestimo, GetItemEmprestimosDto>().ReverseMap() ;
           

        CreateMap<Emprestimo,GetEmprestimosDto>().ReverseMap()
            .ForMember(
                x => x.EmprestimoId,
                opt => opt.MapFrom(src => src.EmprestimoId))
            .ForMember(
                x => x.AlunoId,
                opt => opt.MapFrom(src => src.AlunoId))
            .ForMember(
                x => x.FuncionarioId,
                opt => opt.MapFrom(src => src.FuncionarioId)
            );

    }
}
