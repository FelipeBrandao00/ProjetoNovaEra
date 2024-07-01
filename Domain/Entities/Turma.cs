using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Turma
    {
        [Key]
        [Required]
        public int cdTurma { get; set; }
        public DateTime dtInicio { get; set; }
        public DateTime dtFim { get; set; }
        public Guid cdProfessor { get; set; }
        public int cdCurso { get; set; }
        public virtual Professor Professor { get; set; }
        public virtual Certificado Certificado { get; set; }
        public virtual Curso Curso { get; set; }

        public virtual ICollection<Aula> Aulas { get; set; }
        public virtual ICollection<Turma_Aluno> TurmaAluno { get; set; }
    }
}
