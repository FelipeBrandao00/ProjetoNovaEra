using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class permissoes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Permissoes",
                columns: new[] { "CdPermissao", "NmPermissao" },
                values: new object[,]
                {
                    { 1, "Gerenciar turmas" },
                    { 2, "Gerenciar alunos" },
                    { 3, "Gerenciar professores" },
                    { 4, "Gerenciar cursos" },
                    { 5, "Gerenciar matriculas" },
                    { 6, "Gerenciar chamadas" },
                    { 7, "Gerenciar usuários" }
                });

            migrationBuilder.InsertData(
                table: "Permissao_Cargos",
                columns: new[] { "CdCargo", "CdPermissao" },
                values: new object[,]
                {
                    { 4, 1 },
                    { 4, 2 },
                    { 4, 3 },
                    { 4, 4 },
                    { 4, 5 },
                    { 4, 6 },
                    { 4, 7 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Permissao_Cargos",
                keyColumns: new[] { "CdCargo", "CdPermissao" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "Permissao_Cargos",
                keyColumns: new[] { "CdCargo", "CdPermissao" },
                keyValues: new object[] { 4, 2 });

            migrationBuilder.DeleteData(
                table: "Permissao_Cargos",
                keyColumns: new[] { "CdCargo", "CdPermissao" },
                keyValues: new object[] { 4, 3 });

            migrationBuilder.DeleteData(
                table: "Permissao_Cargos",
                keyColumns: new[] { "CdCargo", "CdPermissao" },
                keyValues: new object[] { 4, 4 });

            migrationBuilder.DeleteData(
                table: "Permissao_Cargos",
                keyColumns: new[] { "CdCargo", "CdPermissao" },
                keyValues: new object[] { 4, 5 });

            migrationBuilder.DeleteData(
                table: "Permissao_Cargos",
                keyColumns: new[] { "CdCargo", "CdPermissao" },
                keyValues: new object[] { 4, 6 });

            migrationBuilder.DeleteData(
                table: "Permissao_Cargos",
                keyColumns: new[] { "CdCargo", "CdPermissao" },
                keyValues: new object[] { 4, 7 });

            migrationBuilder.DeleteData(
                table: "Permissoes",
                keyColumn: "CdPermissao",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Permissoes",
                keyColumn: "CdPermissao",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Permissoes",
                keyColumn: "CdPermissao",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Permissoes",
                keyColumn: "CdPermissao",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Permissoes",
                keyColumn: "CdPermissao",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Permissoes",
                keyColumn: "CdPermissao",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Permissoes",
                keyColumn: "CdPermissao",
                keyValue: 7);
        }
    }
}
