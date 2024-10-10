using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests.Turma {
    public class GetTurmasRequest : PagedRequest {
        public GetTurmasRequest(int? pageNumber, int? pageSize) : base(pageNumber, pageSize) {
        }
    }
}
