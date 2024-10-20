using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cargos",
                columns: table => new
                {
                    CdCargo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DsCargo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cargos", x => x.CdCargo);
                });

            migrationBuilder.CreateTable(
                name: "Cursos",
                columns: table => new
                {
                    CdCurso = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NmCurso = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DsCurso = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DtCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DtFinalizacao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cursos", x => x.CdCurso);
                });

            migrationBuilder.CreateTable(
                name: "Permissoes",
                columns: table => new
                {
                    CdPermissao = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NmPermissao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissoes", x => x.CdPermissao);
                });

            migrationBuilder.CreateTable(
                name: "RequestsChangePassword",
                columns: table => new
                {
                    CdRequest = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CdUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DsCodigoRedefinicao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DtValidade = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DtTrocaSenha = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestsChangePassword", x => x.CdRequest);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    CdUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NmUsuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DsEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DsSenha = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DsCpf = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: true),
                    DsGenero = table.Column<int>(type: "int", nullable: true),
                    DtNascimento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IcHabilitadoTurma = table.Column<bool>(type: "bit", nullable: true),
                    DsFoto = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    DsTelefone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.CdUsuario);
                });

            migrationBuilder.CreateTable(
                name: "Permissao_Cargos",
                columns: table => new
                {
                    CdCargo = table.Column<int>(type: "int", nullable: false),
                    CdPermissao = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissao_Cargos", x => new { x.CdPermissao, x.CdCargo });
                    table.ForeignKey(
                        name: "FK_Permissao_Cargos_Cargos_CdCargo",
                        column: x => x.CdCargo,
                        principalTable: "Cargos",
                        principalColumn: "CdCargo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Permissao_Cargos_Permissoes_CdPermissao",
                        column: x => x.CdPermissao,
                        principalTable: "Permissoes",
                        principalColumn: "CdPermissao",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cargo_Usuarios",
                columns: table => new
                {
                    CdUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CdCargo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cargo_Usuarios", x => new { x.CdUsuario, x.CdCargo });
                    table.ForeignKey(
                        name: "FK_Cargo_Usuarios_Cargos_CdCargo",
                        column: x => x.CdCargo,
                        principalTable: "Cargos",
                        principalColumn: "CdCargo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cargo_Usuarios_Usuarios_CdUsuario",
                        column: x => x.CdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "CdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Turmas",
                columns: table => new
                {
                    CdTurma = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DsTurma = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DtInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DtFim = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CdProfessor = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CdCurso = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turmas", x => x.CdTurma);
                    table.ForeignKey(
                        name: "FK_Turmas_Cursos_CdCurso",
                        column: x => x.CdCurso,
                        principalTable: "Cursos",
                        principalColumn: "CdCurso",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Turmas_Usuarios_CdProfessor",
                        column: x => x.CdProfessor,
                        principalTable: "Usuarios",
                        principalColumn: "CdUsuario");
                });

            migrationBuilder.CreateTable(
                name: "Aulas",
                columns: table => new
                {
                    CdAula = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CdTurma = table.Column<int>(type: "int", nullable: false),
                    DtAula = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DsAula = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aulas", x => new { x.CdAula, x.CdTurma });
                    table.ForeignKey(
                        name: "FK_Aulas_Turmas_CdTurma",
                        column: x => x.CdTurma,
                        principalTable: "Turmas",
                        principalColumn: "CdTurma",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Certificados",
                columns: table => new
                {
                    CdCertificado = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NmArquivo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DsExtensao = table.Column<int>(type: "int", nullable: false),
                    CdTurma = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Certificados", x => x.CdCertificado);
                    table.ForeignKey(
                        name: "FK_Certificados_Turmas_CdTurma",
                        column: x => x.CdTurma,
                        principalTable: "Turmas",
                        principalColumn: "CdTurma",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Turma_Alunos",
                columns: table => new
                {
                    CdAluno = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CdTurma = table.Column<int>(type: "int", nullable: false),
                    IcAprovado = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turma_Alunos", x => new { x.CdTurma, x.CdAluno });
                    table.ForeignKey(
                        name: "FK_Turma_Alunos_Turmas_CdTurma",
                        column: x => x.CdTurma,
                        principalTable: "Turmas",
                        principalColumn: "CdTurma",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Turma_Alunos_Usuarios_CdAluno",
                        column: x => x.CdAluno,
                        principalTable: "Usuarios",
                        principalColumn: "CdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Conteudos",
                columns: table => new
                {
                    CdConteudo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DsConteudo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NmArquivo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DsExtencao = table.Column<int>(type: "int", nullable: false),
                    CdAula = table.Column<int>(type: "int", nullable: false),
                    CdTurma = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conteudos", x => x.CdConteudo);
                    table.ForeignKey(
                        name: "FK_Conteudos_Aulas_CdAula_CdTurma",
                        columns: x => new { x.CdAula, x.CdTurma },
                        principalTable: "Aulas",
                        principalColumns: new[] { "CdAula", "CdTurma" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Frequencias",
                columns: table => new
                {
                    CdAluno = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CdTurma = table.Column<int>(type: "int", nullable: false),
                    CdAula = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Frequencias", x => new { x.CdAula, x.CdTurma, x.CdAluno });
                    table.ForeignKey(
                        name: "FK_Frequencias_Aulas_CdAula_CdTurma",
                        columns: x => new { x.CdAula, x.CdTurma },
                        principalTable: "Aulas",
                        principalColumns: new[] { "CdAula", "CdTurma" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Frequencias_Usuarios_CdAluno",
                        column: x => x.CdAluno,
                        principalTable: "Usuarios",
                        principalColumn: "CdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Cargos",
                columns: new[] { "CdCargo", "DsCargo" },
                values: new object[,]
                {
                    { 1, "Administrador" },
                    { 2, "Professor" },
                    { 3, "Aluno" },
                    { 4, "Master" }
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "CdUsuario", "DsCpf", "DsEmail", "DsFoto", "DsGenero", "DsSenha", "DsTelefone", "DtNascimento", "IcHabilitadoTurma", "NmUsuario" },
                values: new object[] { new Guid("a21fa379-2b28-447f-ad88-87ef9df45df7"), null, "master@mail.com", null, null, "E59pyTwEJJao6VjsWTBmLGzMr78=", null, null, null, "Master" });

            migrationBuilder.InsertData(
                table: "Cargo_Usuarios",
                columns: new[] { "CdCargo", "CdUsuario" },
                values: new object[,]
                {
                    { 1, new Guid("a21fa379-2b28-447f-ad88-87ef9df45df7") },
                    { 4, new Guid("a21fa379-2b28-447f-ad88-87ef9df45df7") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Aulas_CdTurma",
                table: "Aulas",
                column: "CdTurma");

            migrationBuilder.CreateIndex(
                name: "IX_Cargo_Usuarios_CdCargo",
                table: "Cargo_Usuarios",
                column: "CdCargo");

            migrationBuilder.CreateIndex(
                name: "IX_Certificados_CdTurma",
                table: "Certificados",
                column: "CdTurma",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Conteudos_CdAula_CdTurma",
                table: "Conteudos",
                columns: new[] { "CdAula", "CdTurma" });

            migrationBuilder.CreateIndex(
                name: "IX_Frequencias_CdAluno",
                table: "Frequencias",
                column: "CdAluno");

            migrationBuilder.CreateIndex(
                name: "IX_Permissao_Cargos_CdCargo",
                table: "Permissao_Cargos",
                column: "CdCargo");

            migrationBuilder.CreateIndex(
                name: "IX_Turma_Alunos_CdAluno",
                table: "Turma_Alunos",
                column: "CdAluno");

            migrationBuilder.CreateIndex(
                name: "IX_Turmas_CdCurso",
                table: "Turmas",
                column: "CdCurso");

            migrationBuilder.CreateIndex(
                name: "IX_Turmas_CdProfessor",
                table: "Turmas",
                column: "CdProfessor");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cargo_Usuarios");

            migrationBuilder.DropTable(
                name: "Certificados");

            migrationBuilder.DropTable(
                name: "Conteudos");

            migrationBuilder.DropTable(
                name: "Frequencias");

            migrationBuilder.DropTable(
                name: "Permissao_Cargos");

            migrationBuilder.DropTable(
                name: "RequestsChangePassword");

            migrationBuilder.DropTable(
                name: "Turma_Alunos");

            migrationBuilder.DropTable(
                name: "Aulas");

            migrationBuilder.DropTable(
                name: "Cargos");

            migrationBuilder.DropTable(
                name: "Permissoes");

            migrationBuilder.DropTable(
                name: "Turmas");

            migrationBuilder.DropTable(
                name: "Cursos");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
