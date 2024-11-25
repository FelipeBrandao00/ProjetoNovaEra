using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class fixprofessor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Permissao_Cargos",
                keyColumns: new[] { "CdCargo", "CdPermissao" },
                keyValues: new object[] { 2, 5 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Permissao_Cargos",
                columns: new[] { "CdCargo", "CdPermissao" },
                values: new object[] { 2, 5 });
        }
    }
}
