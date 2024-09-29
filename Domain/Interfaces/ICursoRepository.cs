using Domain.Entities;

namespace Domain.Interfaces;

public interface ICursoRepository
{
    Task<Curso> AddCurso(Curso curso);
    Task<Curso> DeleteCurso(Curso curso);
    Task<Curso> UpdateCurso(Curso curso);
    Task<List<Curso>> GetCursos(DateTime? dtInicial = null, DateTime? dtFinal = null, bool icAndamento = true, bool icFinalizado = true);
    Task<Curso> GetCursoByid(int cdCurso);

}