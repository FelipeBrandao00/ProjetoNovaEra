using Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Certificado {
    public class CertificadoDto {
        public int CdCertificado { get; set; }
        public required string NmArquivo { get; set; }
        public string DsExtensao { get; set; }
        public byte[]? Arquivo { get; set; }
    }
}
