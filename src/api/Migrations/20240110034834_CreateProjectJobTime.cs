using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace api.Migrations
{
    public partial class CreateProjectJobTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Projeto",
                schema: "cadastro",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true),
                    Descricao = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UltimaAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projeto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tarefa",
                schema: "cadastro",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true),
                    Descricao = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UltimaAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tarefa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tarefa_Projeto_ProjectId",
                        column: x => x.ProjectId,
                        principalSchema: "cadastro",
                        principalTable: "Projeto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tarefa_Usuario_UserId",
                        column: x => x.UserId,
                        principalSchema: "cadastro",
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioProjeto",
                schema: "cadastro",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioProjeto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsuarioProjeto_Projeto_ProjectId",
                        column: x => x.ProjectId,
                        principalSchema: "cadastro",
                        principalTable: "Projeto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsuarioProjeto_Usuario_UserId",
                        column: x => x.UserId,
                        principalSchema: "cadastro",
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tempo",
                schema: "cadastro",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobId = table.Column<int>(type: "int", nullable: false),
                    DataInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataFim = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tempo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tempo_Tarefa_JobId",
                        column: x => x.JobId,
                        principalSchema: "cadastro",
                        principalTable: "Tarefa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tarefa_ProjectId",
                schema: "cadastro",
                table: "Tarefa",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Tarefa_UserId",
                schema: "cadastro",
                table: "Tarefa",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Tempo_JobId",
                schema: "cadastro",
                table: "Tempo",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioProjeto_ProjectId",
                schema: "cadastro",
                table: "UsuarioProjeto",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioProjeto_UserId",
                schema: "cadastro",
                table: "UsuarioProjeto",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tempo",
                schema: "cadastro");

            migrationBuilder.DropTable(
                name: "UsuarioProjeto",
                schema: "cadastro");

            migrationBuilder.DropTable(
                name: "Tarefa",
                schema: "cadastro");

            migrationBuilder.DropTable(
                name: "Projeto",
                schema: "cadastro");
        }
    }
}
