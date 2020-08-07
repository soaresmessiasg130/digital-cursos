using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace DigitalCursos.Api.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DCCurso",
                columns: table => new
                {
                    CursoId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CursoNome = table.Column<string>(maxLength: 150, nullable: true),
                    Descricao = table.Column<string>(maxLength: 250, nullable: true),
                    CargaHoraria = table.Column<int>(nullable: false),
                    Inicio = table.Column<DateTime>(nullable: false),
                    Preco = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Logo = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DCCurso", x => x.CursoId);
                });

            migrationBuilder.CreateTable(
                name: "DCAluno",
                columns: table => new
                {
                    AlunoId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(maxLength: 150, nullable: true),
                    Sobrenome = table.Column<string>(maxLength: 100, nullable: true),
                    Email = table.Column<string>(maxLength: 100, nullable: true),
                    Nascimento = table.Column<DateTime>(nullable: false),
                    Foto = table.Column<byte[]>(nullable: true),
                    Genero = table.Column<int>(nullable: false),
                    CursoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DCAluno", x => x.AlunoId);
                    table.ForeignKey(
                        name: "FK_DCAluno_DCCurso_CursoId",
                        column: x => x.CursoId,
                        principalTable: "DCCurso",
                        principalColumn: "CursoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "DCCurso",
                columns: new[] { "CursoId", "CargaHoraria", "CursoNome", "Descricao", "Inicio", "Logo", "Preco" },
                values: new object[,]
                {
                    { 1, 40, "ADS", null, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 180.00m },
                    { 2, 44, "Redes", null, new DateTime(2020, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 200.00m },
                    { 3, 60, "Engenharia TI", null, new DateTime(2020, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 330.00m }
                });

            migrationBuilder.InsertData(
                table: "DCAluno",
                columns: new[] { "AlunoId", "CursoId", "Email", "Foto", "Genero", "Nascimento", "Nome", "Sobrenome" },
                values: new object[,]
                {
                    { 1, 1, "soaresmessiasg130@gmail.com", null, 0, new DateTime(1997, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Messias Soares", "Paiva" },
                    { 2, 2, "soaresmessiasg130@gmail.com", null, 0, new DateTime(1997, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Messias Soares", "Paiva" },
                    { 3, 3, "soaresmessiasg130@gmail.com", null, 0, new DateTime(1997, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Messias Soares", "Paiva" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DCAluno_CursoId",
                table: "DCAluno",
                column: "CursoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DCAluno");

            migrationBuilder.DropTable(
                name: "DCCurso");
        }
    }
}
