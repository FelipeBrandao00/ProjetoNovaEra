using Domain.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities 
    {
    public class Certificado
    {
        [Key]
        [Required]
        public int CdCertificado { get; set; }
        public required string NmArquivo { get; set; }
        public Extensao DsExtensao { get; set; }

        [Required]
        public int CdTurma { get; set; }
        public virtual required Turma Turma { get; set; }
    }
}
