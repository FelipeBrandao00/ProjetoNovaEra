using Application.DTOs;
using Application.DTOs.Usuario;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings;

public class UsuarioMapping : Profile
{
    public UsuarioMapping()
    {
        CreateMap<Usuario, AddUsuarioDto>().ReverseMap();        
        CreateMap<Usuario, RegisteredUsuarioDto>().ReverseMap();        
        CreateMap<Usuario, UsuarioDto>().ReverseMap();
    }
}