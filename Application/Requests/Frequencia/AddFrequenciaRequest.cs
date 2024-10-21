using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests.Frequencia {
    public class AddFrequenciaRequest {
        public Guid CdAluno { get; set; }
        public int CdTurma { get; set; }
        public int CdAula { get; set; }
    }
}
