using Domain.Entities;

namespace Domain.Interfaces;

public interface IAlunoRepository
{
    Task<List<Turma_Aluno>> GetAllTurmasByUsuarioId(Guid cdUsuario);
    Task<Turma_Aluno?> GetAtualTurmaByUsuarioId(Guid cdUsuario);
    Task<List<Usuario?>> GetAlunoByLikedName(string nmAluno);
    Task<List<Usuario?>> GetAlunosByTurmaId(int turmaId);
}