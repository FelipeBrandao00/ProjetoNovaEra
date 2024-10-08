using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests.Generos {
    public class GetGenerosRequest : PagedRequest {
        public GetGenerosRequest(int? pageNumber, int? pageSize) : base(pageNumber, pageSize) {
        }
    }
}
