using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Turma {
    public class TurmaDto {
        public int CdTurma { get; set; }
        public required string NmTurma { get; set; }
        public string? DsTurma { get; set; }
        public DateTime DtInicio { get; set; }
        public DateTime? DtFim { get; set; }
        public Guid CdProfessor { get; set; }
        public int CdCurso { get; set; }
        public bool IcAbertaMatricula { get; set; }
    }
}
