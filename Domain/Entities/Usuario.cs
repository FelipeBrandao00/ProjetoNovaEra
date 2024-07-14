using Domain.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities {
    public class Usuario {
        [Key]
        public Guid cdUsuario { get; set; }
        public string nmUsuario { get; set; }
        public string dsEmail { get; set; }
        public string dsSenha { get; set; }
        [MinLength(11)]
        [MaxLength(12)]
        public string dsCPF { get; set; }
        public Genero dsGenero { get; set; }


        public virtual Professor Professor { get; set; }
        public virtual Aluno Aluno { get; set; }
        public virtual ICollection<Cargo_Usuario> CargoUsuario { get; set; }
    }
}
