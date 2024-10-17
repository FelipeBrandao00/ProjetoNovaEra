using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Aula
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CdAula { get; set; }
        public DateTime DtAula { get; set; }
        public required string NmAula { get; set; }
        public string? DsAula { get; set; }

        public int CdTurma { get; set; }
        public virtual required Turma Turma { get; set; }

        public virtual ICollection<Conteudo>? Conteudos { get; set; }

        public virtual ICollection<Frequencia>? Frequencia { get; set; }
    }
}
