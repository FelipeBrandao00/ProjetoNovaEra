using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces {
    public interface ITurmaRepository {
        Task<Turma> AddTurma(Turma turma);
        Task<Turma> DeleteTurma(Turma turma);
        Task<Turma> UpdateTurma(Turma turma);
        Task<Turma> GetTurmas(); //falta os filtros
        Task<Turma> GetTurmaById(int CdTurma);
        Task<Turma> FinalizarTurma(int CdTurma);
        Task<Turma> ReativarTurma(int CdTurma);
    }
}
