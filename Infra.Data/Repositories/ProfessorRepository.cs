using API_NOVA_ERA.Database;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Repositories;

public class ProfessorRepository(ApplicationDbContext _context) : IProfessorRepository
{
    public async Task<List<Usuario?>> GetProfessores(string nmProfessor = null, bool? icHabilitadoTurma = null)
    {
        var professores =
            (from u in _context.Usuarios
                join cu in _context.Cargo_Usuarios on u.CdUsuario equals cu.CdUsuario
                join c in _context.Cargos on cu.CdCargo equals c.CdCargo
                where c.DsCargo == "Professor"
                select u);

        if (!string.IsNullOrEmpty(nmProfessor))
        {
            professores = professores.Where( x=>  x.NmUsuario.Contains(nmProfessor));
        }
        
        if (icHabilitadoTurma != null)
        {
            professores = professores.Where( x=>  x.IcHabilitadoTurma == icHabilitadoTurma);
        }

        return await professores.ToListAsync();
    }

    public async Task<Usuario> SetProfessorHabilitadoTurma(Guid cdProfessor)
    {
        var professor = _context.Usuarios.Find(cdProfessor);

        if (professor == null) return null;

        professor.IcHabilitadoTurma = true;
        await _context.SaveChangesAsync();
        return professor;
    }

    public async Task<Usuario> SetProfessorDesabilitadoTurma(Guid cdProfessor)
    {
        var professor = _context.Usuarios.Find(cdProfessor);

        if (professor == null) return null;

        professor.IcHabilitadoTurma = false;
        await _context.SaveChangesAsync();
        return professor;
    }
}