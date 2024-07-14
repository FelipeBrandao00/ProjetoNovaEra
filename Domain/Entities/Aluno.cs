using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities {
    public class Aluno {
        [Key, ForeignKey("Usuario")]
        [Required]
        public Guid cdAluno { get; set; }
        public DateTime dtNascimentoAluno { get; set; }

        public Usuario Usuario { get; set; }
        public virtual ICollection<Turma_Aluno> TurmaAluno { get; set; }
        public virtual ICollection<Frequencia> Frequencia { get; set; }

    }
}
