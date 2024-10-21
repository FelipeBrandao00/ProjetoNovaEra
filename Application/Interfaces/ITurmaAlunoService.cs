using Application.DTOs.TurmaAluno;
using Application.Requests.TurmaAluno;
using Application.Responses;
using Domain.Entities;

namespace Application.Interfaces {
    public interface ITurmaAlunoService {
        Task<Response<TurmaAlunoDto>> AddTurmaAluno(AddTurmaAlunoRequest request);
        Task<Response<TurmaAlunoDto>> DeleteTurmaAluno(DeleteTurmaAlunoRequest request);
    }
}
