namespace Domain.Entities {
    public class Cargo_Usuario {
        public required Guid CdUsuario { get; set; }
        public required int CdCargo { get; set; }


        public virtual Usuario Usuario { get; set; }
        public virtual Cargo Cargo { get; set; }
    }
}
