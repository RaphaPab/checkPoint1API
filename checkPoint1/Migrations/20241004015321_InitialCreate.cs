using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace checkPoint1.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_PACIENTE_CP",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NomeCompleto = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "DATE", nullable: false),
                    CPF = table.Column<string>(type: "NVARCHAR2(11)", maxLength: 11, nullable: false),
                    Endereco = table.Column<string>(type: "NVARCHAR2(200)", maxLength: 200, nullable: false),
                    Telefone = table.Column<string>(type: "NVARCHAR2(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_PACIENTE_CP", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_PLANO_SAUDE_CP",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NomePlano = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    Cobertura = table.Column<string>(type: "NVARCHAR2(200)", maxLength: 200, nullable: false),
                    PacienteId = table.Column<int>(type: "NUMBER(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_PLANO_SAUDE_CP", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_PLANO_SAUDE_CP_TB_PACIENTE_CP_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "TB_PACIENTE_CP",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TB_PACIENTE_PLANO_CP",
                columns: table => new
                {
                    PacienteId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    PlanoSaudeId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_PACIENTE_PLANO_CP", x => new { x.PacienteId, x.PlanoSaudeId });
                    table.ForeignKey(
                        name: "FK_TB_PACIENTE_PLANO_CP_TB_PACIENTE_CP_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "TB_PACIENTE_CP",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_PACIENTE_PLANO_CP_TB_PLANO_SAUDE_CP_PlanoSaudeId",
                        column: x => x.PlanoSaudeId,
                        principalTable: "TB_PLANO_SAUDE_CP",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "TB_PACIENTE_CP",
                columns: new[] { "Id", "CPF", "DataNascimento", "Endereco", "NomeCompleto", "Telefone" },
                values: new object[] { 1, "123456789", new DateTime(2024, 10, 3, 22, 53, 20, 796, DateTimeKind.Local).AddTicks(8127), "endereço inicial", "Paciente Inicial", "123456789" });

            migrationBuilder.InsertData(
                table: "TB_PLANO_SAUDE_CP",
                columns: new[] { "Id", "Cobertura", "NomePlano", "PacienteId" },
                values: new object[] { 1, "Cobertura Inicial", "Plano Inicial", null });

            migrationBuilder.InsertData(
                table: "TB_PACIENTE_PLANO_CP",
                columns: new[] { "PacienteId", "PlanoSaudeId" },
                values: new object[] { 1, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_TB_PACIENTE_PLANO_CP_PlanoSaudeId",
                table: "TB_PACIENTE_PLANO_CP",
                column: "PlanoSaudeId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_PLANO_SAUDE_CP_PacienteId",
                table: "TB_PLANO_SAUDE_CP",
                column: "PacienteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_PACIENTE_PLANO_CP");

            migrationBuilder.DropTable(
                name: "TB_PLANO_SAUDE_CP");

            migrationBuilder.DropTable(
                name: "TB_PACIENTE_CP");
        }
    }
}
