using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class Adiçãodevalorespadraoaoiniciarobanco : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "DsGenero",
                table: "Usuarios",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "DsCpf",
                table: "Usuarios",
                type: "nvarchar(12)",
                maxLength: 12,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(12)",
                oldMaxLength: 12);

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
                columns: new[] { "CdUsuario", "DsCpf", "DsEmail", "DsGenero", "DsSenha", "DtNascimento", "IcHabilitadoTurma", "NmUsuario" },
                values: new object[] { new Guid("a21fa379-2b28-447f-ad88-87ef9df45df7"), null, "master@mail.com", null, "E59pyTwEJJao6VjsWTBmLGzMr78=", null, null, "Master" });

            migrationBuilder.InsertData(
                table: "Cargo_Usuarios",
                columns: new[] { "CdCargo", "CdUsuario" },
                values: new object[,]
                {
                    { 1, new Guid("a21fa379-2b28-447f-ad88-87ef9df45df7") },
                    { 4, new Guid("a21fa379-2b28-447f-ad88-87ef9df45df7") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cargo_Usuarios",
                keyColumns: new[] { "CdCargo", "CdUsuario" },
                keyValues: new object[] { 1, new Guid("a21fa379-2b28-447f-ad88-87ef9df45df7") });

            migrationBuilder.DeleteData(
                table: "Cargo_Usuarios",
                keyColumns: new[] { "CdCargo", "CdUsuario" },
                keyValues: new object[] { 4, new Guid("a21fa379-2b28-447f-ad88-87ef9df45df7") });

            migrationBuilder.DeleteData(
                table: "Cargos",
                keyColumn: "CdCargo",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cargos",
                keyColumn: "CdCargo",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Cargos",
                keyColumn: "CdCargo",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cargos",
                keyColumn: "CdCargo",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "CdUsuario",
                keyValue: new Guid("a21fa379-2b28-447f-ad88-87ef9df45df7"));

            migrationBuilder.AlterColumn<int>(
                name: "DsGenero",
                table: "Usuarios",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DsCpf",
                table: "Usuarios",
                type: "nvarchar(12)",
                maxLength: 12,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(12)",
                oldMaxLength: 12,
                oldNullable: true);
        }
    }
}
