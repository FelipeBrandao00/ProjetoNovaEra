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
        public int? IdadeInicial { get; set; }
        public int? IdadeFinal { get; set; }
        public bool? IcExAluno { get; set; }

        public GetMatriculasByTurmaIdRequest(int cdTurma, int? idadeInicial, int? idadeFinal, bool? icExAluno){
            IdadeInicial = idadeInicial;
            IdadeFinal = idadeFinal;
            IcExAluno = icExAluno;
            CdTurma = cdTurma;
        }
    }
}
