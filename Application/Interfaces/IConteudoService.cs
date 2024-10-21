using Application.DTOs.Conteudo;
using Application.Requests.Conteudo;
using Application.Responses;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces {
    public interface IConteudoService {
        Task<Response<ConteudoDto>> AddConteudo(AddConteudoRequest request);
        Task<Response<ConteudoDto>> DeleteConteudo(DeleteConteudoRequest request);
        Task<Response<ConteudoDto>> UpdateConteudo(UpdateConteudoRequest request);
        Task<Response<ConteudoDto>?> GetConteudoById(GetConteudoByIdRequest request);
        Task<PagedResponse<List<ConteudoDto>?>> GetConteudosByAulaId(GetConteudosByAulaIdRequest request);
    }
}
