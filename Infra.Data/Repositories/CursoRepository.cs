﻿using API_NOVA_ERA.Database;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Repositories;

public class CursoRepository(ApplicationDbContext _context) : ICursoRepository
{
    public async Task<Curso> AddCurso(Curso curso)
    {
        _context.Cursos.Add(curso);
        await _context.SaveChangesAsync();
        return curso;
    }

    public async Task<Curso> DeleteCurso(Curso curso)
    {
        _context.Cursos.Remove(curso);
        await _context.SaveChangesAsync();
        return curso;    }

    public async Task<Curso> UpdateCurso(Curso curso)
    {
        _context.Cursos.Update(curso);
        await _context.SaveChangesAsync();
        return curso;    }

    public async Task<List<Curso>> GetCursos(DateTime? dtInicial = null, DateTime? dtFinal = null, bool icAndamento = true, bool icFinalizado = true)
    {
        IQueryable<Curso> cursos =  _context.Cursos;

        if (dtInicial != null)
            cursos = cursos.Where(x => x.DtCriacao >= dtInicial.Value);
        
        if (dtFinal != null)
            cursos = cursos.Where(x => x.DtCriacao <= dtFinal.Value);
        
        if (!icAndamento)
            cursos = cursos.Where(x => x.DtFinalizacao != null);
        
        if (!icFinalizado)
            cursos = cursos.Where(x => x.DtFinalizacao != null);

        return await cursos.ToListAsync();
    }

    public async Task<Curso> GetCursoByid(int cdCurso)
    {
        return await _context.Cursos.Where(x => x.CdCurso == cdCurso).FirstOrDefaultAsync();
    }
}