using Application.DTOs.Certificado;
using Application.Requests.Certificado;
using Application.Responses;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces {
    public interface ICertificadoService {
        Task<Response<CertificadoDto>> AddCertificado(AddCertificadoRequest request);
        Task<Response<CertificadoDto>> DeleteCertificado(DeleteCertificadoRequest request);
        Task<Response<CertificadoDto?>> GetCertificadoById(GetCertificadoByIdRequest request);
    }
}
