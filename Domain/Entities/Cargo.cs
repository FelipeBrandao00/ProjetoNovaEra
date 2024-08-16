using System.ComponentModel.DataAnnotations;

namespace Domain.Entities {
    public class Cargo {
        [Key]
        public int CdCargo { get; set; }
        public required string DsCargo { get; set; }

        public virtual ICollection<Cargo_Usuario>? CargoUsuario { get; set; }
        public virtual ICollection<Permissao_Cargos>? PermissaoCargos { get; set; }
    }
}
