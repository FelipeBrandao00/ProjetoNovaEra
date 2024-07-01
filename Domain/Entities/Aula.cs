using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Aula
    {
        [Key]
        [Required]
        public int cdAula { get; set; }
        public DateTime dtAula { get; set; }

        public int cdTurma { get; set; }
        public virtual Turma Turma { get; set; }

        public virtual ICollection<Conteudo> Conteudos { get; set; }

        public virtual ICollection<Frequencia> Frequencia { get; set; }
    }
}
