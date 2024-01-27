using AutoMapper;
using WebApi_Biblioteca.Data.Dtos.PeriodicoDtos;
using WebApi_Biblioteca.Models;

namespace WebApi_Biblioteca.Profiles
{
    public class PeriodicoProfile : Profile
    {
        public PeriodicoProfile()
        {
            CreateMap<CreatePeriodicoDto,Periodico>();
            CreateMap<ReadPeriodicoDto,Periodico>().ReverseMap();
            CreateMap<UpdatePeriodicoDto, Periodico>().ReverseMap();
        }
    }
}
