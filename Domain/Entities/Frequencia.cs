using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Frequencia
    {
        public Guid cdAluno { get; set; }
        public int cdTurma { get; set; }
        public int cdAula { get; set; }


        public virtual Aula Aula { get; set; }
        public virtual Aluno Aluno { get; set; }
    }
}
