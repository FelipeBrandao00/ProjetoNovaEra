using Domain.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities {
    public class Usuario {
        [Key]
        public Guid CdUsuario { get; set; }
        public required string NmUsuario { get; set; }
        public required string DsEmail { get; set; }
        public required string DsSenha { get; set; }
        [MinLength(11)]
        [MaxLength(12)]
        public required string DsCpf { get; set; }
        public Genero DsGenero { get; set; }


        public virtual Professor? Professor { get; set; }
        public virtual Aluno? Aluno { get; set; }
        public virtual ICollection<Cargo_Usuario>? CargoUsuario { get; set; }
    }
}
