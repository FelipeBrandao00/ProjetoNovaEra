using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class permissoes_cargos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Permissao_Cargos",
                columns: new[] { "CdCargo", "CdPermissao" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 1, 2 },
                    { 1, 3 },
                    { 1, 4 },
                    { 1, 5 },
                    { 2, 5 },
                    { 1, 6 },
                    { 2, 6 },
                    { 1, 7 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Permissao_Cargos",
                keyColumns: new[] { "CdCargo", "CdPermissao" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "Permissao_Cargos",
                keyColumns: new[] { "CdCargo", "CdPermissao" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "Permissao_Cargos",
                keyColumns: new[] { "CdCargo", "CdPermissao" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "Permissao_Cargos",
                keyColumns: new[] { "CdCargo", "CdPermissao" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "Permissao_Cargos",
                keyColumns: new[] { "CdCargo", "CdPermissao" },
                keyValues: new object[] { 1, 4 });

            migrationBuilder.DeleteData(
                table: "Permissao_Cargos",
                keyColumns: new[] { "CdCargo", "CdPermissao" },
                keyValues: new object[] { 1, 5 });

            migrationBuilder.DeleteData(
                table: "Permissao_Cargos",
                keyColumns: new[] { "CdCargo", "CdPermissao" },
                keyValues: new object[] { 2, 5 });

            migrationBuilder.DeleteData(
                table: "Permissao_Cargos",
                keyColumns: new[] { "CdCargo", "CdPermissao" },
                keyValues: new object[] { 1, 6 });

            migrationBuilder.DeleteData(
                table: "Permissao_Cargos",
                keyColumns: new[] { "CdCargo", "CdPermissao" },
                keyValues: new object[] { 2, 6 });

            migrationBuilder.DeleteData(
                table: "Permissao_Cargos",
                keyColumns: new[] { "CdCargo", "CdPermissao" },
                keyValues: new object[] { 1, 7 });
        }
    }
}
