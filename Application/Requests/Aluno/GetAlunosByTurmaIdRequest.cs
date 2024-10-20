using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests.Aluno {
    public class GetAlunosByTurmaIdRequest : PagedRequest {
        public int TurmaId { get; set; }
        public GetAlunosByTurmaIdRequest(int turmaId, int? pageNumber, int? pageSize) : base(pageNumber, pageSize) {
            TurmaId = turmaId;
        }
    }
}
