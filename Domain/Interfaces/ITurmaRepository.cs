using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces {
    public interface ITurmaRepository {
        Task<Turma> AddTurma(Turma turma);
        Task<Turma> UpdateTurma(Turma turma);
        Task<List<Turma>> GetTurmas(string nome, DateTime? dtInicial = null, DateTime? dtFinal = null, bool? icFinalizado = null, int? cursoId = null); //falta os filtros
        Task<Turma?> GetTurmaById(int CdTurma);
        Task<Turma> FinalizarTurma(int CdTurma);
        Task<Turma> ReativarTurma(int CdTurma);
    }
}
