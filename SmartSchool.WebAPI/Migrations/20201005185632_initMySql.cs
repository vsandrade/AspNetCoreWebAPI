using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartSchool.WebAPI.Migrations
{
    public partial class initMySql : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alunos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Matricula = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    Sobrenome = table.Column<string>(nullable: true),
                    Telefone = table.Column<string>(nullable: true),
                    DataNasc = table.Column<DateTime>(nullable: false),
                    DataIni = table.Column<DateTime>(nullable: false),
                    DataFim = table.Column<DateTime>(nullable: true),
                    Ativo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alunos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cursos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cursos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Professores",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Registro = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    Sobrenome = table.Column<string>(nullable: true),
                    Telefone = table.Column<string>(nullable: true),
                    DataIni = table.Column<DateTime>(nullable: false),
                    DataFim = table.Column<DateTime>(nullable: true),
                    Ativo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AlunosCursos",
                columns: table => new
                {
                    AlunoId = table.Column<int>(nullable: false),
                    CursoId = table.Column<int>(nullable: false),
                    DataIni = table.Column<DateTime>(nullable: false),
                    DataFim = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlunosCursos", x => new { x.AlunoId, x.CursoId });
                    table.ForeignKey(
                        name: "FK_AlunosCursos_Alunos_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Alunos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlunosCursos_Cursos_CursoId",
                        column: x => x.CursoId,
                        principalTable: "Cursos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Disciplinas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true),
                    CargaHoraria = table.Column<int>(nullable: false),
                    PrerequisitoId = table.Column<int>(nullable: true),
                    ProfessorId = table.Column<int>(nullable: false),
                    CursoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disciplinas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Disciplinas_Cursos_CursoId",
                        column: x => x.CursoId,
                        principalTable: "Cursos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Disciplinas_Disciplinas_PrerequisitoId",
                        column: x => x.PrerequisitoId,
                        principalTable: "Disciplinas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Disciplinas_Professores_ProfessorId",
                        column: x => x.ProfessorId,
                        principalTable: "Professores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AlunosDisciplinas",
                columns: table => new
                {
                    AlunoId = table.Column<int>(nullable: false),
                    DisciplinaId = table.Column<int>(nullable: false),
                    DataIni = table.Column<DateTime>(nullable: false),
                    DataFim = table.Column<DateTime>(nullable: true),
                    Nota = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlunosDisciplinas", x => new { x.AlunoId, x.DisciplinaId });
                    table.ForeignKey(
                        name: "FK_AlunosDisciplinas_Alunos_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Alunos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlunosDisciplinas_Disciplinas_DisciplinaId",
                        column: x => x.DisciplinaId,
                        principalTable: "Disciplinas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "Id", "Ativo", "DataFim", "DataIni", "DataNasc", "Matricula", "Nome", "Sobrenome", "Telefone" },
                values: new object[,]
                {
                    { 1, true, null, new DateTime(2020, 10, 5, 15, 56, 31, 871, DateTimeKind.Local).AddTicks(4940), new DateTime(2005, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Marta", "Kent", "33225555" },
                    { 2, true, null, new DateTime(2020, 10, 5, 15, 56, 31, 871, DateTimeKind.Local).AddTicks(7970), new DateTime(2005, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Paula", "Isabela", "3354288" },
                    { 3, true, null, new DateTime(2020, 10, 5, 15, 56, 31, 871, DateTimeKind.Local).AddTicks(8040), new DateTime(2005, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Laura", "Antonia", "55668899" },
                    { 4, true, null, new DateTime(2020, 10, 5, 15, 56, 31, 871, DateTimeKind.Local).AddTicks(8050), new DateTime(2005, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Luiza", "Maria", "6565659" },
                    { 5, true, null, new DateTime(2020, 10, 5, 15, 56, 31, 871, DateTimeKind.Local).AddTicks(8060), new DateTime(2005, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "Lucas", "Machado", "565685415" },
                    { 6, true, null, new DateTime(2020, 10, 5, 15, 56, 31, 871, DateTimeKind.Local).AddTicks(8080), new DateTime(2005, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, "Pedro", "Alvares", "456454545" },
                    { 7, true, null, new DateTime(2020, 10, 5, 15, 56, 31, 871, DateTimeKind.Local).AddTicks(8080), new DateTime(2005, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, "Paulo", "José", "9874512" }
                });

            migrationBuilder.InsertData(
                table: "Cursos",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { 1, "Tecnologia da Informação" },
                    { 2, "Sistemas de Informação" },
                    { 3, "Ciência da Computação" }
                });

            migrationBuilder.InsertData(
                table: "Professores",
                columns: new[] { "Id", "Ativo", "DataFim", "DataIni", "Nome", "Registro", "Sobrenome", "Telefone" },
                values: new object[,]
                {
                    { 1, true, null, new DateTime(2020, 10, 5, 15, 56, 31, 849, DateTimeKind.Local).AddTicks(2120), "Lauro", 1, "Oliveira", null },
                    { 2, true, null, new DateTime(2020, 10, 5, 15, 56, 31, 868, DateTimeKind.Local).AddTicks(6310), "Roberto", 2, "Soares", null },
                    { 3, true, null, new DateTime(2020, 10, 5, 15, 56, 31, 868, DateTimeKind.Local).AddTicks(6390), "Ronaldo", 3, "Marconi", null },
                    { 4, true, null, new DateTime(2020, 10, 5, 15, 56, 31, 868, DateTimeKind.Local).AddTicks(6390), "Rodrigo", 4, "Carvalho", null },
                    { 5, true, null, new DateTime(2020, 10, 5, 15, 56, 31, 868, DateTimeKind.Local).AddTicks(6390), "Alexandre", 5, "Montanha", null }
                });

            migrationBuilder.InsertData(
                table: "Disciplinas",
                columns: new[] { "Id", "CargaHoraria", "CursoId", "Nome", "PrerequisitoId", "ProfessorId" },
                values: new object[,]
                {
                    { 1, 0, 1, "Matemática", null, 1 },
                    { 2, 0, 3, "Matemática", null, 1 },
                    { 3, 0, 3, "Física", null, 2 },
                    { 4, 0, 1, "Português", null, 3 },
                    { 5, 0, 1, "Inglês", null, 4 },
                    { 6, 0, 2, "Inglês", null, 4 },
                    { 7, 0, 3, "Inglês", null, 4 },
                    { 8, 0, 1, "Programação", null, 5 },
                    { 9, 0, 2, "Programação", null, 5 },
                    { 10, 0, 3, "Programação", null, 5 }
                });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataIni", "Nota" },
                values: new object[,]
                {
                    { 2, 1, null, new DateTime(2020, 10, 5, 15, 56, 31, 872, DateTimeKind.Local).AddTicks(710), null },
                    { 4, 5, null, new DateTime(2020, 10, 5, 15, 56, 31, 872, DateTimeKind.Local).AddTicks(730), null },
                    { 2, 5, null, new DateTime(2020, 10, 5, 15, 56, 31, 872, DateTimeKind.Local).AddTicks(720), null },
                    { 1, 5, null, new DateTime(2020, 10, 5, 15, 56, 31, 872, DateTimeKind.Local).AddTicks(700), null },
                    { 7, 4, null, new DateTime(2020, 10, 5, 15, 56, 31, 872, DateTimeKind.Local).AddTicks(760), null },
                    { 6, 4, null, new DateTime(2020, 10, 5, 15, 56, 31, 872, DateTimeKind.Local).AddTicks(750), null },
                    { 5, 4, null, new DateTime(2020, 10, 5, 15, 56, 31, 872, DateTimeKind.Local).AddTicks(740), null },
                    { 4, 4, null, new DateTime(2020, 10, 5, 15, 56, 31, 872, DateTimeKind.Local).AddTicks(730), null },
                    { 1, 4, null, new DateTime(2020, 10, 5, 15, 56, 31, 872, DateTimeKind.Local).AddTicks(670), null },
                    { 7, 3, null, new DateTime(2020, 10, 5, 15, 56, 31, 872, DateTimeKind.Local).AddTicks(760), null },
                    { 5, 5, null, new DateTime(2020, 10, 5, 15, 56, 31, 872, DateTimeKind.Local).AddTicks(740), null },
                    { 6, 3, null, new DateTime(2020, 10, 5, 15, 56, 31, 872, DateTimeKind.Local).AddTicks(750), null },
                    { 7, 2, null, new DateTime(2020, 10, 5, 15, 56, 31, 872, DateTimeKind.Local).AddTicks(750), null },
                    { 6, 2, null, new DateTime(2020, 10, 5, 15, 56, 31, 872, DateTimeKind.Local).AddTicks(740), null },
                    { 3, 2, null, new DateTime(2020, 10, 5, 15, 56, 31, 872, DateTimeKind.Local).AddTicks(720), null },
                    { 2, 2, null, new DateTime(2020, 10, 5, 15, 56, 31, 872, DateTimeKind.Local).AddTicks(710), null },
                    { 1, 2, null, new DateTime(2020, 10, 5, 15, 56, 31, 871, DateTimeKind.Local).AddTicks(9800), null },
                    { 7, 1, null, new DateTime(2020, 10, 5, 15, 56, 31, 872, DateTimeKind.Local).AddTicks(750), null },
                    { 6, 1, null, new DateTime(2020, 10, 5, 15, 56, 31, 872, DateTimeKind.Local).AddTicks(740), null },
                    { 4, 1, null, new DateTime(2020, 10, 5, 15, 56, 31, 872, DateTimeKind.Local).AddTicks(730), null },
                    { 3, 1, null, new DateTime(2020, 10, 5, 15, 56, 31, 872, DateTimeKind.Local).AddTicks(720), null },
                    { 3, 3, null, new DateTime(2020, 10, 5, 15, 56, 31, 872, DateTimeKind.Local).AddTicks(730), null },
                    { 7, 5, null, new DateTime(2020, 10, 5, 15, 56, 31, 872, DateTimeKind.Local).AddTicks(760), null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlunosCursos_CursoId",
                table: "AlunosCursos",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_AlunosDisciplinas_DisciplinaId",
                table: "AlunosDisciplinas",
                column: "DisciplinaId");

            migrationBuilder.CreateIndex(
                name: "IX_Disciplinas_CursoId",
                table: "Disciplinas",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_Disciplinas_PrerequisitoId",
                table: "Disciplinas",
                column: "PrerequisitoId");

            migrationBuilder.CreateIndex(
                name: "IX_Disciplinas_ProfessorId",
                table: "Disciplinas",
                column: "ProfessorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlunosCursos");

            migrationBuilder.DropTable(
                name: "AlunosDisciplinas");

            migrationBuilder.DropTable(
                name: "Alunos");

            migrationBuilder.DropTable(
                name: "Disciplinas");

            migrationBuilder.DropTable(
                name: "Cursos");

            migrationBuilder.DropTable(
                name: "Professores");
        }
    }
}
