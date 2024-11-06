using API_NOVA_ERA.Database;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Data.Repositories {
    public class ConteudoRepository(ApplicationDbContext _context) : IConteudoRepository {
        public async Task<Conteudo> AddConteudo(Conteudo conteudo) {
            _context.Conteudos.Add(conteudo);
            await _context.SaveChangesAsync();
            return conteudo;
        }

        public async Task<Conteudo> DeleteConteudo(Conteudo conteudo) {
            _context.Conteudos.Remove(conteudo);
            await _context.SaveChangesAsync();
            return conteudo;
        }

        public async Task<List<Conteudo>?> GetConteudosByAulaId(int aulaId) {
            return await _context.Conteudos.Where(x => x.CdAula == aulaId).ToListAsync();
        }

        public async Task<Conteudo?> GetConteudoById(int conteudoId) {
            return await _context.Conteudos.Where(x => x.CdConteudo == conteudoId).FirstOrDefaultAsync();
        }

        public async Task<Conteudo> UpdateConteudo(Conteudo conteudo) {
            _context.Conteudos.Update(conteudo);
            await _context.SaveChangesAsync();
            return conteudo;
        }
    }
}
