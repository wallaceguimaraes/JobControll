using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace api.Migrations
{
    public partial class AddCreateInitialTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "cadastro");

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
                name: "Usuario",
                schema: "cadastro",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Salt = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Login = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UltimaAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tarefa",
                schema: "cadastro",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    IdProjeto = table.Column<int>(type: "int", nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true),
                    Descricao = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UltimaAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tarefa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tarefa_Projeto_IdProjeto",
                        column: x => x.IdProjeto,
                        principalSchema: "cadastro",
                        principalTable: "Projeto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tarefa_Usuario_IdUsuario",
                        column: x => x.IdUsuario,
                        principalSchema: "cadastro",
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    IdTarefa = table.Column<int>(type: "int", nullable: false),
                    DataInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataFim = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tempo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tempo_Tarefa_IdTarefa",
                        column: x => x.IdTarefa,
                        principalSchema: "cadastro",
                        principalTable: "Tarefa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TempoTrabalhado",
                schema: "cadastro",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdProjeto = table.Column<int>(type: "int", nullable: true),
                    IdTarefa = table.Column<int>(type: "int", nullable: true),
                    Horas = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Dias = table.Column<int>(type: "int", nullable: true),
                    Meses = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TempoTrabalhado", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TempoTrabalhado_Projeto_IdProjeto",
                        column: x => x.IdProjeto,
                        principalSchema: "cadastro",
                        principalTable: "Projeto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TempoTrabalhado_Tarefa_IdTarefa",
                        column: x => x.IdTarefa,
                        principalSchema: "cadastro",
                        principalTable: "Tarefa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tarefa_IdProjeto",
                schema: "cadastro",
                table: "Tarefa",
                column: "IdProjeto");

            migrationBuilder.CreateIndex(
                name: "IX_Tarefa_IdUsuario",
                schema: "cadastro",
                table: "Tarefa",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Tempo_IdTarefa",
                schema: "cadastro",
                table: "Tempo",
                column: "IdTarefa");

            migrationBuilder.CreateIndex(
                name: "IX_TempoTrabalhado_IdProjeto",
                schema: "cadastro",
                table: "TempoTrabalhado",
                column: "IdProjeto",
                unique: true,
                filter: "[IdProjeto] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_TempoTrabalhado_IdTarefa",
                schema: "cadastro",
                table: "TempoTrabalhado",
                column: "IdTarefa",
                unique: true,
                filter: "[IdTarefa] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_Email",
                schema: "cadastro",
                table: "Usuario",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_Login",
                schema: "cadastro",
                table: "Usuario",
                column: "Login");

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
                name: "TempoTrabalhado",
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

            migrationBuilder.DropTable(
                name: "Usuario",
                schema: "cadastro");
        }
    }
}
