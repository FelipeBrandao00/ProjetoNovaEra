using Application.DTOs.Certificado;
using Application.DTOs.Conteudo;
using Application.Interfaces;
using Application.Requests.Certificado;
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
    public class CertificadoService(ICertificadoRepository _certificadoRepository, IMapper mapper, IFileService fileService) : ICertificadoService {
        public async Task<Response<CertificadoDto>> AddCertificado(AddCertificadoRequest request) {
            try {
                var Entity = mapper.Map<Certificado>(request);
                Entity.NmArquivo = Path.GetFileNameWithoutExtension(request.Arquivo.FileName);
                Entity.DsExtensao = Path.GetExtension(request.Arquivo.FileName);


                var path = $"Certificados/Turma{request.CdTurma}/";
                await fileService.SaveFileAsync(request.Arquivo, path);

                var retorno = await _certificadoRepository.AddCertificado(Entity);
                return new Response<CertificadoDto>(
                    mapper.Map<CertificadoDto>(retorno),
                    201,
                    "Certificado criado com sucesso!");
            }
            catch (Exception e) {
                return new Response<CertificadoDto>(
                    null,
                    500,
                    "Não foi possível criar o certificado");
            }
        }

        public async Task<Response<CertificadoDto>> DeleteCertificado(DeleteCertificadoRequest request) {
            try {
                var Entity = await _certificadoRepository.GetCertificadoById(request.CdCertificado);

                if (Entity == null) return new Response<CertificadoDto>(null, 500, "Não foi possível encontrar o certificado");
                var path = $"Certificados/Turma{Entity.CdTurma}/";
                var fileName = $"{Entity.NmArquivo}{Entity.DsExtensao}";

                fileService.DeleteFile(path, fileName);

                var retorno = await _certificadoRepository.DeleteCertificado(Entity);
                return new Response<CertificadoDto>(
                    mapper.Map<CertificadoDto>(retorno),
                    201,
                    "Certificado deletado com sucesso!");
            }
            catch (Exception e) {
                return new Response<CertificadoDto>(
                    null,
                    500,
                    "Não foi possível deletar o certificado");
            }
        }

        public async Task<Response<CertificadoDto?>> GetCertificadoById(GetCertificadoByIdRequest request) {
            try {
                var entity = await _certificadoRepository.GetCertificadoById(request.CdCertificado);

                if (entity == null) return new Response<CertificadoDto?>(null, 500, "Não foi possível encontrar o certificado");

                var result = mapper.Map<CertificadoDto>(entity);
                var path = $"Certificados/Turma{entity.CdTurma}/";
                var fileName = $"{entity.NmArquivo}{entity.DsExtensao}";

                var file = await fileService.GetFileAsync(path, fileName);

                result.Arquivo = file;

                return new Response<CertificadoDto?>(result, 200, "Certificado encontrado!");
            }
            catch (Exception e) {
                return new Response<CertificadoDto?>(null, 500, "Algo deu errado tentando buscar o certificado.");
            }
        }
    }
}
