using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alunos",
                columns: table => new
                {
                    cdAluno = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nmAluno = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    dtNascimentoAluno = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dsCPFAluno = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    dsGenero = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alunos", x => x.cdAluno);
                });

            migrationBuilder.CreateTable(
                name: "Cursos",
                columns: table => new
                {
                    cdCurso = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nmCurso = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dsCurso = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dtCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dtFinalizacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    qtHoras = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cursos", x => x.cdCurso);
                });

            migrationBuilder.CreateTable(
                name: "Professores",
                columns: table => new
                {
                    cdProfessor = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nmProfessor = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    dsCPFProfessor = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    icHabilitadoTurma = table.Column<bool>(type: "bit", nullable: false),
                    dsEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dsGenero = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professores", x => x.cdProfessor);
                });

            migrationBuilder.CreateTable(
                name: "Turmas",
                columns: table => new
                {
                    cdTurma = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dtInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dtFim = table.Column<DateTime>(type: "datetime2", nullable: false),
                    cdProfessor = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    cdCurso = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turmas", x => x.cdTurma);
                    table.ForeignKey(
                        name: "FK_Turmas_Cursos_cdCurso",
                        column: x => x.cdCurso,
                        principalTable: "Cursos",
                        principalColumn: "cdCurso",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Turmas_Professores_cdProfessor",
                        column: x => x.cdProfessor,
                        principalTable: "Professores",
                        principalColumn: "cdProfessor",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Aulas",
                columns: table => new
                {
                    cdAula = table.Column<int>(type: "int", nullable: false),
                    cdTurma = table.Column<int>(type: "int", nullable: false),
                    dtAula = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aulas", x => new { x.cdAula, x.cdTurma });
                    table.ForeignKey(
                        name: "FK_Aulas_Turmas_cdTurma",
                        column: x => x.cdTurma,
                        principalTable: "Turmas",
                        principalColumn: "cdTurma",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Certificados",
                columns: table => new
                {
                    cdCertificado = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nmArquivo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dsExtensao = table.Column<int>(type: "int", nullable: false),
                    cdTurma = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Certificados", x => x.cdCertificado);
                    table.ForeignKey(
                        name: "FK_Certificados_Turmas_cdTurma",
                        column: x => x.cdTurma,
                        principalTable: "Turmas",
                        principalColumn: "cdTurma",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Turma_Alunos",
                columns: table => new
                {
                    cdAluno = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    cdTurma = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turma_Alunos", x => new { x.cdTurma, x.cdAluno });
                    table.ForeignKey(
                        name: "FK_Turma_Alunos_Alunos_cdAluno",
                        column: x => x.cdAluno,
                        principalTable: "Alunos",
                        principalColumn: "cdAluno",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Turma_Alunos_Turmas_cdTurma",
                        column: x => x.cdTurma,
                        principalTable: "Turmas",
                        principalColumn: "cdTurma",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Conteudos",
                columns: table => new
                {
                    cdConteudo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dsConteudo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nmArquivo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dsExtencao = table.Column<int>(type: "int", nullable: false),
                    cdAula = table.Column<int>(type: "int", nullable: false),
                    cdTurma = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conteudos", x => x.cdConteudo);
                    table.ForeignKey(
                        name: "FK_Conteudos_Aulas_cdAula_cdTurma",
                        columns: x => new { x.cdAula, x.cdTurma },
                        principalTable: "Aulas",
                        principalColumns: new[] { "cdAula", "cdTurma" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Frequencias",
                columns: table => new
                {
                    cdAluno = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    cdTurma = table.Column<int>(type: "int", nullable: false),
                    cdAula = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Frequencias", x => new { x.cdAula, x.cdTurma, x.cdAluno });
                    table.ForeignKey(
                        name: "FK_Frequencias_Alunos_cdAluno",
                        column: x => x.cdAluno,
                        principalTable: "Alunos",
                        principalColumn: "cdAluno",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Frequencias_Aulas_cdAula_cdTurma",
                        columns: x => new { x.cdAula, x.cdTurma },
                        principalTable: "Aulas",
                        principalColumns: new[] { "cdAula", "cdTurma" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Aulas_cdTurma",
                table: "Aulas",
                column: "cdTurma");

            migrationBuilder.CreateIndex(
                name: "IX_Certificados_cdTurma",
                table: "Certificados",
                column: "cdTurma",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Conteudos_cdAula_cdTurma",
                table: "Conteudos",
                columns: new[] { "cdAula", "cdTurma" });

            migrationBuilder.CreateIndex(
                name: "IX_Frequencias_cdAluno",
                table: "Frequencias",
                column: "cdAluno");

            migrationBuilder.CreateIndex(
                name: "IX_Turma_Alunos_cdAluno",
                table: "Turma_Alunos",
                column: "cdAluno");

            migrationBuilder.CreateIndex(
                name: "IX_Turmas_cdCurso",
                table: "Turmas",
                column: "cdCurso");

            migrationBuilder.CreateIndex(
                name: "IX_Turmas_cdProfessor",
                table: "Turmas",
                column: "cdProfessor");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Certificados");

            migrationBuilder.DropTable(
                name: "Conteudos");

            migrationBuilder.DropTable(
                name: "Frequencias");

            migrationBuilder.DropTable(
                name: "Turma_Alunos");

            migrationBuilder.DropTable(
                name: "Aulas");

            migrationBuilder.DropTable(
                name: "Alunos");

            migrationBuilder.DropTable(
                name: "Turmas");

            migrationBuilder.DropTable(
                name: "Cursos");

            migrationBuilder.DropTable(
                name: "Professores");
        }
    }
}
