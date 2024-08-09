namespace Domain.Entities {
    public class Cargo_Usuario {
        public Guid CdUsuario { get; set; }
        public int CdCargo { get; set; }


        public virtual required Usuario Usuario { get; set; }
        public virtual required Cargo Cargo { get; set; }
    }
}
