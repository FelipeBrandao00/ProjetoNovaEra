using Application.DTOs.PermissaoCargo;
using Application.Requests;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings;

public class PermissaoCargoMapping : Profile
{
    public PermissaoCargoMapping()
    {
        CreateMap<PermissaoCargoDto, Permissao_Cargos>().ReverseMap();
        CreateMap<CreatePermissaoCargoRequest, Permissao_Cargos>().ReverseMap();     
        CreateMap<DeletePermissaoCargoRequest, Permissao_Cargos>().ReverseMap();
        CreateMap<PermissaoCargoDto, CreatePermissaoCargoRequest>().ReverseMap();

    }
}