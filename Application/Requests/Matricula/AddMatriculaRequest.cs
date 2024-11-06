using Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests.Matricula
{
    public class AddMatriculaRequest
    {
        public required string NmUsuario { get; set; }
        public required string DsEmail { get; set; }
        public string? DsCpf { get; set; }
        public Genero? DsGenero { get; set; }
        public DateTime? DtNascimento { get; set; }
        public string? DsTelefone { get; set; }
        public int CdTurma { get; set; }
    }
}
