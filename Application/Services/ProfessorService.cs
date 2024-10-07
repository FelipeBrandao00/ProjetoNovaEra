using Application.DTOs.Usuario;
using Application.Requests.Professor;
using Application.Responses;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services;

public class ProfessorService(IProfessorRepository professorRepository, IMapper mapper) : IProfessorService
{
    public async Task<PagedResponse<List<UsuarioDto?>>> GetProfessores(GetProfessoresRequest request)
    {
        try {
            List<Usuario> query = await professorRepository.GetProfessores(request.NmProfessor, request.IcHabilitadoTurma);

            var professores = query
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToList();

            List<UsuarioDto> result = new();
            foreach (var professor in professores) {
                result.Add(mapper.Map<UsuarioDto>(professor));
            }

            return new PagedResponse<List<UsuarioDto>>(
                result,
                query.Count,
                request.PageNumber,
                request.PageSize);
        }
        catch (Exception e) {
            return new PagedResponse<List<UsuarioDto>>(null, 500, "Não foi possível consultar os professores.");
        }
    }

    public async Task<Response<UsuarioDto>> SetProfessorHabilitadoTurma(SetProfessorHabilitadoTurmaRequest request)
    {
        try
        {
           var professor = await professorRepository.SetProfessorHabilitadoTurma(request.CdProfessor);
           if(professor is null) return new Response<UsuarioDto?>(null, 500, "Professor não encontrado.");
           var professorDto = mapper.Map<UsuarioDto>(professor);
           return new Response<UsuarioDto?>(professorDto, 200, "Sucesso ao habilitar professor");
        }
        catch (Exception e)
        {
            return new Response<UsuarioDto?>(null, 500, "Algo deu errado tentando Habilitar o professor.");
        }
    }

    public async Task<Response<UsuarioDto>> SetProfessorDesabilitadoTurma(SetProfessorDesabilitadoTurmaRequest request)
    {
        try
        {
            var professor = await professorRepository.SetProfessorDesabilitadoTurma(request.CdProfessor);
            if(professor is null) return new Response<UsuarioDto?>(null, 500, "Professor não encontrado.");
            var professorDto = mapper.Map<UsuarioDto>(professor);
            return new Response<UsuarioDto?>(professorDto, 200, "Sucesso ao desabilitar professor");
        }
        catch (Exception e)
        {
            return new Response<UsuarioDto?>(null, 500, "Algo deu errado tentando desabilitar o professor.");
        }
    }
}