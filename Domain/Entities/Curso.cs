using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Curso
    {
        [Key]
        [Required]
        public int CdCurso { get; set; }
        public required string NmCurso { get; set; }
        public required string DsCurso { get; set; }
        public DateTime DtCriacao { get; set; }
        public DateTime? DtFinalizacao { get; set; }
        public virtual ICollection<Turma>? Turmas { get; set; }
    }
}
