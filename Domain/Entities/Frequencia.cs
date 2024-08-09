using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Frequencia
    {
        public Guid CdAluno { get; set; }
        public int CdTurma { get; set; }
        public int CdAula { get; set; }


        public virtual required Aula Aula { get; set; }
        public virtual required Aluno Aluno { get; set; }
    }
}
