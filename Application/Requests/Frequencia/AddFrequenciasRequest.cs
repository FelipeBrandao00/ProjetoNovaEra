using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests.Frequencia {
    public class AddFrequenciasRequest {
        public int CdAula { get; set; }
        public int CdTurma { get; set; }
        public Guid[] CdAlunos { get; set; }
    }
}
