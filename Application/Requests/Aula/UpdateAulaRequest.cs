using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests.Aula {
    public class UpdateAulaRequest {
        public int CdAula { get; set; }
        public DateTime DtAula { get; set; }
        public string? DsAula { get; set; }
    }
}
