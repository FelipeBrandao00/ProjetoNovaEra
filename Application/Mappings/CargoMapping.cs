using Application.DTOs.Cargo;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings;

public class CargoMapping : Profile
{
    public CargoMapping()
    {
        CreateMap<Cargo, CargoDto>().ReverseMap(); 
    }
}