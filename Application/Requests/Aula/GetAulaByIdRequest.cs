using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests.Aula {
    public class GetAulaByIdRequest {
        public int CdAula { get; set; }

        public GetAulaByIdRequest(int cdAula)
        {
            CdAula = cdAula;
        }
    }
}
