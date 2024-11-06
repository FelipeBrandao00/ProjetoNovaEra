using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces {
    public interface ICertificadoRepository {
        Task<Certificado> AddCertificado(Certificado certificado);
        Task<Certificado> DeleteCertificado(Certificado certificado);
        Task<Certificado?> GetCertificadoById(int certificadoId);
    }
}
