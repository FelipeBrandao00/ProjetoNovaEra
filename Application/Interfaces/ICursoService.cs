﻿using Application.DTOs.Cursos;
using Application.Requests.Curso;
using Application.Responses;
using Domain.Entities;

namespace Application.Interfaces;

public interface ICursoService
{
    Task<Response<CursoDto>> AddCurso(CreateCursoRequest request);
    Task<Response<CursoDto>> DeleteCurso(DeleteCursoRequest request);
    Task<Response<CursoDto>> UpdateCurso(UpdateCursoRequest request);
    Task<PagedResponse<List<CursoDto>>> GetCursos(GetCursosRequest request);
    Task<Response<CursoDto>> GetCursoByid(GetCursoByidRequest request);
    Task<Response<CursoDto>> FinalizarCurso(FinishCursoByidRequest request);
    Task<Response<CursoDto>> ReativarCurso(ReactivateCursoByidRequest request);
}