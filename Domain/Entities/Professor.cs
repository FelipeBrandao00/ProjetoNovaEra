using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities {
    public class Professor {
        [Key, ForeignKey("Usuario")]
        [Required]
        public Guid CdProfessor { get; set; }
        public bool IcHabilitadoTurma { get; set; }


        public required Usuario Usuario { get; set; }
        public virtual ICollection<Turma>? Turmas { get; set; }
    }
}
