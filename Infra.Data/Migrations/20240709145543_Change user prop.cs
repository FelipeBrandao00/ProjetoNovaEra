using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class Changeuserprop : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "dsCPFProfessor",
                table: "Professores");

            migrationBuilder.DropColumn(
                name: "dsEmail",
                table: "Professores");

            migrationBuilder.DropColumn(
                name: "dsGenero",
                table: "Professores");

            migrationBuilder.DropColumn(
                name: "nmProfessor",
                table: "Professores");

            migrationBuilder.DropColumn(
                name: "dsCPFAluno",
                table: "Alunos");

            migrationBuilder.DropColumn(
                name: "dsGenero",
                table: "Alunos");

            migrationBuilder.DropColumn(
                name: "nmAluno",
                table: "Alunos");

            migrationBuilder.AddColumn<string>(
                name: "dsCPF",
                table: "Usuarios",
                type: "nvarchar(12)",
                maxLength: 12,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "dsGenero",
                table: "Usuarios",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "dsCPF",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "dsGenero",
                table: "Usuarios");

            migrationBuilder.AddColumn<string>(
                name: "dsCPFProfessor",
                table: "Professores",
                type: "nvarchar(12)",
                maxLength: 12,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "dsEmail",
                table: "Professores",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "dsGenero",
                table: "Professores",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "nmProfessor",
                table: "Professores",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "dsCPFAluno",
                table: "Alunos",
                type: "nvarchar(12)",
                maxLength: 12,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "dsGenero",
                table: "Alunos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "nmAluno",
                table: "Alunos",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }
    }
}
