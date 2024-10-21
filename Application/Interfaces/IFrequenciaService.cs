using Application.DTOs.Frequencia;
using Application.Requests.Frequencia;
using Application.Responses;
using Domain.Entities;

namespace Application.Interfaces {
    public interface IFrequenciaService {
        Task<Response<FrequenciaDto>> AddFrequencia(AddFrequenciaRequest request);
        Task<Response<FrequenciaDto>> DeleteFrequencia(DeleteFrequenciaRequest request);
        Task<PagedResponse<List<FrequenciaDto>>> GetFrequenciasByAulaId(GetFrequenciasByAulaIdRequest request);
    }
}
