using API_NOVA_ERA.Database;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Data.Repositories
{
    public class MatriculaRepository(ApplicationDbContext _context) : IMatriculaRepository
    {
        public async Task<Matricula?> AddMatricula(Matricula matricula)
        {
            if (_context.Matriculas.Where(x => x.DsCpf == matricula.DsCpf && x.CdTurma == matricula.CdTurma).Any()) {
                return null;
            }

            _context.Matriculas.Add(matricula);
            await _context.SaveChangesAsync();
            return matricula;
        }

        public async Task<Matricula> DeleteMatricula(Matricula matricula)
        {
            _context.Matriculas.Remove(matricula);
            await _context.SaveChangesAsync();
            return matricula;
        }

        public async Task<Matricula> GetMatriculaById(int matriculaId) => await _context.Matriculas.Where(x => x.CdMatricula == matriculaId).FirstOrDefaultAsync();

        public async Task<List<Matricula>> GetMatriculasByTurmaId(int turmaId) => await _context.Matriculas.Where(x => x.CdTurma == turmaId)
            .Include(turma => turma.Turma)
            .ToListAsync();
    }
}
