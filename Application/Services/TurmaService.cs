﻿using Application.DTOs.Cursos;
using Application.DTOs.Turma;
using Application.Interfaces;
using Application.Requests.Turma;
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
    public class TurmaService(ITurmaRepository _turmaRepository, IMapper mapper) : ITurmaService {
        public async Task<Response<TurmaDto>> AddTurma(AddTurmaRequest request) {
            try {
                var turmaEntity = mapper.Map<Turma>(request);
                var retorno = await _turmaRepository.AddTurma(turmaEntity);
                return new Response<TurmaDto>(
                    mapper.Map<TurmaDto>(retorno),
                    201,
                    "Turma criada com sucesso!");
            }
            catch (Exception e) {
                return new Response<TurmaDto>(
                    null,
                    500,
                    "Não foi possível criar a turma");
            }
        }
        public async Task<Response<TurmaDto>> FinalizarTurma(FinalizarTurmaRequest request) {
            try {
                var retorno = await _turmaRepository.FinalizarTurma(request.CdTurma);
                return new Response<TurmaDto>(
                    mapper.Map<TurmaDto>(retorno),
                    200,
                    "Turma finalizada com sucesso!");
            }
            catch (Exception e) {
                return new Response<TurmaDto>(
                    null,
                    500,
                    "Não foi possível finalizar a turma");
            }
        }

        public async Task<Response<TurmaDto?>> GetTurmaById(GetTurmaByIdRequest request) {
            try {
                var result = mapper.Map<TurmaDto>(await _turmaRepository.GetTurmaById(request.CdTurma));
                return new Response<TurmaDto>(result, 200, "Turma encontrada!");
            }
            catch (Exception e) {
                return new Response<TurmaDto>(null, 500, "Algo deu errado tentando buscar a turma.");
            }
        }

        public async Task<PagedResponse<List<TurmaDto>>> GetTurmas(GetTurmasRequest request) {
            try {
                List<Turma> query = await _turmaRepository.GetTurmas(request.Nome,request.DtInicial,request.DtFinal,request.IcFinalizado,request.CursoId);

                var usuarios = query
                    .Skip((request.PageNumber - 1) * request.PageSize)
                    .Take(request.PageSize)
                    .ToList();

                List<TurmaDto> result = new();
                foreach (var usuario in usuarios) {
                    result.Add(mapper.Map<TurmaDto>(usuario));
                }

                return new PagedResponse<List<TurmaDto>>(
                    result,
                    query.Count,
                    request.PageNumber,
                    request.PageSize);
            }
            catch (Exception e) {
                return new PagedResponse<List<TurmaDto>>(null, 500, "Não foi possível consultar as turmas");
            }
        }

        public async Task<Response<TurmaDto>> ReativarTurma(ReativarTurmaRequest request) {
            try {
                var retorno = await _turmaRepository.ReativarTurma(request.CdTurma);
                return new Response<TurmaDto>(
                    mapper.Map<TurmaDto>(retorno),
                    200,
                    "Turma reativada com sucesso!");
            }
            catch (Exception e) {
                return new Response<TurmaDto>(
                    null,
                    500,
                    "Não foi possível reativar a turma");
            }
        }

        public async Task<Response<TurmaDto>> UpdateTurma(UpdateTurmaRequest request) {
            try {
                var entity = mapper.Map<Turma>(request);
                var result = await _turmaRepository.UpdateTurma(entity);
                return new Response<TurmaDto>(mapper.Map<TurmaDto>(result), 200, "Turma atualizada com sucesso!");
            }
            catch (Exception e) {
                return new Response<TurmaDto>(null, 500, "Não foi possível atualizar a turma.");
            }
        }
    }
}
