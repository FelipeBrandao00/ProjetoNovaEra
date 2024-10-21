using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests.TurmaAluno {
    public class DeleteTurmaAlunoRequest {
        public Guid CdAluno { get; set; }
        public int CdTurma { get; set; }
    }
}
