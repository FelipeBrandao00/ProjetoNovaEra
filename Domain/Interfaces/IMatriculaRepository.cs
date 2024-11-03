using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IMatriculaRepository
    {
        Task<List<Matricula>> GetMatriculasByTurmaId(int turmaId);
        Task<Matricula?> AddMatricula(Matricula matricula);
        Task<Matricula> DeleteMatricula(Matricula matricula);
        Task<Matricula> GetMatriculaById(int matriculaId);
    }
}
