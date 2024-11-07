using Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Matricula
{
    public class MatriculaDto
    {
        public int CdMatricula { get; set; }
        public required string NmUsuario { get; set; }   
        public string? DsCpf { get; set; }
        public int CdTurma { get; set; }
        public string? NmTurma { get; set; }
    }
}
