using Application.DTOs;
using Application.DTOs.Usuario;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings;

public class UsuarioMapping : Profile
{
    public UsuarioMapping()
    {
        CreateMap<Usuario, AddUsuarioRequestDto>().ReverseMap();        
        CreateMap<Usuario, AddUsuarioResponseDto>().ReverseMap();        
        CreateMap<Usuario, GetUsuarioResponseDto>().ReverseMap();        
        CreateMap<Usuario, UsuarioDto>().ReverseMap();
    }
}