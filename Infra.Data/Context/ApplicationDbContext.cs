using Domain.Entities;
using Domain.Entities.Enums;
using Infra.Data.Encode;
using Microsoft.EntityFrameworkCore;

namespace API_NOVA_ERA.Database {
    public class ApplicationDbContext : DbContext {
        public ApplicationDbContext() { }
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Turma> Turmas { get; set; }
        public DbSet<Certificado> Certificados { get; set; }
        public DbSet<Aula> Aulas { get; set; }
        public DbSet<Conteudo> Conteudos { get; set; }
        public DbSet<Frequencia> Frequencias { get; set; }
        public DbSet<Turma_Aluno> Turma_Alunos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Cargo> Cargos { get; set; }
        public DbSet<Cargo_Usuario> Cargo_Usuarios { get; set; }
        public DbSet<Permissao> Permissoes { get; set; }
        public DbSet<Permissao_Cargos> Permissao_Cargos { get; set; }
        public DbSet<RequestChangePassword> RequestsChangePassword{ get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            modelBuilder.Entity<Turma_Aluno>().
                HasKey(x => new { CdTurma = x.CdTurma, CdAluno = x.CdAluno });
            
            modelBuilder.Entity<Permissao_Cargos>().
                HasKey(x => new { CdPermissao = x.CdPermissao, CdCargo = x.CdCargo });

            modelBuilder.Entity<Cargo_Usuario>()
                .HasKey(x => new { cdUsuario = x.CdUsuario, cdCargo = x.CdCargo });

            modelBuilder.Entity<Frequencia>().
                HasKey(x => new { cdAula = x.CdAula, cdTurma = x.CdTurma, cdAluno = x.CdAluno });


            #region Turma
            modelBuilder.Entity<Turma>()
               .HasOne(e => e.Certificado)
               .WithOne(e => e.Turma)
               .HasForeignKey<Certificado>(e => e.CdTurma)
               .IsRequired();


            modelBuilder.Entity<Turma>()
               .HasOne(t => t.Professor)
               .WithMany(p => p.Turmas)
               .HasForeignKey(t => t.CdProfessor)
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Turma>()
                .HasOne(t => t.Curso)
                .WithMany(c => c.Turmas)
                .HasForeignKey(t => t.CdCurso)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Turma>()
                .HasMany(t => t.Aulas)
                .WithOne(a => a.Turma)
                .HasForeignKey(a => a.CdTurma)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Turma>()
                .HasMany(t => t.TurmaAluno)
                .WithOne(ta => ta.Turma)
                .HasForeignKey(ta => ta.CdTurma)
                .OnDelete(DeleteBehavior.Cascade);
            
            modelBuilder.Entity<Turma_Aluno>()
                .HasOne(ta => ta.Usuario)
                .WithMany(tu => tu.TurmaAluno) 
                .HasForeignKey(ta => ta.CdAluno)
                .OnDelete(DeleteBehavior.Cascade); 
            #endregion

            #region Aula
            modelBuilder.Entity<Aula>()
                .HasKey(a => new { cdAula = a.CdAula, cdTurma = a.CdTurma });

            modelBuilder.Entity<Aula>()
                .HasOne(a => a.Turma)
                .WithMany(t => t.Aulas)
                .HasForeignKey(a => a.CdTurma)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Aula>()
               .HasMany(a => a.Conteudos)
               .WithOne(c => c.Aula)
               .HasForeignKey(c => new { cdAula = c.CdAula, cdTurma = c.CdTurma })
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Aula>()
                .HasMany(a => a.Frequencia)
                .WithOne(f => f.Aula)
                .HasForeignKey(f => new { cdAula = f.CdAula, cdTurma = f.CdTurma })
                .OnDelete(DeleteBehavior.Cascade);
            #endregion

            #region Frequencia
            modelBuilder.Entity<Frequencia>()
             .HasOne(f => f.Aula)
             .WithMany(a => a.Frequencia)
             .HasForeignKey(f => f.CdAula)
             .HasForeignKey(f => new { cdAula = f.CdAula, cdTurma = f.CdTurma })
             .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Frequencia>()
                .HasOne(f => f.Aluno)
                .WithMany(a => a.Frequencia)
                .HasForeignKey(f => f.CdAluno)
                .OnDelete(DeleteBehavior.Cascade);
            #endregion

            modelBuilder.Entity<Usuario>()
            .HasMany(uc => uc.CargoUsuario)
            .WithOne(u => u.Usuario)
            .HasForeignKey(uc => uc.CdUsuario)
            .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Cargo>()
           .HasMany(uc => uc.CargoUsuario)
           .WithOne(c => c.Cargo)
           .HasForeignKey(uc => uc.CdCargo)
           .OnDelete(DeleteBehavior.Cascade);
            
            modelBuilder.Entity<Cargo>()
                .HasMany(uc => uc.PermissaoCargos)
                .WithOne(c => c.Cargo)
                .HasForeignKey(uc => uc.CdCargo)
                .OnDelete(DeleteBehavior.Cascade);
            
            modelBuilder.Entity<Permissao>()
                .HasMany(uc => uc.PermissaoCargos)
                .WithOne(c => c.Permissao)
                .HasForeignKey(uc => uc.CdPermissao)
                .OnDelete(DeleteBehavior.Cascade);
            
            modelBuilder.Entity<Turma>()
                .HasOne(t => t.Professor)
                .WithMany(p => p.Turmas)
                .HasForeignKey(t => t.CdProfessor)
                .OnDelete(DeleteBehavior.NoAction);
            
            
            modelBuilder.Entity<Cargo>().HasData(
                new Cargo { CdCargo = 1, DsCargo = "Administrador" },
                new Cargo { CdCargo = 2, DsCargo = "Professor" },
                new Cargo { CdCargo = 3, DsCargo = "Aluno" },
                new Cargo { CdCargo = 4, DsCargo = "Master" }
            );
            
            modelBuilder.Entity<Usuario>().HasData(
                new Usuario
                {
                    CdUsuario = new Guid("A21FA379-2B28-447F-AD88-87EF9DF45DF7"),
                    NmUsuario = "Master",
                    DsEmail = "master@gmail.com",
                    DsSenha = Password.EncodePassword("1234"),
                    DsCpf = "00000000000"
                }
            );

            modelBuilder.Entity<Cargo_Usuario>().HasData(
                new Cargo_Usuario { CdUsuario = new Guid("A21FA379-2B28-447F-AD88-87EF9DF45DF7"), CdCargo = 4 },
                new Cargo_Usuario { CdUsuario = new Guid("A21FA379-2B28-447F-AD88-87EF9DF45DF7"), CdCargo = 1 }
            );
            
        }
    }
}
