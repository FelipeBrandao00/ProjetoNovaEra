using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Turma_Aluno
    {
        [ForeignKey(nameof(Usuario))]
        public Guid CdAluno { get; set; }
        public int CdTurma { get; set; }
        public bool? IcAprovado { get; set; }

        public virtual required Turma Turma { get; set; }
        public virtual required Usuario Usuario { get; set; }

    }
}
