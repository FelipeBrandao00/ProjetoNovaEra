using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class user : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cargos",
                columns: table => new
                {
                    cdCargo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dsCargo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cargos", x => x.cdCargo);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    cdUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nmUsuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dsEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dsSenha = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.cdUsuario);
                });

            migrationBuilder.CreateTable(
                name: "Cargo_Usuarios",
                columns: table => new
                {
                    cdUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    cdCargo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cargo_Usuarios", x => new { x.cdUsuario, x.cdCargo });
                    table.ForeignKey(
                        name: "FK_Cargo_Usuarios_Cargos_cdCargo",
                        column: x => x.cdCargo,
                        principalTable: "Cargos",
                        principalColumn: "cdCargo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cargo_Usuarios_Usuarios_cdUsuario",
                        column: x => x.cdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "cdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cargo_Usuarios_cdCargo",
                table: "Cargo_Usuarios",
                column: "cdCargo");

            migrationBuilder.AddForeignKey(
                name: "FK_Alunos_Usuarios_cdAluno",
                table: "Alunos",
                column: "cdAluno",
                principalTable: "Usuarios",
                principalColumn: "cdUsuario");

            migrationBuilder.AddForeignKey(
                name: "FK_Professores_Usuarios_cdProfessor",
                table: "Professores",
                column: "cdProfessor",
                principalTable: "Usuarios",
                principalColumn: "cdUsuario");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alunos_Usuarios_cdAluno",
                table: "Alunos");

            migrationBuilder.DropForeignKey(
                name: "FK_Professores_Usuarios_cdProfessor",
                table: "Professores");

            migrationBuilder.DropTable(
                name: "Cargo_Usuarios");

            migrationBuilder.DropTable(
                name: "Cargos");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
