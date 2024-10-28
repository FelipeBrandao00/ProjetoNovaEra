using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests.Turma {
    public class GetTurmasRequest : PagedRequest {
        public string Nome { get; set; }
        public DateTime? DtInicial { get; set; }
        public DateTime? DtFinal { get; set; }
        public bool? IcFinalizado { get; set; }
        public int? CursoId { get; set; }
        public GetTurmasRequest(string nome, int? pageNumber, int? pageSize, DateTime? dtInicial, DateTime? dtFinal, bool? icFinalizado, int? cursoId ) : base(pageNumber, pageSize) {
            Nome = nome.Trim();
            DtInicial = dtInicial;
            DtFinal = dtFinal;
            IcFinalizado = icFinalizado;
            CursoId = cursoId;
        }
    }
}
