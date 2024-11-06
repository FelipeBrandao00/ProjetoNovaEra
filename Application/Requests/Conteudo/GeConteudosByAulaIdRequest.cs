using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests.Conteudo {
    public class GetConteudosByAulaIdRequest : PagedRequest {
        public int AulaId { get; set; }
        public GetConteudosByAulaIdRequest(int aulaId,int? pageNumber, int? pageSize) : base(pageNumber, pageSize) {
            AulaId = aulaId; 
        }
    }
}
