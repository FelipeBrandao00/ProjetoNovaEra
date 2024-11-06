using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests.Matricula
{
    public class GetMatriculasByTurmaIdRequest
    {
        public int CdTurma { get; set; }
        public GetMatriculasByTurmaIdRequest(int cdTurma)
        {
            CdTurma = cdTurma;
        }
    }
}
