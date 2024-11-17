using Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Matricula
{
    public class MatriculaDto {
        public int CdMatricula { get; set; }
        public string NmUsuario { get; set; }
        public string? DsCpf { get; set; }
        public string DsEmail { get; set; }
        public int CdTurma { get; set; }
        public string? NmTurma { get; set; }
        public Genero? DsGenero { get; set; }
        public string StrDsGenero { get; init; }
        public DateTime? DtNascimento { get; set; }
        public string? DsTelefone { get; set; }
        public bool? IcAtendeFiltro { get; set; }

        public MatriculaDto()
        {
            
        }

        public MatriculaDto(int cdMatricula, string nmUsuario, string? dsCpf, string dsEmail, int cdTurma, string? nmTurma, Genero? dsGenero, DateTime? dtNascimento, string? dsTelefone) {
            CdMatricula = cdMatricula;
            NmUsuario = nmUsuario;
            DsCpf = dsCpf;
            DsEmail = dsEmail;
            CdTurma = cdTurma;
            NmTurma = nmTurma;
            DsGenero = dsGenero;
            StrDsGenero = dsGenero?.ToString();
            DtNascimento = dtNascimento;
            DsTelefone = dsTelefone;
        }
    }
}
