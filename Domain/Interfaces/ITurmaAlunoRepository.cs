using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces {
    public interface ITurmaAlunoRepository {
        Task<Turma_Aluno> AddTurmaAluno(Turma_Aluno turmaAluno);
        Task<Turma_Aluno> DeleteTurmaAluno(Turma_Aluno turmaAluno);
    }
}
