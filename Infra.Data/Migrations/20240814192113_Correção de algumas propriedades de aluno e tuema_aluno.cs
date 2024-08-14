using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class Correçãodealgumaspropriedadesdealunoetuema_aluno : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DtFinalizacao",
                table: "Cursos");

            migrationBuilder.DropColumn(
                name: "QtHoras",
                table: "Cursos");

            migrationBuilder.AddColumn<byte[]>(
                name: "DsFoto",
                table: "Usuarios",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DsTelefone",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IcAprovado",
                table: "Turma_Alunos",
                type: "bit",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "CdUsuario",
                keyValue: new Guid("a21fa379-2b28-447f-ad88-87ef9df45df7"),
                columns: new[] { "DsFoto", "DsTelefone" },
                values: new object[] { null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DsFoto",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "DsTelefone",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "IcAprovado",
                table: "Turma_Alunos");

            migrationBuilder.AddColumn<DateTime>(
                name: "DtFinalizacao",
                table: "Cursos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "QtHoras",
                table: "Cursos",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
