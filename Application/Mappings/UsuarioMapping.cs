using Application.DTOs;
using Application.DTOs.Jwt;
using Application.Requests.Usuarios;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings;

public class UsuarioMapping : Profile
{
    public UsuarioMapping()
    {
        CreateMap<Usuario, CreateUsuarioRequest>().ReverseMap(); 
        CreateMap<Usuario, UpdateUsuarioRequest>().ReverseMap(); 
        CreateMap<Usuario, UsuarioDto>().ReverseMap();
        CreateMap<Usuario, JwtDto>().ReverseMap();
    }
}