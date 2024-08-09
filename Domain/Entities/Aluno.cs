using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities {
    public class Aluno {
        [Key, ForeignKey("Usuario")]
        [Required]
        public Guid CdAluno { get; set; }
        public DateTime DtNascimentoAluno { get; set; }

        public required Usuario Usuario { get; set; }
        public virtual ICollection<Turma_Aluno>? TurmaAluno { get; set; }
        public virtual ICollection<Frequencia>? Frequencia { get; set; }

    }
}
