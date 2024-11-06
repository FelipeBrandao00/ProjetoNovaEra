using Application.DTOs.Aula;
using Application.DTOs.CargoUsuario;
using Application.DTOs.Matricula;
using Application.DTOs.TurmaAluno;
using Application.DTOs.Usuario;
using Application.Interfaces;
using Application.Requests.CargoUsuario;
using Application.Requests.Matricula;
using Application.Requests.TurmaAluno;
using Application.Responses;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class MatriculaService(IMatriculaRepository matriculaRepository, IUsuarioRepository usuarioRepository, IMapper mapper,ICargoUsuarioRepository cargoUsuarioRepository, ITurmaAlunoRepository turmaAlunoRepository) : IMatriculaService
    {
        public async Task<Response<MatriculaDto>> AddMatricula(AddMatriculaRequest request)
        {
            try
            {
                var Entity = mapper.Map<Matricula>(request);
                var retorno = await matriculaRepository.AddMatricula(Entity);

                if(retorno == null) return new Response<MatriculaDto>(
                    null,
                    400,
                    "Você ja se matriculou para essa turma!");

                return new Response<MatriculaDto>(
                    mapper.Map<MatriculaDto>(retorno),
                    201,
                    "Matricula realizada com sucesso!");
            }
            catch (Exception e)
            {
                return new Response<MatriculaDto>(
                    null,
                    500,
                    "Não foi possível realizar a matricula");
            }
        }

        public async Task<PagedResponse<List<UsuarioDto>>> EfetivarMatriculas(EfetivarMatriculasRequest request)
        {
            try
            {
                var matriculasEfetivadas = new List<UsuarioDto>();
            foreach (var matriculaId in request.MatriculaIds)
            {
                var matricula = await matriculaRepository.GetMatriculaById(matriculaId);

                if (matricula == null) continue;

                var usuarioEntity = mapper.Map<Usuario>(matricula);

                var usuario = await usuarioRepository.GetUsuarioByCpf(matricula.DsCpf) ?? await usuarioRepository.AddUsuario(usuarioEntity);

                var cargos = await cargoUsuarioRepository.GetCargosByUserId(usuario.CdUsuario);

                if (cargos.Where(x => x.CdCargo == 3).Count() == 0)
                {
                    var cargoUsuario = new CreateCargoUsuarioRequest { CdUsuario = usuario.CdUsuario, CdCargo = 3 };
                    await cargoUsuarioRepository.AddCargoUsuario(mapper.Map<Cargo_Usuario>(cargoUsuario));
                }

                var turmaAluno = new AddTurmaAlunoRequest {CdAluno = usuario.CdUsuario, CdTurma = matricula.CdTurma };

                await turmaAlunoRepository.AddTurmaAluno(mapper.Map<Turma_Aluno>(turmaAluno));

                await matriculaRepository.DeleteMatricula(matricula);

                matriculasEfetivadas.Add(mapper.Map<UsuarioDto>(usuario));

            }
            return new PagedResponse<List<UsuarioDto>>(matriculasEfetivadas,matriculasEfetivadas.Count,1,matriculasEfetivadas.Count);
            }
            catch (Exception e)
            {
                return new PagedResponse<List<UsuarioDto>>(null, 500, "Não foi possível efetivar as matriculas");
            }
        }

        public async Task<Response<MatriculaDto>> GetMatriculaById(GetMatriculaByIdRequest request)
        {
            try
            {
                var result = mapper.Map<MatriculaDto>(await matriculaRepository.GetMatriculaById(request.CdMatricula));
                return new Response<MatriculaDto>(result, 200, "Matricula encontrado!");
            }
            catch (Exception e)
            {
                return new Response<MatriculaDto>(null, 500, "Algo deu errado tentando buscar a matricula.");

            }
        }

        public async Task<Response<List<MatriculaDto>>> GetMatriculasByTurmaId(GetMatriculasByTurmaIdRequest request)
        {
            try
            {
                List<Matricula> matriculas = await matriculaRepository.GetMatriculasByTurmaId(request.CdTurma);

                List<MatriculaDto> result = new();
                foreach (var matricula in matriculas)
                {
                    result.Add(mapper.Map<MatriculaDto>(matricula));
                }
                return new Response<List<MatriculaDto>>(result, 200, "Sucesso consultando as matriculas.");
            }
            catch (Exception e)
            {
                return new Response<List<MatriculaDto>>(null, 500, "Não foi possível consultar as matriculas.");
            }
        }
    }
}
