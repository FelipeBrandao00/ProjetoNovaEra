using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests.Aula {
    public class GetAulasByTurmaIdRequest : PagedRequest {
        public int TurmaId { get; set; }
        public bool? IcChamada { get; set; }
        public GetAulasByTurmaIdRequest(int turmaId, bool? icChamada, int? pageNumber, int? pageSize) : base(pageNumber, pageSize) {
            TurmaId = turmaId;
            IcChamada = icChamada;
        }
    }
}
