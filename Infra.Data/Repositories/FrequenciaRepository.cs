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
    public class FrequenciaRepository(ApplicationDbContext _context) : IFrequenciaRepository {
        public async Task<Frequencia> AddFrequencia(Frequencia frequencia) {
           _context.Frequencias.Add(frequencia);
            await _context.SaveChangesAsync();
            return frequencia;
        }

        public async Task<List<Frequencia>> AddFrequencias(int cdAula, List<Frequencia> frequencias) {
            _context.Frequencias.RemoveRange(_context.Frequencias.Where(x => x.CdAula == cdAula));

            foreach (var frequencia in frequencias) {
                _context.Frequencias.Add(frequencia);
            }
            await _context.SaveChangesAsync();
            return await GetFrequenciasByAulaId(cdAula);
        }

        public async Task<Frequencia> DeleteFrequencia(Frequencia frequencia) {
            _context.Frequencias.Remove(frequencia);
            await _context.SaveChangesAsync();
            return frequencia;
        }

        public async Task<List<Frequencia>> GetFrequenciasByAulaId(int aulaId) {
            return await _context.Frequencias.Where(x => x.CdAula == aulaId).ToListAsync();
        }
    }
}
