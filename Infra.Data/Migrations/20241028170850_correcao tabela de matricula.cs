using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class correcaotabeladematricula : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matriculas_Turmas_TurmaCdTurma",
                table: "Matriculas");

            migrationBuilder.DropIndex(
                name: "IX_Matriculas_TurmaCdTurma",
                table: "Matriculas");

            migrationBuilder.DropColumn(
                name: "TurmaCdTurma",
                table: "Matriculas");

            migrationBuilder.CreateIndex(
                name: "IX_Matriculas_CdTurma",
                table: "Matriculas",
                column: "CdTurma");

            migrationBuilder.AddForeignKey(
                name: "FK_Matriculas_Turmas_CdTurma",
                table: "Matriculas",
                column: "CdTurma",
                principalTable: "Turmas",
                principalColumn: "CdTurma");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matriculas_Turmas_CdTurma",
                table: "Matriculas");

            migrationBuilder.DropIndex(
                name: "IX_Matriculas_CdTurma",
                table: "Matriculas");

            migrationBuilder.AddColumn<int>(
                name: "TurmaCdTurma",
                table: "Matriculas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Matriculas_TurmaCdTurma",
                table: "Matriculas",
                column: "TurmaCdTurma");

            migrationBuilder.AddForeignKey(
                name: "FK_Matriculas_Turmas_TurmaCdTurma",
                table: "Matriculas",
                column: "TurmaCdTurma",
                principalTable: "Turmas",
                principalColumn: "CdTurma",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
