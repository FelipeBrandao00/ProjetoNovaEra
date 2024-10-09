using Domain.Entities;

namespace Domain.Interfaces;

public interface IProfessorRepository
{
    Task<List<Usuario?>> GetProfessores(string nmProfessor = null,bool? icHabilitadoTurma = null);
    Task<Usuario> SetProfessorHabilitadoTurma(Guid cdProfessor);
    Task<Usuario> SetProfessorDesabilitadoTurma(Guid cdProfessor);
}