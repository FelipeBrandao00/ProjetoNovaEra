using Domain.Entities;

namespace Domain.Interfaces;

public interface ICursoRepository {
    Task<Curso> AddCurso(Curso curso);
    Task<Curso> DeleteCurso(Curso curso);
    Task<Curso> UpdateCurso(Curso curso);
    Task<List<Curso>> GetCursos(string nmCurso, DateTime? dtInicial = null, DateTime? dtFinal = null, bool? icFinalizado = null);
    Task<Curso?> GetCursoByid(int cdCurso);
    Task<Curso> FinalizarCurso(int cdCurso);
    Task<Curso> ReativarCurso(int cdCurso);
}