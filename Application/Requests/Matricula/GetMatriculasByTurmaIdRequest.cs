using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests.Matricula
{
    public class GetMatriculasByTurmaIdRequest : PagedRequest
    {
        public int CdTurma { get; set; }
        public GetMatriculasByTurmaIdRequest(int? pageNumber, int? pageSize, int cdTurma) : base(pageNumber, pageSize)
        {
            CdTurma = cdTurma;
        }
    }
}
