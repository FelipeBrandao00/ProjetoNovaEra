using Application.DTOs.TurmaAluno;
using Application.Requests.Cargos;
using Application.Responses;

namespace Application.Interfaces;

public interface IAlunoService
{
    Task<PagedResponse<List<TurmaAlunoDto>>> GetAllTurmasByUsuarioId(GetAllTurmasByUsuarioIdRequest request);
    Task<Response<TurmaAlunoDto?>> GetAtualTurmaByUsuarioId(GetAtualTurmaByUsuarioIdRequest request);
}