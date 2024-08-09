using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Aula
    {
        [Key]
        [Required]
        public int CdAula { get; set; }
        public DateTime DtAula { get; set; }

        public int CdTurma { get; set; }
        public virtual required Turma Turma { get; set; }

        public virtual ICollection<Conteudo>? Conteudos { get; set; }

        public virtual ICollection<Frequencia>? Frequencia { get; set; }
    }
}
