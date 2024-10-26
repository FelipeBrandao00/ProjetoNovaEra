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
    public class CertificadoRepository(ApplicationDbContext _context) : ICertificadoRepository {
        public async Task<Certificado> AddCertificado(Certificado certificado) {
            _context.Certificados.Add(certificado);
            await _context.SaveChangesAsync();
            return certificado;
        }

        public async Task<Certificado> DeleteCertificado(Certificado certificado) {
            _context.Certificados.Add(certificado);
            await _context.SaveChangesAsync();
            return certificado;
        }

        public async Task<Certificado?> GetCertificadoById(int certificadoId) {
            return await _context.Certificados.Where(x => x.CdCertificado == certificadoId).FirstOrDefaultAsync();
        }
    }
}
