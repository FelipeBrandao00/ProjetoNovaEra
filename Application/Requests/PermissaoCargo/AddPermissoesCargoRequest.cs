using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests.PermissaoCargo {
    public class AddPermissoesCargoRequest {
        public int CdCargo { get; set; }
        public int[] CdPermissoes { get; set; }
    }
}
