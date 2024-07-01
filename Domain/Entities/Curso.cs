using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Curso
    {
        [Key]
        [Required]
        public int cdCurso { get; set; }
        public string nmCurso { get; set; }
        public string dsCurso { get; set; }
        public DateTime dtCriacao { get; set; }
        public DateTime dtFinalizacao { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal qtHoras { get; set; }

        public ICollection<Turma> Turmas { get; set; }
    }
}
