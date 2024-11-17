using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.Enums;

namespace Domain.Entities
{
    public class Matricula
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CdMatricula { get; set; }
        public DateTime DtMatricula { get; set; }
        public required string NmUsuario { get; set; }
        public required string DsEmail { get; set; }
        [MinLength(11)]
        [MaxLength(12)]
        public required string DsCpf { get; set; }
        public Genero? DsGenero { get; set; }
        public DateTime DtNascimento { get; set; }
        public string? DsTelefone { get; set; }
        public int CdTurma { get; set; }
        public virtual required Turma Turma { get; set; }
    }
}
