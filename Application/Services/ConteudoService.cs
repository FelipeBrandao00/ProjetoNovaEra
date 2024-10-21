using Application.DTOs.Conteudo;
using Application.DTOs.Cursos;
using Application.Interfaces;
using Application.Requests.Conteudo;
using Application.Responses;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services {
    public class ConteudoService(IConteudoRepository _conteudoRepository, IMapper mapper, IFileService fileService) : IConteudoService {
        public async Task<Response<ConteudoDto>> AddConteudo(AddConteudoRequest request) {
            try {
                var Entity = mapper.Map<Conteudo>(request);
                Entity.NmArquivo = Path.GetFileNameWithoutExtension(request.Arquivo.FileName);
                Entity.DsExtensao = Path.GetExtension(request.Arquivo.FileName);


                var path = $"Turmas/Turma{request.CdTurma}/Aula{request.CdAula}/";
                await fileService.SaveFileAsync(request.Arquivo, path);

                var retorno = await _conteudoRepository.AddConteudo(Entity);
                return new Response<ConteudoDto>(
                    mapper.Map<ConteudoDto>(retorno),
                    201,
                    "Conteudo criado com sucesso!");
            }
            catch (Exception e) {
                return new Response<ConteudoDto>(
                    null,
                    500,
                    "Não foi possível criar o conteudo");
            }
        }

        public async Task<Response<ConteudoDto>> DeleteConteudo(DeleteConteudoRequest request) {
            try {
                var Entity = await _conteudoRepository.GetConteudoById(request.CdConteudo);

                if(Entity == null) return new Response<ConteudoDto>(null, 500, "Não foi possível encontrar o conteudo");
                var path = $"Turmas/Turma{Entity.CdTurma}/Aula{Entity.CdAula}/";
                var fileName = $"{Entity.NmArquivo}{Entity.DsExtensao}";

                fileService.DeleteFile(path, fileName);

                var retorno = await _conteudoRepository.DeleteConteudo(Entity);
                return new Response<ConteudoDto>(
                    mapper.Map<ConteudoDto>(retorno),
                    201,
                    "Conteudo deletado com sucesso!");
            }
            catch (Exception e) {
                return new Response<ConteudoDto>(
                    null,
                    500,
                    "Não foi possível deletar o conteudo");
            }
        }

        public async Task<Response<ConteudoDto>?> GetConteudoById(GetConteudoByIdRequest request) {
            try {

                var entity = await _conteudoRepository.GetConteudoById(request.CdConteudo);
                var result = mapper.Map<ConteudoDto>(entity);
                var path = $"Turmas/Turma{entity.CdTurma}/Aula{entity.CdAula}/";
                var fileName = $"{entity.NmArquivo}{entity.DsExtensao}";

                var file = await fileService.GetFileAsync(path, fileName);

                result.Arquivo = file;

                return new Response<ConteudoDto>(result, 200, "Conteudo encontrado!");
            }
            catch (Exception e) {
                return new Response<ConteudoDto>(null, 500, "Algo deu errado tentando buscar o conteudo.");
            }
        }

        public async Task<PagedResponse<List<ConteudoDto>>> GetConteudosByAulaId(GetConteudosByAulaIdRequest request) {
            try {
                List<Conteudo> query = await _conteudoRepository.GetConteudosByAulaId(request.AulaId);

                var conteudos = query
                    .Skip((request.PageNumber - 1) * request.PageSize)
                    .Take(request.PageSize)
                    .ToList();

                List<ConteudoDto> result = new();
                foreach (var conteudo in conteudos) {
                    result.Add(mapper.Map<ConteudoDto>(conteudo));
                }

                return new PagedResponse<List<ConteudoDto>>(
                    result,
                    query.Count,
                    request.PageNumber,
                    request.PageSize);
            }
            catch (Exception e) {
                return new PagedResponse<List<ConteudoDto>>(null, 500, "Não foi possível consultar os conteudos");
            }
        }

        public async Task<Response<ConteudoDto>> UpdateConteudo(UpdateConteudoRequest request) {
            try {
                var Entity = await _conteudoRepository.GetConteudoById(request.CdConteudo);

                if (Entity == null) return new Response<ConteudoDto>(null, 500, "Não foi possível encontrar o conteudo");

                Entity.DsConteudo = request.DsConteudo;

                var result = await _conteudoRepository.UpdateConteudo(Entity);
                return new Response<ConteudoDto>(mapper.Map<ConteudoDto>(result), 200, "Conteudo atualizado com sucesso!");
            }
            catch (Exception e) {
                return new Response<ConteudoDto>(null, 500, "Não foi possível atualizar o conteudo.");
            }
        }
    }
}
