using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class MudancacertificadoExtensao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "DsExtensao",
                table: "Certificados",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "CdUsuario",
                keyValue: new Guid("a21fa379-2b28-447f-ad88-87ef9df45df7"),
                columns: new[] { "DsCpf", "DsEmail" },
                values: new object[] { "00000000000", "master@gmail.com" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "DsExtensao",
                table: "Certificados",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "CdUsuario",
                keyValue: new Guid("a21fa379-2b28-447f-ad88-87ef9df45df7"),
                columns: new[] { "DsCpf", "DsEmail" },
                values: new object[] { null, "master@mail.com" });
        }
    }
}
