using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests.Aula {
    public class AddAulaRequest {
        public DateTime DtAula { get; set; }
        public string NmAula { get; set; }
        public string? DsAula { get; set; }
        public int CdTurma { get; set; }
    }
}
