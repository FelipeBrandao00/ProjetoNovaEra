using Application.DTOs.Curso;
using Application.Interfaces;
using Application.Requests.Curso;
using Application.Responses;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services;

public class CursoService(ICursoRepository _cursoRepository, IMapper mapper) : ICursoService {
    public async Task<Response<CursoDto>> AddCurso(CreateCursoRequest request) {
        try {
            var cursoEntity = mapper.Map<Curso>(request);
            var retorno = await _cursoRepository.AddCurso(cursoEntity);
            return new Response<CursoDto>(
                mapper.Map<CursoDto>(retorno),
                201,
                "Curso criado com sucesso!");
        }
        catch (Exception e) {
            return new Response<CursoDto>(
                null,
                500,
                "Não foi possível criar o curso");
        }
    }

    public async Task<Response<CursoDto>> DeleteCurso(DeleteCursoRequest request) {
        try {
            var cursoEntity = mapper.Map<Curso>(request);
            var retorno = await _cursoRepository.DeleteCurso(cursoEntity);
            return new Response<CursoDto>(
                mapper.Map<CursoDto>(retorno),
                201,
                "Curso excluido com sucesso!");
        }
        catch (Exception e) {
            return new Response<CursoDto>(
                null,
                500,
                "Não foi possível excluido o curso");
        }
    }

    public async Task<Response<CursoDto>> UpdateCurso(UpdateCursoRequest request) {
        try {
            var entity = mapper.Map<Curso>(request);
            var result = await _cursoRepository.UpdateCurso(entity);
            return new Response<CursoDto>(mapper.Map<CursoDto>(result), 200, "Curso atualizado com sucesso!");
        }
        catch (Exception e) {
            return new Response<CursoDto>(null, 500, "Não foi possível atualizar o curso.");
        }
    }

    public async Task<PagedResponse<List<CursoDto>>> GetCursos(GetCursosRequest request) {
        try {
            List<Curso> query = await _cursoRepository.GetCursos(request.Nome, request.DtInicial, request.DtFinal, request.IcFinalizado);

            var usuarios = query
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToList();

            List<CursoDto> result = new();
            foreach (var usuario in usuarios) {
                result.Add(mapper.Map<CursoDto>(usuario));
            }

            return new PagedResponse<List<CursoDto>>(
                result,
                query.Count,
                request.PageNumber,
                request.PageSize);
        }
        catch (Exception e) {
            return new PagedResponse<List<CursoDto>>(null, 500, "Não foi possível consultar os cursos");
        }
    }

    public async Task<Response<CursoDto>> GetCursoByid(GetCursoByidRequest request) {
        try {
            var result = mapper.Map<CursoDto>(await _cursoRepository.GetCursoByid(request.CdCurso));
            return new Response<CursoDto>(result, 200, "Curso encontrado!");
        }
        catch (Exception e) {
            return new Response<CursoDto>(null, 500, "Algo deu errado tentando buscar o curso.");
        }
    }
}