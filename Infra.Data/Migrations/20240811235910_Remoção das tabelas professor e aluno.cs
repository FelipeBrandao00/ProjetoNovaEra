using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class Remoçãodastabelasprofessorealuno : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Frequencias_Alunos_CdAluno",
                table: "Frequencias");

            migrationBuilder.DropForeignKey(
                name: "FK_Turma_Alunos_Alunos_CdAluno",
                table: "Turma_Alunos");

            migrationBuilder.DropForeignKey(
                name: "FK_Turmas_Cursos_cdCurso",
                table: "Turmas");

            migrationBuilder.DropForeignKey(
                name: "FK_Turmas_Professores_cdProfessor",
                table: "Turmas");

            migrationBuilder.DropTable(
                name: "Alunos");

            migrationBuilder.DropTable(
                name: "Professores");

            migrationBuilder.DropIndex(
                name: "IX_Turma_Alunos_CdAluno",
                table: "Turma_Alunos");

            migrationBuilder.RenameColumn(
                name: "dtInicio",
                table: "Turmas",
                newName: "DtInicio");

            migrationBuilder.RenameColumn(
                name: "dtFim",
                table: "Turmas",
                newName: "DtFim");

            migrationBuilder.RenameColumn(
                name: "cdProfessor",
                table: "Turmas",
                newName: "CdProfessor");

            migrationBuilder.RenameColumn(
                name: "cdCurso",
                table: "Turmas",
                newName: "CdCurso");

            migrationBuilder.RenameColumn(
                name: "cdTurma",
                table: "Turmas",
                newName: "CdTurma");

            migrationBuilder.RenameIndex(
                name: "IX_Turmas_cdProfessor",
                table: "Turmas",
                newName: "IX_Turmas_CdProfessor");

            migrationBuilder.RenameIndex(
                name: "IX_Turmas_cdCurso",
                table: "Turmas",
                newName: "IX_Turmas_CdCurso");

            migrationBuilder.AddColumn<DateTime>(
                name: "DtNascimento",
                table: "Usuarios",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IcHabilitadoTurma",
                table: "Usuarios",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "AlunoCdUsuario",
                table: "Turma_Alunos",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Turma_Alunos_AlunoCdUsuario",
                table: "Turma_Alunos",
                column: "AlunoCdUsuario");

            migrationBuilder.AddForeignKey(
                name: "FK_Frequencias_Usuarios_CdAluno",
                table: "Frequencias",
                column: "CdAluno",
                principalTable: "Usuarios",
                principalColumn: "CdUsuario",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Turma_Alunos_Usuarios_AlunoCdUsuario",
                table: "Turma_Alunos",
                column: "AlunoCdUsuario",
                principalTable: "Usuarios",
                principalColumn: "CdUsuario",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Turmas_Cursos_CdCurso",
                table: "Turmas",
                column: "CdCurso",
                principalTable: "Cursos",
                principalColumn: "CdCurso",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Turmas_Usuarios_CdProfessor",
                table: "Turmas",
                column: "CdProfessor",
                principalTable: "Usuarios",
                principalColumn: "CdUsuario");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Frequencias_Usuarios_CdAluno",
                table: "Frequencias");

            migrationBuilder.DropForeignKey(
                name: "FK_Turma_Alunos_Usuarios_AlunoCdUsuario",
                table: "Turma_Alunos");

            migrationBuilder.DropForeignKey(
                name: "FK_Turmas_Cursos_CdCurso",
                table: "Turmas");

            migrationBuilder.DropForeignKey(
                name: "FK_Turmas_Usuarios_CdProfessor",
                table: "Turmas");

            migrationBuilder.DropIndex(
                name: "IX_Turma_Alunos_AlunoCdUsuario",
                table: "Turma_Alunos");

            migrationBuilder.DropColumn(
                name: "DtNascimento",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "IcHabilitadoTurma",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "AlunoCdUsuario",
                table: "Turma_Alunos");

            migrationBuilder.RenameColumn(
                name: "DtInicio",
                table: "Turmas",
                newName: "dtInicio");

            migrationBuilder.RenameColumn(
                name: "DtFim",
                table: "Turmas",
                newName: "dtFim");

            migrationBuilder.RenameColumn(
                name: "CdProfessor",
                table: "Turmas",
                newName: "cdProfessor");

            migrationBuilder.RenameColumn(
                name: "CdCurso",
                table: "Turmas",
                newName: "cdCurso");

            migrationBuilder.RenameColumn(
                name: "CdTurma",
                table: "Turmas",
                newName: "cdTurma");

            migrationBuilder.RenameIndex(
                name: "IX_Turmas_CdProfessor",
                table: "Turmas",
                newName: "IX_Turmas_cdProfessor");

            migrationBuilder.RenameIndex(
                name: "IX_Turmas_CdCurso",
                table: "Turmas",
                newName: "IX_Turmas_cdCurso");

            migrationBuilder.CreateTable(
                name: "Alunos",
                columns: table => new
                {
                    CdAluno = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DtNascimentoAluno = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alunos", x => x.CdAluno);
                    table.ForeignKey(
                        name: "FK_Alunos_Usuarios_CdAluno",
                        column: x => x.CdAluno,
                        principalTable: "Usuarios",
                        principalColumn: "CdUsuario");
                });

            migrationBuilder.CreateTable(
                name: "Professores",
                columns: table => new
                {
                    CdProfessor = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IcHabilitadoTurma = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professores", x => x.CdProfessor);
                    table.ForeignKey(
                        name: "FK_Professores_Usuarios_CdProfessor",
                        column: x => x.CdProfessor,
                        principalTable: "Usuarios",
                        principalColumn: "CdUsuario");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Turma_Alunos_CdAluno",
                table: "Turma_Alunos",
                column: "CdAluno");

            migrationBuilder.AddForeignKey(
                name: "FK_Frequencias_Alunos_CdAluno",
                table: "Frequencias",
                column: "CdAluno",
                principalTable: "Alunos",
                principalColumn: "CdAluno",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Turma_Alunos_Alunos_CdAluno",
                table: "Turma_Alunos",
                column: "CdAluno",
                principalTable: "Alunos",
                principalColumn: "CdAluno",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Turmas_Cursos_cdCurso",
                table: "Turmas",
                column: "cdCurso",
                principalTable: "Cursos",
                principalColumn: "CdCurso",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Turmas_Professores_cdProfessor",
                table: "Turmas",
                column: "cdProfessor",
                principalTable: "Professores",
                principalColumn: "CdProfessor",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
