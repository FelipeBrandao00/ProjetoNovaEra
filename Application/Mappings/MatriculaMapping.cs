using Application.DTOs.Matricula;
using Application.Requests.Matricula;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings;

public class MatriculaMapping : Profile
{
    public MatriculaMapping()
    {
        CreateMap<Matricula, MatriculaDto>()
            .ForMember(dest => dest.NmTurma, opt => opt.MapFrom(src => src.Turma.NmTurma));

        //CreateMap<Matricula, MatriculaDto>().ReverseMap();
        CreateMap<Matricula, AddMatriculaRequest>().ReverseMap();
    }
}
