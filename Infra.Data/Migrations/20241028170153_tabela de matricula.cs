using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class tabeladematricula : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Matriculas",
                columns: table => new
                {
                    CdMatricula = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NmUsuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DsEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DsCpf = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: true),
                    DsGenero = table.Column<int>(type: "int", nullable: true),
                    DtNascimento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DsFoto = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    DsTelefone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CdTurma = table.Column<int>(type: "int", nullable: false),
                    TurmaCdTurma = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matriculas", x => x.CdMatricula);
                    table.ForeignKey(
                        name: "FK_Matriculas_Turmas_TurmaCdTurma",
                        column: x => x.TurmaCdTurma,
                        principalTable: "Turmas",
                        principalColumn: "CdTurma",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Matriculas_TurmaCdTurma",
                table: "Matriculas",
                column: "TurmaCdTurma");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Matriculas");
        }
    }
}
