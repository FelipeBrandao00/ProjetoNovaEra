using Application.DTOs.TurmaAluno;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings;

public class TurmaAlunoMapping : Profile
{
    public TurmaAlunoMapping()
    {
        CreateMap<Turma_Aluno, TurmaAlunoDto>().ReverseMap();
    }
}