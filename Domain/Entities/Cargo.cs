using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities {
    public class Cargo {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CdCargo { get; set; }
        public required string DsCargo { get; set; }

        public virtual ICollection<Cargo_Usuario>? CargoUsuario { get; set; }
        public virtual ICollection<Permissao_Cargos>? PermissaoCargos { get; set; }
    }
}
