using AutoMapper;
using Smartschool.WebApi.Dtos;
using Smartschool.WebApi.Models;

namespace Smartschool.WebApi.Helpers
{
    public class SmartSchoolProfile : Profile
    {
        public SmartSchoolProfile()
        {
            CreateMap<Aluno, AlunoDto>()
            .ForMember(
                dest => dest.Nome,
                opt => opt.MapFrom(src => $"{src.Nome} {src.SobreNome}")
            )
            .ForMember(
                dest => dest.Idade,
                opt => opt.MapFrom(src => src.DataNascimento.GetCurrentAge())
            );

            CreateMap<AlunoDto, Aluno>();

            CreateMap<AlunoRegistrarDto, Aluno>().ReverseMap();

            CreateMap<Professor, ProfessorDto>()
            .ForMember(
                dest => dest.Nome,
                opt => opt.MapFrom(src => $"{src.Nome} {src.Sobrenome}")
            );

            CreateMap<ProfessorDto, Professor>();

            CreateMap<ProfessorRegistroDto, Professor>().ReverseMap();
        }
    }
}