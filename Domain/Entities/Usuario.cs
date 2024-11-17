using Domain.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities {
    public class Usuario {
        [Key]
        [Required]
        public Guid CdUsuario { get; set; }
        public required string NmUsuario { get; set; }
        public required string DsEmail { get; set; }
        public required string DsSenha { get; set; }
        [MinLength(11)]
        [MaxLength(12)]
        public required string DsCpf { get; set; }
        public Genero? DsGenero { get; set; }
        public DateTime? DtNascimento { get; set; }
        public bool? IcHabilitadoTurma { get; set; }
        public byte[]? DsFoto { get; set; }
        public string? DsTelefone { get; set; }
        
        public virtual ICollection<Cargo_Usuario>? CargoUsuario { get; set; }
        public virtual ICollection<Turma_Aluno>? TurmaAluno { get; set; }
        public virtual ICollection<Frequencia>? Frequencia { get; set; }
        public virtual ICollection<Turma>? Turmas { get; set; }

    }
}
