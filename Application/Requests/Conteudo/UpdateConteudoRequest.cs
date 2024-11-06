using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests.Conteudo {
    public class UpdateConteudoRequest {
        public int CdConteudo { get; set; }
        public required string DsConteudo { get; set; }
    }
}
