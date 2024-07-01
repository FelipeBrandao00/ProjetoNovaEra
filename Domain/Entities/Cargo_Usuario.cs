namespace Domain.Entities {
    public class Cargo_Usuario {
        public Guid cdUsuario { get; set; }
        public int cdCargo { get; set; }


        public virtual Usuario Usuario { get; set; }
        public virtual Cargo Cargo { get; set; }
    }
}
