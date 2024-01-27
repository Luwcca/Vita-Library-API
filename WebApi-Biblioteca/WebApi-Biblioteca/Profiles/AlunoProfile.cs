using AutoMapper;
using WebApi_Biblioteca.Data.Dtos.AlunoDtos;
using WebApi_Biblioteca.Models;

namespace WebApi_Biblioteca.Profiles
{
    public class AlunoProfile : Profile
    {
        public AlunoProfile()
        {
            CreateMap<CreateAlunoDto, Aluno>();
            CreateMap<ReadAlunoDto, Aluno>().ReverseMap();
            CreateMap<UpdateAlunoDto, Aluno>().ReverseMap();
        }
    }
}
