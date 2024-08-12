using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Turma
    {
        [Key]
        [Required]
        public int CdTurma { get; set; }
        public DateTime DtInicio { get; set; }
        public DateTime DtFim { get; set; }
        public Guid CdProfessor { get; set; }
        public int CdCurso { get; set; }
        public virtual required Usuario Professor { get; set; }
        public virtual Certificado? Certificado { get; set; }
        public virtual required Curso Curso { get; set; }

        public virtual ICollection<Aula>? Aulas { get; set; }
        public virtual ICollection<Turma_Aluno>? TurmaAluno { get; set; }
    }
}
