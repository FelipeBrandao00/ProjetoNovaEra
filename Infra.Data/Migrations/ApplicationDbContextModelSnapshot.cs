﻿// <auto-generated />
using System;
using API_NOVA_ERA.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infra.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.Aula", b =>
                {
                    b.Property<int>("CdAula")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CdAula"));

                    b.Property<int>("CdTurma")
                        .HasColumnType("int");

                    b.Property<string>("DsAula")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DtAula")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsChamada")
                        .HasColumnType("bit");

                    b.Property<string>("NmAula")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CdAula", "CdTurma");

                    b.HasIndex("CdTurma");

                    b.ToTable("Aulas");
                });

            modelBuilder.Entity("Domain.Entities.Cargo", b =>
                {
                    b.Property<int>("CdCargo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CdCargo"));

                    b.Property<string>("DsCargo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CdCargo");

                    b.ToTable("Cargos");

                    b.HasData(
                        new
                        {
                            CdCargo = 1,
                            DsCargo = "Administrador"
                        },
                        new
                        {
                            CdCargo = 2,
                            DsCargo = "Professor"
                        },
                        new
                        {
                            CdCargo = 3,
                            DsCargo = "Aluno"
                        },
                        new
                        {
                            CdCargo = 4,
                            DsCargo = "Master"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Cargo_Usuario", b =>
                {
                    b.Property<Guid>("CdUsuario")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CdCargo")
                        .HasColumnType("int");

                    b.HasKey("CdUsuario", "CdCargo");

                    b.HasIndex("CdCargo");

                    b.ToTable("Cargo_Usuarios");

                    b.HasData(
                        new
                        {
                            CdUsuario = new Guid("a21fa379-2b28-447f-ad88-87ef9df45df7"),
                            CdCargo = 4
                        },
                        new
                        {
                            CdUsuario = new Guid("a21fa379-2b28-447f-ad88-87ef9df45df7"),
                            CdCargo = 1
                        });
                });

            modelBuilder.Entity("Domain.Entities.Certificado", b =>
                {
                    b.Property<int>("CdCertificado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CdCertificado"));

                    b.Property<int>("CdTurma")
                        .HasColumnType("int");

                    b.Property<string>("DsExtensao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NmArquivo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CdCertificado");

                    b.HasIndex("CdTurma")
                        .IsUnique();

                    b.ToTable("Certificados");
                });

            modelBuilder.Entity("Domain.Entities.Conteudo", b =>
                {
                    b.Property<int>("CdConteudo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CdConteudo"));

                    b.Property<int>("CdAula")
                        .HasColumnType("int");

                    b.Property<int>("CdTurma")
                        .HasColumnType("int");

                    b.Property<string>("DsConteudo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DsExtensao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NmArquivo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CdConteudo");

                    b.HasIndex("CdAula", "CdTurma");

                    b.ToTable("Conteudos");
                });

            modelBuilder.Entity("Domain.Entities.Curso", b =>
                {
                    b.Property<int>("CdCurso")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CdCurso"));

                    b.Property<string>("DsCurso")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DtCriacao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DtFinalizacao")
                        .HasColumnType("datetime2");

                    b.Property<string>("NmCurso")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CdCurso");

                    b.ToTable("Cursos");
                });

            modelBuilder.Entity("Domain.Entities.Frequencia", b =>
                {
                    b.Property<int>("CdAula")
                        .HasColumnType("int");

                    b.Property<int>("CdTurma")
                        .HasColumnType("int");

                    b.Property<Guid>("CdAluno")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("CdAula", "CdTurma", "CdAluno");

                    b.HasIndex("CdAluno");

                    b.ToTable("Frequencias");
                });

            modelBuilder.Entity("Domain.Entities.Matricula", b =>
                {
                    b.Property<int>("CdMatricula")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CdMatricula"));

                    b.Property<int>("CdTurma")
                        .HasColumnType("int");

                    b.Property<string>("DsCpf")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.Property<string>("DsEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DsGenero")
                        .HasColumnType("int");

                    b.Property<string>("DsTelefone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DtMatricula")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DtNascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("NmUsuario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CdMatricula");

                    b.HasIndex("CdTurma");

                    b.ToTable("Matriculas");
                });

            modelBuilder.Entity("Domain.Entities.Permissao", b =>
                {
                    b.Property<int>("CdPermissao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CdPermissao"));

                    b.Property<string>("NmPermissao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CdPermissao");

                    b.ToTable("Permissoes");

                    b.HasData(
                        new
                        {
                            CdPermissao = 1,
                            NmPermissao = "Gerenciar turmas"
                        },
                        new
                        {
                            CdPermissao = 2,
                            NmPermissao = "Gerenciar alunos"
                        },
                        new
                        {
                            CdPermissao = 3,
                            NmPermissao = "Gerenciar professores"
                        },
                        new
                        {
                            CdPermissao = 4,
                            NmPermissao = "Gerenciar cursos"
                        },
                        new
                        {
                            CdPermissao = 5,
                            NmPermissao = "Gerenciar matriculas"
                        },
                        new
                        {
                            CdPermissao = 6,
                            NmPermissao = "Gerenciar chamadas"
                        },
                        new
                        {
                            CdPermissao = 7,
                            NmPermissao = "Gerenciar usuários"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Permissao_Cargos", b =>
                {
                    b.Property<int>("CdPermissao")
                        .HasColumnType("int");

                    b.Property<int>("CdCargo")
                        .HasColumnType("int");

                    b.HasKey("CdPermissao", "CdCargo");

                    b.HasIndex("CdCargo");

                    b.ToTable("Permissao_Cargos");

                    b.HasData(
                        new
                        {
                            CdPermissao = 1,
                            CdCargo = 4
                        },
                        new
                        {
                            CdPermissao = 2,
                            CdCargo = 4
                        },
                        new
                        {
                            CdPermissao = 3,
                            CdCargo = 4
                        },
                        new
                        {
                            CdPermissao = 4,
                            CdCargo = 4
                        },
                        new
                        {
                            CdPermissao = 5,
                            CdCargo = 4
                        },
                        new
                        {
                            CdPermissao = 6,
                            CdCargo = 4
                        },
                        new
                        {
                            CdPermissao = 7,
                            CdCargo = 4
                        },
                        new
                        {
                            CdPermissao = 1,
                            CdCargo = 1
                        },
                        new
                        {
                            CdPermissao = 2,
                            CdCargo = 1
                        },
                        new
                        {
                            CdPermissao = 3,
                            CdCargo = 1
                        },
                        new
                        {
                            CdPermissao = 4,
                            CdCargo = 1
                        },
                        new
                        {
                            CdPermissao = 5,
                            CdCargo = 1
                        },
                        new
                        {
                            CdPermissao = 6,
                            CdCargo = 1
                        },
                        new
                        {
                            CdPermissao = 7,
                            CdCargo = 1
                        },
                        new
                        {
                            CdPermissao = 1,
                            CdCargo = 2
                        },
                        new
                        {
                            CdPermissao = 6,
                            CdCargo = 2
                        });
                });

            modelBuilder.Entity("Domain.Entities.RequestChangePassword", b =>
                {
                    b.Property<int>("CdRequest")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CdRequest"));

                    b.Property<Guid>("CdUsuario")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DsCodigoRedefinicao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DtTrocaSenha")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DtValidade")
                        .HasColumnType("datetime2");

                    b.HasKey("CdRequest");

                    b.ToTable("RequestsChangePassword");
                });

            modelBuilder.Entity("Domain.Entities.Turma", b =>
                {
                    b.Property<int>("CdTurma")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CdTurma"));

                    b.Property<int>("CdCurso")
                        .HasColumnType("int");

                    b.Property<Guid>("CdProfessor")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DsTurma")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DtFim")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DtInicio")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IcAbertaMatricula")
                        .HasColumnType("bit");

                    b.Property<string>("NmTurma")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CdTurma");

                    b.HasIndex("CdCurso");

                    b.HasIndex("CdProfessor");

                    b.ToTable("Turmas");
                });

            modelBuilder.Entity("Domain.Entities.Turma_Aluno", b =>
                {
                    b.Property<int>("CdTurma")
                        .HasColumnType("int");

                    b.Property<Guid>("CdAluno")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool?>("IcAprovado")
                        .HasColumnType("bit");

                    b.HasKey("CdTurma", "CdAluno");

                    b.HasIndex("CdAluno");

                    b.ToTable("Turma_Alunos");
                });

            modelBuilder.Entity("Domain.Entities.Usuario", b =>
                {
                    b.Property<Guid>("CdUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DsCpf")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.Property<string>("DsEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("DsFoto")
                        .HasColumnType("varbinary(max)");

                    b.Property<int?>("DsGenero")
                        .HasColumnType("int");

                    b.Property<string>("DsSenha")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DsTelefone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DtNascimento")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("IcHabilitadoTurma")
                        .HasColumnType("bit");

                    b.Property<string>("NmUsuario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CdUsuario");

                    b.ToTable("Usuarios");

                    b.HasData(
                        new
                        {
                            CdUsuario = new Guid("a21fa379-2b28-447f-ad88-87ef9df45df7"),
                            DsCpf = "00000000000",
                            DsEmail = "master@gmail.com",
                            DsSenha = "E59pyTwEJJao6VjsWTBmLGzMr78=",
                            NmUsuario = "Master"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Aula", b =>
                {
                    b.HasOne("Domain.Entities.Turma", "Turma")
                        .WithMany("Aulas")
                        .HasForeignKey("CdTurma")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Turma");
                });

            modelBuilder.Entity("Domain.Entities.Cargo_Usuario", b =>
                {
                    b.HasOne("Domain.Entities.Cargo", "Cargo")
                        .WithMany("CargoUsuario")
                        .HasForeignKey("CdCargo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Usuario", "Usuario")
                        .WithMany("CargoUsuario")
                        .HasForeignKey("CdUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cargo");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Domain.Entities.Certificado", b =>
                {
                    b.HasOne("Domain.Entities.Turma", "Turma")
                        .WithOne("Certificado")
                        .HasForeignKey("Domain.Entities.Certificado", "CdTurma")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Turma");
                });

            modelBuilder.Entity("Domain.Entities.Conteudo", b =>
                {
                    b.HasOne("Domain.Entities.Aula", "Aula")
                        .WithMany("Conteudos")
                        .HasForeignKey("CdAula", "CdTurma")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Aula");
                });

            modelBuilder.Entity("Domain.Entities.Frequencia", b =>
                {
                    b.HasOne("Domain.Entities.Usuario", "Aluno")
                        .WithMany("Frequencia")
                        .HasForeignKey("CdAluno")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Aula", "Aula")
                        .WithMany("Frequencia")
                        .HasForeignKey("CdAula", "CdTurma")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Aluno");

                    b.Navigation("Aula");
                });

            modelBuilder.Entity("Domain.Entities.Matricula", b =>
                {
                    b.HasOne("Domain.Entities.Turma", "Turma")
                        .WithMany("Matriculas")
                        .HasForeignKey("CdTurma")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Turma");
                });

            modelBuilder.Entity("Domain.Entities.Permissao_Cargos", b =>
                {
                    b.HasOne("Domain.Entities.Cargo", "Cargo")
                        .WithMany("PermissaoCargos")
                        .HasForeignKey("CdCargo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Permissao", "Permissao")
                        .WithMany("PermissaoCargos")
                        .HasForeignKey("CdPermissao")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cargo");

                    b.Navigation("Permissao");
                });

            modelBuilder.Entity("Domain.Entities.Turma", b =>
                {
                    b.HasOne("Domain.Entities.Curso", "Curso")
                        .WithMany("Turmas")
                        .HasForeignKey("CdCurso")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Usuario", "Professor")
                        .WithMany("Turmas")
                        .HasForeignKey("CdProfessor")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Curso");

                    b.Navigation("Professor");
                });

            modelBuilder.Entity("Domain.Entities.Turma_Aluno", b =>
                {
                    b.HasOne("Domain.Entities.Usuario", "Usuario")
                        .WithMany("TurmaAluno")
                        .HasForeignKey("CdAluno")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Turma", "Turma")
                        .WithMany("TurmaAluno")
                        .HasForeignKey("CdTurma")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Turma");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Domain.Entities.Aula", b =>
                {
                    b.Navigation("Conteudos");

                    b.Navigation("Frequencia");
                });

            modelBuilder.Entity("Domain.Entities.Cargo", b =>
                {
                    b.Navigation("CargoUsuario");

                    b.Navigation("PermissaoCargos");
                });

            modelBuilder.Entity("Domain.Entities.Curso", b =>
                {
                    b.Navigation("Turmas");
                });

            modelBuilder.Entity("Domain.Entities.Permissao", b =>
                {
                    b.Navigation("PermissaoCargos");
                });

            modelBuilder.Entity("Domain.Entities.Turma", b =>
                {
                    b.Navigation("Aulas");

                    b.Navigation("Certificado");

                    b.Navigation("Matriculas");

                    b.Navigation("TurmaAluno");
                });

            modelBuilder.Entity("Domain.Entities.Usuario", b =>
                {
                    b.Navigation("CargoUsuario");

                    b.Navigation("Frequencia");

                    b.Navigation("TurmaAluno");

                    b.Navigation("Turmas");
                });
#pragma warning restore 612, 618
        }
    }
}
