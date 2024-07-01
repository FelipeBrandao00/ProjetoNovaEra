using Domain.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities 
    {
    public class Conteudo
    {
        [Key]
        [Required]
        public int cdConteudo { get; set; }
        public string dsConteudo { get; set; }
        public string nmArquivo { get; set; }
        public Extensao dsExtencao { get; set; }

        [Required]
        public int cdAula { get; set; }
        [Required]
        public int cdTurma { get; set; }
        public Aula Aula { get; set; }

    }
}
