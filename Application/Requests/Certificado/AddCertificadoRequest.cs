using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests.Certificado {
    public class AddCertificadoRequest {
        public int CdTurma { get; set; }
        public required IFormFile Arquivo { get; set; }
    }
}
