using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities {
    public class Professor {
        [Key, ForeignKey("Usuario")]
        [Required]
        public Guid cdProfessor { get; set; }
        public bool icHabilitadoTurma { get; set; }


        public Usuario Usuario { get; set; }
        public ICollection<Turma> Turmas { get; set; }
    }
}
