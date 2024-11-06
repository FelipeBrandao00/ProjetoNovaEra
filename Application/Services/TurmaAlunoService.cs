using Application.DTOs.TurmaAluno;
using Application.Interfaces;
using Application.Requests.TurmaAluno;
using Application.Responses;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services {
    public class TurmaAlunoService(ITurmaAlunoRepository turmaAlunoRepository, IMapper mapper) : ITurmaAlunoService {
        public async Task<Response<TurmaAlunoDto>> AddTurmaAluno(AddTurmaAlunoRequest request) {
            try {
                var entity = mapper.Map<Turma_Aluno>(request);
                var retorno = await turmaAlunoRepository.AddTurmaAluno(entity);
                return new Response<TurmaAlunoDto>(
                    mapper.Map<TurmaAlunoDto>(retorno),
                    201,
                    "Aluno matriculado com sucesso!");
            }
            catch (Exception e) {
                return new Response<TurmaAlunoDto>(
                    null,
                    500,
                    "Não foi possível matricular o aluno");
            }
        }

        public async Task<Response<TurmaAlunoDto>> DeleteTurmaAluno(DeleteTurmaAlunoRequest request) {
            try {
                var entity = mapper.Map<Turma_Aluno>(request);
                var retorno = await turmaAlunoRepository.DeleteTurmaAluno(entity);
                return new Response<TurmaAlunoDto>(
                    mapper.Map<TurmaAlunoDto>(retorno),
                    201,
                    "Aluno desmatriculado com sucesso!");
            }
            catch (Exception e) {
                return new Response<TurmaAlunoDto>(
                    null,
                    500,
                    "Não foi possível desmatricular o aluno");
            }
        }
    }
}
