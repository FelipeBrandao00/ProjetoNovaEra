using Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Matricula
{
    public class MatriculaDto(int cdMatricula, string nmUsuario, string? dsCpf, string dsEmail, int cdTurma, string? nmTurma, Genero? dsGenero, DateTime? dtNascimento, string? dsTelefone)
    {
        public int CdMatricula { get; set; } = cdMatricula;
        public string NmUsuario { get; set; } = nmUsuario;
        public string? DsCpf { get; set; } = dsCpf;
        public string DsEmail { get; set; } = dsEmail;
        public int CdTurma { get; set; } = cdTurma;
        public string? NmTurma { get; set; } = nmTurma;
        public Genero? DsGenero { get; set; } = dsGenero;
        public string StrDsGenero { get; init; } = dsGenero?.ToString();
        public DateTime? DtNascimento { get; set; } = dtNascimento;
        public string? DsTelefone { get; set; } = dsTelefone;
    }
}
