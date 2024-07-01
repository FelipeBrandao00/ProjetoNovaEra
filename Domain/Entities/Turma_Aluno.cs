using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Turma_Aluno
    {
        public Guid cdAluno { get; set; }
        public int cdTurma { get; set; }

        public virtual Turma Turma { get; set; }
        public virtual Aluno Aluno { get; set; }

    }
}
