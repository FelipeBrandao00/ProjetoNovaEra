using Application.DTOs.Turma;
using Application.Requests.Turma;
using Application.Responses;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces {
    public interface ITurmaService {
        Task<Response<TurmaDto>> AddTurma(AddTurmaRequest request);
        Task<Response<TurmaDto>> UpdateTurma(UpdateTurmaRequest request);
        Task<PagedResponse<List<TurmaDto>>> GetTurmas(GetTurmasRequest request); 
        Task<Response<TurmaDto?>> GetTurmaById(GetTurmaByIdRequest request);
        Task<Response<TurmaDto>> FinalizarTurma(FinalizarTurmaRequest request);
        Task<Response<TurmaDto>> ReativarTurma(ReativarTurmaRequest request);
        Task<Response<TurmaDto>> HabilitarMatricula(HabilitarMatriculaRequest request);
        Task<Response<TurmaDto>> EncerrarMatricula(EncerrarMatriculaRequest request);
        Task<PagedResponse<List<TurmaDto>>> GetTurmasAbertaMatricula(GetTurmasAbertaMatriculaRequest request);
    }
}
