﻿using Application.DTOs.Aula;
using Application.DTOs.Cursos;
using Application.Interfaces;
using Application.Requests.Aula;
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
    public class AulaService(IAulaRepository aulaRepository, IMapper mapper) : IAulaService {
        public async Task<Response<AulaDto>> AddAula(AddAulaRequest request) {
            try {
                var Entity = mapper.Map<Aula>(request);
                var retorno = await aulaRepository.AddAula(Entity);
                return new Response<AulaDto>(
                    mapper.Map<AulaDto>(retorno),
                    201,
                    "Aula criada com sucesso!");
            }
            catch (Exception e) {
                return new Response<AulaDto>(
                    null,
                    500,
                    "Não foi possível criar a aula");
            }
        }

        public async Task<Response<AulaDto>> DeleteAula(DeleteAulaRequest request) {
            try {
                var Entity = await aulaRepository.GetAulaById(request.CdAula);
                if (Entity == null) return new Response<AulaDto>(null, 500,"Aula não encontrada");

                var retorno = await aulaRepository.DeleteAula(Entity);
                return new Response<AulaDto>(
                    mapper.Map<AulaDto>(retorno),
                    201,
                    "Aula excluida com sucesso!");
            }
            catch (Exception e) {
                return new Response<AulaDto>(
                    null,
                    500,
                    "Não foi possível excluir a aula");
            }
        }

        public async Task<Response<AulaDto?>> GetAulaById(GetAulaByIdRequest request) {
            try {
                var result = mapper.Map<AulaDto>(await aulaRepository.GetAulaById(request.CdAula));
                return new Response<AulaDto?>(result, 200, "Aula encontrada!");
            }
            catch (Exception e) {
                return new Response<AulaDto?>(null, 500, "Algo deu errado tentando buscar a aula.");
            }
        }

        public async Task<PagedResponse<List<AulaDto>>> GetAulasByTurmaId(GetAulasByTurmaIdRequest request) {
            try {
                List<Aula> query = await aulaRepository.GetAulasByTurmaId(request.TurmaId);

                var aulas = query
                    .Skip((request.PageNumber - 1) * request.PageSize)
                    .Take(request.PageSize)
                    .ToList();

                List<AulaDto> result = new();
                foreach (var aula in aulas) {
                    result.Add(mapper.Map<AulaDto>(aula));
                }

                return new PagedResponse<List<AulaDto>>(
                    result,
                    query.Count,
                    request.PageNumber,
                    request.PageSize);
            }
            catch (Exception e) {
                return new PagedResponse<List<AulaDto>>(null, 500, "Não foi possível consultar as aulas");
            }
        }

        public async Task<Response<AulaDto>> UpdateAula(UpdateAulaRequest request) {
            try {
                var Entity = await aulaRepository.GetAulaById(request.CdAula);
                if (Entity == null) return new Response<AulaDto>(null, 500, "Aula não encontrada"); 
                
                Entity.DtAula = request.DtAula;
                Entity.DsAula = request.DsAula;

                var retorno = await aulaRepository.UpdateAula(Entity);

                return new Response<AulaDto>(
                    mapper.Map<AulaDto>(retorno),
                    201,
                    "Aula atualizada com sucesso!");
            }
            catch (Exception e) {
                return new Response<AulaDto>(
                    null,
                    500,
                    "Não foi possível atualizar a aula");
            }
        }
    }
}
