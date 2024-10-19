﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces {
    public interface IAulaRepository {
        Task<Aula>AddAula(Aula aula);
        Task<Aula> DeleteAula(Aula aula);
        Task<Aula> UpdateAula(Aula aula);
        Task<List<Aula>> GetAulasByTurmaId(int turmaId);
        Task<Aula?> GetAulaById(int aulaId);
    }
}