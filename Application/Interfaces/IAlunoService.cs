using Application.DTOs.TurmaAluno;
using Application.DTOs.Usuario;
using Application.Requests.Cargos;
using Application.Responses;

namespace Application.Interfaces;

public interface IAlunoService
{
    Task<PagedResponse<List<TurmaAlunoDto>>> GetAllTurmasByUsuarioId(GetAllTurmasByUsuarioIdRequest request);
    Task<Response<TurmaAlunoDto?>> GetAtualTurmaByUsuarioId(GetAtualTurmaByUsuarioIdRequest request);
    Task<PagedResponse<List<UsuarioDto?>>> GetAlunoByLikedName(GetAlunoByLikedNameRequest request);
}