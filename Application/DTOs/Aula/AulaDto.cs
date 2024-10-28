using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Aula {
    public class AulaDto {
        public int CdAula { get; set; }
        public DateTime DtAula { get; set; }
        public string? DsAula { get; set; }
        public string NmAula { get; set; }
        public bool IsChamada { get; set; }
        public bool IsArquivo { get; set; }
        public int? QtPresencas { get; set; }
        public int? QtArquivos { get; set; }
    };
}
