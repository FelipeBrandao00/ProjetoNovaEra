using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests.Turma {
    public class AddTurmaRequest {
        public string? DsTurma { get; set; }
        public DateTime DtInicio { get; set; }
        public Guid CdProfessor { get; set; }
        public int CdCurso { get; set; }
    }
}
