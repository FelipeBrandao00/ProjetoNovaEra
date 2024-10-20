using Application.DTOs.TurmaAluno;
using Application.Requests.TurmaAluno;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings;

public class TurmaAlunoMapping : Profile
{
    public TurmaAlunoMapping()
    {
        CreateMap<Turma_Aluno, TurmaAlunoDto>()
           .ForMember(dest => dest.DsTurma, opt => opt.MapFrom(src => src.Turma.DsTurma))
           .ForMember(dest => dest.NmCurso, opt => opt.MapFrom(src => src.Turma.Curso.DsCurso))
           .ForMember(dest => dest.CdCurso, opt => opt.MapFrom(src => src.Turma.Curso.CdCurso));

        CreateMap<AddTurmaAlunoRequest, Turma_Aluno>().ReverseMap();
        CreateMap<DeleteTurmaAlunoRequest, Turma_Aluno>().ReverseMap();

    }
}