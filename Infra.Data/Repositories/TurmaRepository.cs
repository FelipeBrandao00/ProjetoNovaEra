﻿using API_NOVA_ERA.Database;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Repositories {
    public class TurmaRepository(ApplicationDbContext _context) : ITurmaRepository {
        public async Task<Turma> AddTurma(Turma turma) {
            _context.Turmas.Add(turma);
            await _context.SaveChangesAsync();
            return turma;
        }
        public async Task<Turma> FinalizarTurma(int CdTurma) {
            var turma = await GetTurmaById(CdTurma);

            if (turma != null && turma.DtFim == null) {
                turma.DtFim = DateTime.Now;
                await _context.SaveChangesAsync();
            }
            return turma;
        }

        public async Task<Turma?> GetTurmaById(int CdTurma) {
            return await _context.Turmas.Where(x => x.CdTurma == CdTurma).FirstOrDefaultAsync();
        }

        public async Task<List<Turma>> GetTurmas(string nome, DateTime? dtInicial = null, DateTime? dtFinal = null, bool? icFinalizado = null, int? cursoId = null) {
            IQueryable<Turma> turmas = _context.Turmas;

            if (!string.IsNullOrEmpty(nome)) {
                turmas = turmas.Where(x => x.DsTurma.Contains(nome));
            }

            if (dtInicial != null)
                turmas = turmas.Where(x => x.DtInicio >= dtInicial.Value);

            if (dtFinal != null)
                turmas = turmas.Where(x => x.DtInicio <= dtFinal.Value);

            if (icFinalizado != null)
                turmas = (icFinalizado == true) ? turmas.Where(x => x.DtFim != null) : turmas.Where(x => x.DtFim == null);

            if (cursoId != null)
                turmas = turmas.Where(x => x.CdCurso == cursoId);

            return await turmas.ToListAsync();
        }

        public async Task<Turma> ReativarTurma(int CdTurma) {
            var turma = await GetTurmaById(CdTurma);

            if (turma != null && turma.DtFim != null) {
                turma.DtFim = null;
                await _context.SaveChangesAsync();
            }
            return turma;
        }

        public async Task<Turma> UpdateTurma(Turma turma) {
            _context.Turmas.Update(turma);
            await _context.SaveChangesAsync();
            return turma;
        }
    }
}
