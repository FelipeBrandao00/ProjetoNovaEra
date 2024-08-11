using Application.DTOs;
using Application.DTOs.Cargo;
using Application.DTOs.CargoUsuario;
using Application.DTOs.Usuario;
using Application.Interfaces;
using Application.Requests.CargoUsuario;
using Application.Responses;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services;

public class CargoUsuarioService(ICargoUsuarioRepository cargoUsuarioRepository, IMapper mapper) : ICargoUsuarioService
{
    public async Task<Response<CargoUsuarioDto>> AddCargoUsuario(CreateCargoUsuarioRequest request)
    {
        try
        {
            var entity = mapper.Map<Cargo_Usuario>(request);
            var retorno =  await cargoUsuarioRepository.AddCargoUsuario(entity);
            return new Response<CargoUsuarioDto>(
                mapper.Map<CargoUsuarioDto>(retorno), 
                201, 
                "Cargo vinculado com sucesso!");
        }
        catch (Exception e)
        {
            return new Response<CargoUsuarioDto>(
                null, 
                500, 
                "Não foi possível vincular o cargo");
        }
    }

    public async Task<Response<CargoUsuarioDto>> DeleteCargoUsuario(DeleteCargoUsuarioRequest request)
    {
        try
        {
            var entity = mapper.Map<Cargo_Usuario>(request);
            var retorno =  await cargoUsuarioRepository.DeleteCargoUsuario(entity);
            return new Response<CargoUsuarioDto>(
                mapper.Map<CargoUsuarioDto>(retorno), 
                201, 
                "Cargo desvinculado com sucesso!");
        }
        catch (Exception e)
        {
            return new Response<CargoUsuarioDto>(
                null, 
                500, 
                "Não foi possível desvincular o cargo");
        }
    }

    public async Task<PagedResponse<List<CargoDto>>> GetCargosByUserId(GetCargosByUserIdRequest request)
    {
        try
        {
            List<Cargo_Usuario> query = await cargoUsuarioRepository.GetCargosByUserId(request.CdUsuario);
            
            var cargosUsuario =query
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToList();
            
            List<CargoDto> result = new();
            foreach (var cargo in cargosUsuario)
            {
                result.Add(mapper.Map<CargoDto>(cargo.Cargo));
            }

            return new PagedResponse<List<CargoDto>>(
                result,
                query.Count,
                request.PageNumber,
                request.PageSize);
        }
        catch (Exception e)
        {
            return new PagedResponse<List<CargoDto>>(null, 500, "Não foi possível consultar os cargos do usuario");
        }
    }
}