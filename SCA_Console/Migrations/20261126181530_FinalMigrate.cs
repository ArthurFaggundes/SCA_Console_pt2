using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SCA_Console.Migrations
{
    /// <inheritdoc />
    public partial class FinalMigrate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alunos",
                columns: table => new
                {
                    idAluno = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    numCredAtuais = table.Column<int>(type: "int", nullable: false),
                    Excluido = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alunos", x => x.idAluno);
                });

            migrationBuilder.CreateTable(
                name: "Disciplinas",
                columns: table => new
                {
                    idDisciplina = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Excluido = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disciplinas", x => x.idDisciplina);
                });

            migrationBuilder.CreateTable(
                name: "Professores",
                columns: table => new
                {
                    idProfessor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Excluido = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professores", x => x.idProfessor);
                });

            migrationBuilder.CreateTable(
                name: "Turmas",
                columns: table => new
                {
                    idTurma = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    local = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    aberta = table.Column<bool>(type: "bit", nullable: false),
                    disciplinaidDisciplina = table.Column<int>(type: "int", nullable: true),
                    professoridProfessor = table.Column<int>(type: "int", nullable: true),
                    Excluida = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turmas", x => x.idTurma);
                    table.ForeignKey(
                        name: "FK_Turmas_Disciplinas_disciplinaidDisciplina",
                        column: x => x.disciplinaidDisciplina,
                        principalTable: "Disciplinas",
                        principalColumn: "idDisciplina");
                    table.ForeignKey(
                        name: "FK_Turmas_Professores_professoridProfessor",
                        column: x => x.professoridProfessor,
                        principalTable: "Professores",
                        principalColumn: "idProfessor");
                });

            migrationBuilder.CreateTable(
                name: "AlunoTurma",
                columns: table => new
                {
                    alunosidAluno = table.Column<int>(type: "int", nullable: false),
                    turmasidTurma = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlunoTurma", x => new { x.alunosidAluno, x.turmasidTurma });
                    table.ForeignKey(
                        name: "FK_AlunoTurma_Alunos_alunosidAluno",
                        column: x => x.alunosidAluno,
                        principalTable: "Alunos",
                        principalColumn: "idAluno",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlunoTurma_Turmas_turmasidTurma",
                        column: x => x.turmasidTurma,
                        principalTable: "Turmas",
                        principalColumn: "idTurma",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlunoTurma_turmasidTurma",
                table: "AlunoTurma",
                column: "turmasidTurma");

            migrationBuilder.CreateIndex(
                name: "IX_Turmas_disciplinaidDisciplina",
                table: "Turmas",
                column: "disciplinaidDisciplina");

            migrationBuilder.CreateIndex(
                name: "IX_Turmas_professoridProfessor",
                table: "Turmas",
                column: "professoridProfessor");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlunoTurma");

            migrationBuilder.DropTable(
                name: "Alunos");

            migrationBuilder.DropTable(
                name: "Turmas");

            migrationBuilder.DropTable(
                name: "Disciplinas");

            migrationBuilder.DropTable(
                name: "Professores");
        }
    }
}
