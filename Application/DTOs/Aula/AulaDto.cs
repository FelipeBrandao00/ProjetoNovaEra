﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Aula {
    public record AulaDto(int CdAula, DateTime DtAula, string? DsAula, string NmAula);
}