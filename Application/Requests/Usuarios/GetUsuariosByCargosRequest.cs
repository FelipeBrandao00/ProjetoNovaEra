using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests.Usuarios {
    public class GetUsuariosByCargosRequest : PagedRequest {
        public int[] CdCargos { get; set; }

        public GetUsuariosByCargosRequest(int[] cdCargos,int? pageNumber, int? pageSize) : base(pageNumber, pageSize) {
            CdCargos = cdCargos;
        }

    }
}
