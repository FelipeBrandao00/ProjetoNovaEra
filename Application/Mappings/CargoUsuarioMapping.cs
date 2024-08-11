using Application.DTOs.Cargo;
using Application.DTOs.CargoUsuario;
using Application.Requests.CargoUsuario;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings;

public class CargoUsuarioMapping : Profile
{
    public CargoUsuarioMapping()
    {
        CreateMap<CargoUsuarioDto, Cargo_Usuario>().ReverseMap();
        CreateMap<CreateCargoUsuarioRequest, Cargo_Usuario>().ReverseMap(); 
        CreateMap<DeleteCargoUsuarioRequest, Cargo_Usuario>().ReverseMap(); 
        CreateMap<CargoUsuarioDto, CreateCargoUsuarioRequest>().ReverseMap(); 

    }
}