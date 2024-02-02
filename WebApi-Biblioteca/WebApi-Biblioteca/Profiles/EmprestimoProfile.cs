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
        CreateMap<ItemEmprestimo, GetItemEmprestimosDto>();
        CreateMap<Emprestimo, GetEmprestimosDto>();
            
    }
}
