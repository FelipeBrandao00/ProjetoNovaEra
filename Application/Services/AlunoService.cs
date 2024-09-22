using Application.DTOs.TurmaAluno;
using Application.DTOs.Usuario;
using Application.Interfaces;
using Application.Requests.Cargos;
using Application.Responses;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services;

public class AlunoService(IAlunoRepository alunoRepository, IMapper mapper) : IAlunoService {
    public async Task<PagedResponse<List<TurmaAlunoDto>>> GetAllTurmasByUsuarioId(GetAllTurmasByUsuarioIdRequest request) {
        try {
            List<Turma_Aluno> query = await alunoRepository.GetAllTurmasByUsuarioId(request.CdAluno);

            var TurmasAluno = query
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToList();

            List<TurmaAlunoDto> result = new();
            foreach (var turma in TurmasAluno) {
                result.Add(mapper.Map<TurmaAlunoDto>(turma));
            }

            return new PagedResponse<List<TurmaAlunoDto>>(
                result,
                query.Count,
                request.PageNumber,
                request.PageSize);
        }
        catch (Exception e) {
            return new PagedResponse<List<TurmaAlunoDto>>(null, 500, "Não foi possível consultar as turmas do aluno.");
        }
    }

    public async Task<Response<TurmaAlunoDto?>> GetAtualTurmaByUsuarioId(GetAtualTurmaByUsuarioIdRequest request) {
        try {
            var result = mapper.Map<TurmaAlunoDto>(await alunoRepository.GetAtualTurmaByUsuarioId(request.CdAluno));
            return new Response<TurmaAlunoDto?>(result, 200, "Sucesso ao buscar turma atual do aluno.");
        }
        catch (Exception e) {
            return new Response<TurmaAlunoDto?>(null, 500, "Algo deu errado tentando buscar a turma atual do aluno.");
        }
    }

    public async Task<PagedResponse<List<UsuarioDto?>>> GetAlunoByLikedName(GetAlunoByLikedNameRequest request)
    {
        try {
            List<Usuario> query = await alunoRepository.GetAlunoByLikedName(request.NmUsuario);

            var alunos = query
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToList();

            List<UsuarioDto> result = new();
            foreach (var aluno in alunos) {
                result.Add(mapper.Map<UsuarioDto>(aluno));
            }

            return new PagedResponse<List<UsuarioDto>>(
                result,
                query.Count,
                request.PageNumber,
                request.PageSize);
        }
        catch (Exception e) {
            return new PagedResponse<List<UsuarioDto>>(null, 500, "Não foi possível consultar os alunos.");
        }
    }
}