using Application.DTOs.Cargo;
using Application.Interfaces;
using Application.Requests.Cargos;
using Application.Responses;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services;

public class CargoService(ICargoRepository cargoRepository, IMapper mapper) : ICargoService
{
    public async Task<PagedResponse<List<CargoDto>>> GetCargos(GetAllCargosRequest request)
    {
        try
        {
            List<Cargo> query = await cargoRepository.GetCargos();
            
            var cargos =query
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToList();
            
            List<CargoDto> result = new();
            foreach (var cargo in cargos)
            {
                result.Add(mapper.Map<CargoDto>(cargo));
            }

            return new PagedResponse<List<CargoDto>>(
                result,
                query.Count,
                request.PageNumber,
                request.PageSize);
        }
        catch (Exception e)
        {
            return new PagedResponse<List<CargoDto>>(null, 500, "Não foi possível consultar os cargos");

        }
    }
}