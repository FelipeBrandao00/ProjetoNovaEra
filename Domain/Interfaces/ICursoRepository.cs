﻿using Domain.Entities;

namespace Domain.Interfaces;

public interface ICursoRepository
{
    Task<Curso> AddCurso(Curso curso);
    Task<Curso> DeleteCurso(Curso curso);
    Task<Curso> UpdateCurso(Curso curso);
    Task<List<Curso>> GetCursos();
    Task<Curso> GetCursoByid(int cdCurso);

}