using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class Mudandonomedaspropriedadesdasentidades : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alunos_Usuarios_cdAluno",
                table: "Alunos");

            migrationBuilder.DropForeignKey(
                name: "FK_Aulas_Turmas_cdTurma",
                table: "Aulas");

            migrationBuilder.DropForeignKey(
                name: "FK_Cargo_Usuarios_Cargos_cdCargo",
                table: "Cargo_Usuarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Cargo_Usuarios_Usuarios_cdUsuario",
                table: "Cargo_Usuarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Certificados_Turmas_cdTurma",
                table: "Certificados");

            migrationBuilder.DropForeignKey(
                name: "FK_Conteudos_Aulas_cdAula_cdTurma",
                table: "Conteudos");

            migrationBuilder.DropForeignKey(
                name: "FK_Frequencias_Alunos_cdAluno",
                table: "Frequencias");

            migrationBuilder.DropForeignKey(
                name: "FK_Frequencias_Aulas_cdAula_cdTurma",
                table: "Frequencias");

            migrationBuilder.DropForeignKey(
                name: "FK_Professores_Usuarios_cdProfessor",
                table: "Professores");

            migrationBuilder.DropForeignKey(
                name: "FK_Turma_Alunos_Alunos_cdAluno",
                table: "Turma_Alunos");

            migrationBuilder.DropForeignKey(
                name: "FK_Turma_Alunos_Turmas_cdTurma",
                table: "Turma_Alunos");

            migrationBuilder.RenameColumn(
                name: "nmUsuario",
                table: "Usuarios",
                newName: "NmUsuario");

            migrationBuilder.RenameColumn(
                name: "dsSenha",
                table: "Usuarios",
                newName: "DsSenha");

            migrationBuilder.RenameColumn(
                name: "dsGenero",
                table: "Usuarios",
                newName: "DsGenero");

            migrationBuilder.RenameColumn(
                name: "dsEmail",
                table: "Usuarios",
                newName: "DsEmail");

            migrationBuilder.RenameColumn(
                name: "dsCPF",
                table: "Usuarios",
                newName: "DsCpf");

            migrationBuilder.RenameColumn(
                name: "cdUsuario",
                table: "Usuarios",
                newName: "CdUsuario");

            migrationBuilder.RenameColumn(
                name: "cdAluno",
                table: "Turma_Alunos",
                newName: "CdAluno");

            migrationBuilder.RenameColumn(
                name: "cdTurma",
                table: "Turma_Alunos",
                newName: "CdTurma");

            migrationBuilder.RenameIndex(
                name: "IX_Turma_Alunos_cdAluno",
                table: "Turma_Alunos",
                newName: "IX_Turma_Alunos_CdAluno");

            migrationBuilder.RenameColumn(
                name: "icHabilitadoTurma",
                table: "Professores",
                newName: "IcHabilitadoTurma");

            migrationBuilder.RenameColumn(
                name: "cdProfessor",
                table: "Professores",
                newName: "CdProfessor");

            migrationBuilder.RenameColumn(
                name: "cdAluno",
                table: "Frequencias",
                newName: "CdAluno");

            migrationBuilder.RenameColumn(
                name: "cdTurma",
                table: "Frequencias",
                newName: "CdTurma");

            migrationBuilder.RenameColumn(
                name: "cdAula",
                table: "Frequencias",
                newName: "CdAula");

            migrationBuilder.RenameIndex(
                name: "IX_Frequencias_cdAluno",
                table: "Frequencias",
                newName: "IX_Frequencias_CdAluno");

            migrationBuilder.RenameColumn(
                name: "qtHoras",
                table: "Cursos",
                newName: "QtHoras");

            migrationBuilder.RenameColumn(
                name: "nmCurso",
                table: "Cursos",
                newName: "NmCurso");

            migrationBuilder.RenameColumn(
                name: "dtFinalizacao",
                table: "Cursos",
                newName: "DtFinalizacao");

            migrationBuilder.RenameColumn(
                name: "dtCriacao",
                table: "Cursos",
                newName: "DtCriacao");

            migrationBuilder.RenameColumn(
                name: "dsCurso",
                table: "Cursos",
                newName: "DsCurso");

            migrationBuilder.RenameColumn(
                name: "cdCurso",
                table: "Cursos",
                newName: "CdCurso");

            migrationBuilder.RenameColumn(
                name: "nmArquivo",
                table: "Conteudos",
                newName: "NmArquivo");

            migrationBuilder.RenameColumn(
                name: "dsExtencao",
                table: "Conteudos",
                newName: "DsExtencao");

            migrationBuilder.RenameColumn(
                name: "dsConteudo",
                table: "Conteudos",
                newName: "DsConteudo");

            migrationBuilder.RenameColumn(
                name: "cdTurma",
                table: "Conteudos",
                newName: "CdTurma");

            migrationBuilder.RenameColumn(
                name: "cdAula",
                table: "Conteudos",
                newName: "CdAula");

            migrationBuilder.RenameColumn(
                name: "cdConteudo",
                table: "Conteudos",
                newName: "CdConteudo");

            migrationBuilder.RenameIndex(
                name: "IX_Conteudos_cdAula_cdTurma",
                table: "Conteudos",
                newName: "IX_Conteudos_CdAula_CdTurma");

            migrationBuilder.RenameColumn(
                name: "nmArquivo",
                table: "Certificados",
                newName: "NmArquivo");

            migrationBuilder.RenameColumn(
                name: "dsExtensao",
                table: "Certificados",
                newName: "DsExtensao");

            migrationBuilder.RenameColumn(
                name: "cdTurma",
                table: "Certificados",
                newName: "CdTurma");

            migrationBuilder.RenameColumn(
                name: "cdCertificado",
                table: "Certificados",
                newName: "CdCertificado");

            migrationBuilder.RenameIndex(
                name: "IX_Certificados_cdTurma",
                table: "Certificados",
                newName: "IX_Certificados_CdTurma");

            migrationBuilder.RenameColumn(
                name: "dsCargo",
                table: "Cargos",
                newName: "DsCargo");

            migrationBuilder.RenameColumn(
                name: "cdCargo",
                table: "Cargos",
                newName: "CdCargo");

            migrationBuilder.RenameColumn(
                name: "cdCargo",
                table: "Cargo_Usuarios",
                newName: "CdCargo");

            migrationBuilder.RenameColumn(
                name: "cdUsuario",
                table: "Cargo_Usuarios",
                newName: "CdUsuario");

            migrationBuilder.RenameIndex(
                name: "IX_Cargo_Usuarios_cdCargo",
                table: "Cargo_Usuarios",
                newName: "IX_Cargo_Usuarios_CdCargo");

            migrationBuilder.RenameColumn(
                name: "dtAula",
                table: "Aulas",
                newName: "DtAula");

            migrationBuilder.RenameColumn(
                name: "cdTurma",
                table: "Aulas",
                newName: "CdTurma");

            migrationBuilder.RenameColumn(
                name: "cdAula",
                table: "Aulas",
                newName: "CdAula");

            migrationBuilder.RenameIndex(
                name: "IX_Aulas_cdTurma",
                table: "Aulas",
                newName: "IX_Aulas_CdTurma");

            migrationBuilder.RenameColumn(
                name: "dtNascimentoAluno",
                table: "Alunos",
                newName: "DtNascimentoAluno");

            migrationBuilder.RenameColumn(
                name: "cdAluno",
                table: "Alunos",
                newName: "CdAluno");

            migrationBuilder.AddForeignKey(
                name: "FK_Alunos_Usuarios_CdAluno",
                table: "Alunos",
                column: "CdAluno",
                principalTable: "Usuarios",
                principalColumn: "CdUsuario");

            migrationBuilder.AddForeignKey(
                name: "FK_Aulas_Turmas_CdTurma",
                table: "Aulas",
                column: "CdTurma",
                principalTable: "Turmas",
                principalColumn: "cdTurma",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cargo_Usuarios_Cargos_CdCargo",
                table: "Cargo_Usuarios",
                column: "CdCargo",
                principalTable: "Cargos",
                principalColumn: "CdCargo",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cargo_Usuarios_Usuarios_CdUsuario",
                table: "Cargo_Usuarios",
                column: "CdUsuario",
                principalTable: "Usuarios",
                principalColumn: "CdUsuario",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Certificados_Turmas_CdTurma",
                table: "Certificados",
                column: "CdTurma",
                principalTable: "Turmas",
                principalColumn: "cdTurma",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Conteudos_Aulas_CdAula_CdTurma",
                table: "Conteudos",
                columns: new[] { "CdAula", "CdTurma" },
                principalTable: "Aulas",
                principalColumns: new[] { "CdAula", "CdTurma" },
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Frequencias_Alunos_CdAluno",
                table: "Frequencias",
                column: "CdAluno",
                principalTable: "Alunos",
                principalColumn: "CdAluno",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Frequencias_Aulas_CdAula_CdTurma",
                table: "Frequencias",
                columns: new[] { "CdAula", "CdTurma" },
                principalTable: "Aulas",
                principalColumns: new[] { "CdAula", "CdTurma" },
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Professores_Usuarios_CdProfessor",
                table: "Professores",
                column: "CdProfessor",
                principalTable: "Usuarios",
                principalColumn: "CdUsuario");

            migrationBuilder.AddForeignKey(
                name: "FK_Turma_Alunos_Alunos_CdAluno",
                table: "Turma_Alunos",
                column: "CdAluno",
                principalTable: "Alunos",
                principalColumn: "CdAluno",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Turma_Alunos_Turmas_CdTurma",
                table: "Turma_Alunos",
                column: "CdTurma",
                principalTable: "Turmas",
                principalColumn: "cdTurma",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alunos_Usuarios_CdAluno",
                table: "Alunos");

            migrationBuilder.DropForeignKey(
                name: "FK_Aulas_Turmas_CdTurma",
                table: "Aulas");

            migrationBuilder.DropForeignKey(
                name: "FK_Cargo_Usuarios_Cargos_CdCargo",
                table: "Cargo_Usuarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Cargo_Usuarios_Usuarios_CdUsuario",
                table: "Cargo_Usuarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Certificados_Turmas_CdTurma",
                table: "Certificados");

            migrationBuilder.DropForeignKey(
                name: "FK_Conteudos_Aulas_CdAula_CdTurma",
                table: "Conteudos");

            migrationBuilder.DropForeignKey(
                name: "FK_Frequencias_Alunos_CdAluno",
                table: "Frequencias");

            migrationBuilder.DropForeignKey(
                name: "FK_Frequencias_Aulas_CdAula_CdTurma",
                table: "Frequencias");

            migrationBuilder.DropForeignKey(
                name: "FK_Professores_Usuarios_CdProfessor",
                table: "Professores");

            migrationBuilder.DropForeignKey(
                name: "FK_Turma_Alunos_Alunos_CdAluno",
                table: "Turma_Alunos");

            migrationBuilder.DropForeignKey(
                name: "FK_Turma_Alunos_Turmas_CdTurma",
                table: "Turma_Alunos");

            migrationBuilder.RenameColumn(
                name: "NmUsuario",
                table: "Usuarios",
                newName: "nmUsuario");

            migrationBuilder.RenameColumn(
                name: "DsSenha",
                table: "Usuarios",
                newName: "dsSenha");

            migrationBuilder.RenameColumn(
                name: "DsGenero",
                table: "Usuarios",
                newName: "dsGenero");

            migrationBuilder.RenameColumn(
                name: "DsEmail",
                table: "Usuarios",
                newName: "dsEmail");

            migrationBuilder.RenameColumn(
                name: "DsCpf",
                table: "Usuarios",
                newName: "dsCPF");

            migrationBuilder.RenameColumn(
                name: "CdUsuario",
                table: "Usuarios",
                newName: "cdUsuario");

            migrationBuilder.RenameColumn(
                name: "CdAluno",
                table: "Turma_Alunos",
                newName: "cdAluno");

            migrationBuilder.RenameColumn(
                name: "CdTurma",
                table: "Turma_Alunos",
                newName: "cdTurma");

            migrationBuilder.RenameIndex(
                name: "IX_Turma_Alunos_CdAluno",
                table: "Turma_Alunos",
                newName: "IX_Turma_Alunos_cdAluno");

            migrationBuilder.RenameColumn(
                name: "IcHabilitadoTurma",
                table: "Professores",
                newName: "icHabilitadoTurma");

            migrationBuilder.RenameColumn(
                name: "CdProfessor",
                table: "Professores",
                newName: "cdProfessor");

            migrationBuilder.RenameColumn(
                name: "CdAluno",
                table: "Frequencias",
                newName: "cdAluno");

            migrationBuilder.RenameColumn(
                name: "CdTurma",
                table: "Frequencias",
                newName: "cdTurma");

            migrationBuilder.RenameColumn(
                name: "CdAula",
                table: "Frequencias",
                newName: "cdAula");

            migrationBuilder.RenameIndex(
                name: "IX_Frequencias_CdAluno",
                table: "Frequencias",
                newName: "IX_Frequencias_cdAluno");

            migrationBuilder.RenameColumn(
                name: "QtHoras",
                table: "Cursos",
                newName: "qtHoras");

            migrationBuilder.RenameColumn(
                name: "NmCurso",
                table: "Cursos",
                newName: "nmCurso");

            migrationBuilder.RenameColumn(
                name: "DtFinalizacao",
                table: "Cursos",
                newName: "dtFinalizacao");

            migrationBuilder.RenameColumn(
                name: "DtCriacao",
                table: "Cursos",
                newName: "dtCriacao");

            migrationBuilder.RenameColumn(
                name: "DsCurso",
                table: "Cursos",
                newName: "dsCurso");

            migrationBuilder.RenameColumn(
                name: "CdCurso",
                table: "Cursos",
                newName: "cdCurso");

            migrationBuilder.RenameColumn(
                name: "NmArquivo",
                table: "Conteudos",
                newName: "nmArquivo");

            migrationBuilder.RenameColumn(
                name: "DsExtencao",
                table: "Conteudos",
                newName: "dsExtencao");

            migrationBuilder.RenameColumn(
                name: "DsConteudo",
                table: "Conteudos",
                newName: "dsConteudo");

            migrationBuilder.RenameColumn(
                name: "CdTurma",
                table: "Conteudos",
                newName: "cdTurma");

            migrationBuilder.RenameColumn(
                name: "CdAula",
                table: "Conteudos",
                newName: "cdAula");

            migrationBuilder.RenameColumn(
                name: "CdConteudo",
                table: "Conteudos",
                newName: "cdConteudo");

            migrationBuilder.RenameIndex(
                name: "IX_Conteudos_CdAula_CdTurma",
                table: "Conteudos",
                newName: "IX_Conteudos_cdAula_cdTurma");

            migrationBuilder.RenameColumn(
                name: "NmArquivo",
                table: "Certificados",
                newName: "nmArquivo");

            migrationBuilder.RenameColumn(
                name: "DsExtensao",
                table: "Certificados",
                newName: "dsExtensao");

            migrationBuilder.RenameColumn(
                name: "CdTurma",
                table: "Certificados",
                newName: "cdTurma");

            migrationBuilder.RenameColumn(
                name: "CdCertificado",
                table: "Certificados",
                newName: "cdCertificado");

            migrationBuilder.RenameIndex(
                name: "IX_Certificados_CdTurma",
                table: "Certificados",
                newName: "IX_Certificados_cdTurma");

            migrationBuilder.RenameColumn(
                name: "DsCargo",
                table: "Cargos",
                newName: "dsCargo");

            migrationBuilder.RenameColumn(
                name: "CdCargo",
                table: "Cargos",
                newName: "cdCargo");

            migrationBuilder.RenameColumn(
                name: "CdCargo",
                table: "Cargo_Usuarios",
                newName: "cdCargo");

            migrationBuilder.RenameColumn(
                name: "CdUsuario",
                table: "Cargo_Usuarios",
                newName: "cdUsuario");

            migrationBuilder.RenameIndex(
                name: "IX_Cargo_Usuarios_CdCargo",
                table: "Cargo_Usuarios",
                newName: "IX_Cargo_Usuarios_cdCargo");

            migrationBuilder.RenameColumn(
                name: "DtAula",
                table: "Aulas",
                newName: "dtAula");

            migrationBuilder.RenameColumn(
                name: "CdTurma",
                table: "Aulas",
                newName: "cdTurma");

            migrationBuilder.RenameColumn(
                name: "CdAula",
                table: "Aulas",
                newName: "cdAula");

            migrationBuilder.RenameIndex(
                name: "IX_Aulas_CdTurma",
                table: "Aulas",
                newName: "IX_Aulas_cdTurma");

            migrationBuilder.RenameColumn(
                name: "DtNascimentoAluno",
                table: "Alunos",
                newName: "dtNascimentoAluno");

            migrationBuilder.RenameColumn(
                name: "CdAluno",
                table: "Alunos",
                newName: "cdAluno");

            migrationBuilder.AddForeignKey(
                name: "FK_Alunos_Usuarios_cdAluno",
                table: "Alunos",
                column: "cdAluno",
                principalTable: "Usuarios",
                principalColumn: "cdUsuario");

            migrationBuilder.AddForeignKey(
                name: "FK_Aulas_Turmas_cdTurma",
                table: "Aulas",
                column: "cdTurma",
                principalTable: "Turmas",
                principalColumn: "cdTurma",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cargo_Usuarios_Cargos_cdCargo",
                table: "Cargo_Usuarios",
                column: "cdCargo",
                principalTable: "Cargos",
                principalColumn: "cdCargo",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cargo_Usuarios_Usuarios_cdUsuario",
                table: "Cargo_Usuarios",
                column: "cdUsuario",
                principalTable: "Usuarios",
                principalColumn: "cdUsuario",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Certificados_Turmas_cdTurma",
                table: "Certificados",
                column: "cdTurma",
                principalTable: "Turmas",
                principalColumn: "cdTurma",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Conteudos_Aulas_cdAula_cdTurma",
                table: "Conteudos",
                columns: new[] { "cdAula", "cdTurma" },
                principalTable: "Aulas",
                principalColumns: new[] { "cdAula", "cdTurma" },
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Frequencias_Alunos_cdAluno",
                table: "Frequencias",
                column: "cdAluno",
                principalTable: "Alunos",
                principalColumn: "cdAluno",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Frequencias_Aulas_cdAula_cdTurma",
                table: "Frequencias",
                columns: new[] { "cdAula", "cdTurma" },
                principalTable: "Aulas",
                principalColumns: new[] { "cdAula", "cdTurma" },
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Professores_Usuarios_cdProfessor",
                table: "Professores",
                column: "cdProfessor",
                principalTable: "Usuarios",
                principalColumn: "cdUsuario");

            migrationBuilder.AddForeignKey(
                name: "FK_Turma_Alunos_Alunos_cdAluno",
                table: "Turma_Alunos",
                column: "cdAluno",
                principalTable: "Alunos",
                principalColumn: "cdAluno",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Turma_Alunos_Turmas_cdTurma",
                table: "Turma_Alunos",
                column: "cdTurma",
                principalTable: "Turmas",
                principalColumn: "cdTurma",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
