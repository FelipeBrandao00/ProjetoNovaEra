using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests.CargoUsuario {
    public class AddCargosUsuarioRequest {
        public Guid CdUsuario { get; set; }
        public int[] CdCargos { get; set; }
    }
}
