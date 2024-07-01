using Domain.Entities.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities {
    public class Professor {
        [Key, ForeignKey("Usuario")]
        [Required]
        public Guid cdProfessor { get; set; }
        [Required]
        [MaxLength(100)]
        public string nmProfessor { get; set; }
        [MinLength(11)]
        [MaxLength(12)]
        public string dsCPFProfessor { get; set; }
        public bool icHabilitadoTurma { get; set; }
        public string dsEmail { get; set; }
        public Genero dsGenero { get; set; }


        public Usuario Usuario { get; set; }
        public ICollection<Turma> Turmas { get; set; }
    }
}
