using Application.DTOs.TurmaAluno;
using Application.DTOs.Usuario;
using Application.Requests.Aluno;
using Application.Requests.Cargos;
using Application.Responses;
using Domain.Entities;

namespace Application.Interfaces;

public interface IAlunoService
{
    Task<PagedResponse<List<TurmaAlunoDto>>> GetAllTurmasByUsuarioId(GetAllTurmasByUsuarioIdRequest request);
    Task<Response<TurmaAlunoDto?>> GetAtualTurmaByUsuarioId(GetAtualTurmaByUsuarioIdRequest request);
    Task<PagedResponse<List<UsuarioDto?>>> GetAlunoByLikedName(GetAlunoByLikedNameRequest request);
    Task<PagedResponse<List<UsuarioDto?>>> GetAlunosByTurmaId(GetAlunosByTurmaIdRequest request);
}