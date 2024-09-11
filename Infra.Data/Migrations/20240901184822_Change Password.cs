using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangePassword : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RequestsChangePassword",
                columns: table => new
                {
                    CdRequest = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CdUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DsCodigoRedefinicao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DtValidade = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestsChangePassword", x => x.CdRequest);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RequestsChangePassword");
        }
    }
}
