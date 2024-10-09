using Application.DTOs.Generos;
using Application.Requests.Generos;
using Application.Responses;

namespace Application.Interfaces {
    public interface IGeneroService {
        Task<PagedResponse<List<GeneroDto>>> GetGeneros(GetGenerosRequest request);
        Task<Response<GeneroDto>> GetGeneroById(GetGeneroByIdRequest request);
    }
}
