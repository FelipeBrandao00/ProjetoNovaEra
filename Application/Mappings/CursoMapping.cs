using Application.DTOs.Curso;
using Application.Requests.Curso;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings;

public class CursoMapping : Profile {
    public CursoMapping() {
        CreateMap<Curso, CursoDto>().ReverseMap();
        CreateMap<Curso, CreateCursoRequest>().ReverseMap();
        CreateMap<Curso, UpdateCursoRequest>().ReverseMap();
        CreateMap<Curso, DeleteCursoRequest>().ReverseMap();
    }
}