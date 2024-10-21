using Domain.Entities.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities 
    {
    public class Conteudo
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CdConteudo { get; set; }
        public required string DsConteudo { get; set; }
        public required string NmArquivo { get; set; }
        public string DsExtensao { get; set; }

        [Required]
        public virtual int CdAula { get; set; }
        [Required]
        public virtual int CdTurma { get; set; }
        public virtual required Aula Aula { get; set; }

    }
}
