using Domain.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities 
    {
    public class Certificado
    {
        [Key]
        [Required]
        public int cdCertificado { get; set; }
        public string nmArquivo { get; set; }
        public Extensao dsExtensao { get; set; }

        [Required]
        public int cdTurma { get; set; }
        public Turma Turma { get; set; }
    }
}
