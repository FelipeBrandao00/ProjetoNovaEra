using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Turma_Aluno
    {
        public Guid CdAluno { get; set; }
        public int CdTurma { get; set; }

        public virtual required Turma Turma { get; set; }
        public virtual required Usuario Aluno { get; set; }

    }
}
