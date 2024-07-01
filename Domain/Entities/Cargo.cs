using System.ComponentModel.DataAnnotations;

namespace Domain.Entities {
    public class Cargo {
        [Key]
        public int cdCargo { get; set; }
        public string dsCargo { get; set; }

        public virtual ICollection<Cargo_Usuario> CargoUsuario { get; set; }
    }
}
