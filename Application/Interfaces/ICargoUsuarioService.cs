using Application.DTOs.Cargo;
using Application.DTOs.CargoUsuario;
using Application.Requests.CargoUsuario;
using Application.Responses;
using Domain.Entities;

namespace Application.Interfaces;

public interface ICargoUsuarioService
{
    Task<Response<CargoUsuarioDto>> AddCargoUsuario(CreateCargoUsuarioRequest request);
    Task<Response<CargoUsuarioDto>> DeleteCargoUsuario(DeleteCargoUsuarioRequest request);
    Task<PagedResponse<List<CargoDto>>> GetCargosByUserId(GetCargosByUserIdRequest request);
    Task<PagedResponse<List<CargoDto>>> AddCargosUsuario(AddCargosUsuarioRequest request);

}