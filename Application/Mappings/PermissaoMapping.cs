using Application.DTOs.Permissao;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings;

public class PermissaoMapping : Profile
{
    public PermissaoMapping()
    {
        CreateMap<Permissao, PermissaoDto>().ReverseMap(); 
    }
}