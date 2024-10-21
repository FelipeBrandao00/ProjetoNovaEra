using Domain.Entities.Enums;
using Microsoft.AspNetCore.Http;

namespace Application.Requests.Conteudo {
    public class AddConteudoRequest {
        public required string DsConteudo { get; set; }
        public required IFormFile Arquivo { get; set; }
        public int CdAula { get; set; }
        public int CdTurma { get; set; }
    }
}
