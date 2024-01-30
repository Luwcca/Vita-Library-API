using AutoMapper;
using WebApi_Biblioteca.Data.Dtos.FuncionarioDtos;
using WebApi_Biblioteca.Models;

namespace WebApi_Biblioteca.Profiles
{
    public class FuncionarioProfile : Profile
    {
        public FuncionarioProfile() {
            CreateMap<CreateFuncionarioDto, Funcionario>();
            CreateMap<ReadFuncionarioDto,Funcionario>().ReverseMap();
        }
    }
}
