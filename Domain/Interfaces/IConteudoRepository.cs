using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces {
    public interface IConteudoRepository {
        Task<Conteudo> AddConteudo(Conteudo conteudo);
        Task<Conteudo> DeleteConteudo(Conteudo conteudo);
        Task<Conteudo> UpdateConteudo(Conteudo conteudo);
        Task<Conteudo?> GetConteudoById(int conteudoId);
        Task<List<Conteudo>> GetConteudosByAulaId(int aulaId);
    }
}
