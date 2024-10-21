using Application.DTOs.Aula;
using Application.Requests.Aula;
using Application.Responses;

namespace Application.Interfaces {
    public interface IAulaService {
        Task<Response<AulaDto>> AddAula(AddAulaRequest request);
        Task<Response<AulaDto>> DeleteAula(DeleteAulaRequest request);
        Task<Response<AulaDto>> UpdateAula(UpdateAulaRequest request);
        Task<PagedResponse<List<AulaDto>>> GetAulasByTurmaId(GetAulasByTurmaIdRequest request);
        Task<Response<AulaDto?>> GetAulaById(GetAulaByIdRequest request);
    }
}
