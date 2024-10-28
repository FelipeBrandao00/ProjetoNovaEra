using Application.DTOs.Frequencia;
using Application.Interfaces;
using Application.Requests.Frequencia;
using Application.Responses;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services {
    public class FrequenciaService(IFrequenciaRepository frequenciaRepository, IMapper mapper, IAulaRepository aulaRepository) : IFrequenciaService {
        public async Task<Response<FrequenciaDto>> AddFrequencia(AddFrequenciaRequest request) {
            try {
                var entity = mapper.Map<Frequencia>(request);
                var retorno = await frequenciaRepository.AddFrequencia(entity);
                await aulaRepository.EfetuarChamada(request.CdAula);
                return new Response<FrequenciaDto>(
                    mapper.Map<FrequenciaDto>(retorno),
                    201,
                    "Frequencia vinculada com sucesso!");
            }
            catch (Exception e) {
                return new Response<FrequenciaDto>(
                    null,
                    500,
                    "Não foi possível registrar a frequencia");
            }
        }

        public async Task<PagedResponse<List<FrequenciaDto>>> AddFrequencias(AddFrequenciasRequest request) {
            try {
                List<Frequencia> frequencias = new List<Frequencia>();

                foreach (var aluno in request.CdAlunos) {
                    var entity = mapper.Map<Frequencia>(new FrequenciaDto { CdAula = request.CdAula, CdTurma = request.CdTurma, CdAluno = aluno });
                    frequencias.Add(entity);
                }

                var retorno = await frequenciaRepository.AddFrequencias(request.CdAula, frequencias);
                await aulaRepository.EfetuarChamada(request.CdAula);

                List<FrequenciaDto> result = new();
                foreach (var frequencia in retorno) {
                    result.Add(mapper.Map<FrequenciaDto>(frequencia));
                }

                return new PagedResponse<List<FrequenciaDto>>(
                    result,
                    result.Count,
                    1,
                    result.Count);
            }
            catch (Exception e) {
                return new PagedResponse<List<FrequenciaDto>>(null, 500, "Não foi possível gravar as frequências");

            }
        }

        public async Task<Response<FrequenciaDto>> DeleteFrequencia(DeleteFrequenciaRequest request) {
            try {
                var entity = mapper.Map<Frequencia>(request);
                var retorno = await frequenciaRepository.DeleteFrequencia(entity);
                return new Response<FrequenciaDto>(
                    mapper.Map<FrequenciaDto>(retorno),
                    201,
                    "Frequencia removida com sucesso!");
            }
            catch (Exception e) {
                return new Response<FrequenciaDto>(
                    null,
                    500,
                    "Não foi possível remover a frequencia");
            }
        }

        public async Task<PagedResponse<List<FrequenciaDto>>> GetFrequenciasByAulaId(GetFrequenciasByAulaIdRequest request) {
            try {
                List<Frequencia> query = await frequenciaRepository.GetFrequenciasByAulaId(request.CdAula);

                var frequencias = query
                    .Skip((request.PageNumber - 1) * request.PageSize)
                    .Take(request.PageSize)
                    .ToList();

                List<FrequenciaDto> result = new();
                foreach (var frequencia in frequencias) {
                    result.Add(mapper.Map<FrequenciaDto>(frequencia));
                }

                return new PagedResponse<List<FrequenciaDto>>(
                    result,
                    query.Count,
                    request.PageNumber,
                    request.PageSize);
            }
            catch (Exception e) {
                return new PagedResponse<List<FrequenciaDto>>(null, 500, "Não foi possível consultar as frequencias");
            }
        }
    }
}
