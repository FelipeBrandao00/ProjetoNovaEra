using Application.DTOs.Cargo;
using Application.Requests.Cargos;
using Application.Responses;

namespace Application.Interfaces;

public interface ICargoService
{
    Task<PagedResponse<List<CargoDto>>> GetCargos(GetAllCargosRequest request);
}