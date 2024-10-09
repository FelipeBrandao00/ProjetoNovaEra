using Application.DTOs.Usuario;
using Application.Requests.Professor;
using Application.Responses;

namespace Application.Services;

public interface IProfessorService
{
    Task<PagedResponse<List<UsuarioDto?>>> GetProfessores(GetProfessoresRequest request);
    Task<Response<UsuarioDto>> SetProfessorHabilitadoTurma(SetProfessorHabilitadoTurmaRequest request);
    Task<Response<UsuarioDto>> SetProfessorDesabilitadoTurma(SetProfessorDesabilitadoTurmaRequest request);
}