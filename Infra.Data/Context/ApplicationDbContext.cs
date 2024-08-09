using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace API_NOVA_ERA.Database {
    public class ApplicationDbContext : DbContext {
        public ApplicationDbContext() { }
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Professor> Professores { get; set; }
        public DbSet<Turma> Turmas { get; set; }
        public DbSet<Certificado> Certificados { get; set; }
        public DbSet<Aula> Aulas { get; set; }
        public DbSet<Conteudo> Conteudos { get; set; }
        public DbSet<Frequencia> Frequencias { get; set; }
        public DbSet<Turma_Aluno> Turma_Alunos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Cargo> Cargos { get; set; }
        public DbSet<Cargo_Usuario> Cargo_Usuarios { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            modelBuilder.Entity<Turma_Aluno>().
                HasKey(x => new { cdTurma = x.CdTurma, cdAluno = x.CdAluno });

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
               .HasForeignKey(t => t.cdProfessor)
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Turma>()
                .HasOne(t => t.Curso)
                .WithMany(c => c.Turmas)
                .HasForeignKey(t => t.cdCurso)
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

            #region Aluno
            modelBuilder.Entity<Aluno>()
               .HasMany(a => a.TurmaAluno)
               .WithOne(ta => ta.Aluno)
               .HasForeignKey(ta => ta.CdAluno)
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Aluno>()
                .HasMany(a => a.Frequencia)
                .WithOne(f => f.Aluno)
                .HasForeignKey(f => f.CdAluno)
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

            modelBuilder.Entity<Professor>()
                .HasOne(p => p.Usuario)
                .WithOne(u => u.Professor)
                .HasForeignKey<Professor>(p => p.CdProfessor)
        .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Aluno>()
                .HasOne(a => a.Usuario)
                .WithOne(u => u.Aluno)
                .HasForeignKey<Aluno>(a => a.CdAluno)
        .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
