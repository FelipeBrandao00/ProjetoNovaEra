using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests.Frequencia {
    public class GetFrequenciasByAulaIdRequest : PagedRequest {
        public GetFrequenciasByAulaIdRequest(int cdAula,int? pageNumber, int? pageSize) : base(pageNumber, pageSize) {
            CdAula = cdAula;
        }

        public int CdAula { get; set; }
    }
}
