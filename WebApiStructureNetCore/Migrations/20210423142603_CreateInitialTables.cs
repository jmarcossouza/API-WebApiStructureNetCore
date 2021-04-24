using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiStructureNetCore.Migrations
{
    public partial class CreateInitialTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "varchar(254)", maxLength: 254, nullable: false),
                    Senha = table.Column<string>(type: "varchar(84)", maxLength: 84, nullable: false),
                    Nome = table.Column<string>(type: "varchar(35)", maxLength: 35, nullable: false),
                    Sobrenome = table.Column<string>(type: "varchar(35)", maxLength: 35, nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "datetime2(0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LogErrors",
                columns: table => new
                {
                    Id = table.Column<string>(type: "char(36)", maxLength: 36, nullable: false),
                    Tipo = table.Column<short>(type: "smallint", nullable: false),
                    UsuarioId = table.Column<long>(type: "bigint", nullable: true),
                    Resolvido = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Erro = table.Column<string>(type: "varchar(8000)", maxLength: 8000, nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "datetime2(0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogErrors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LogErrors_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LogErrors_UsuarioId",
                table: "LogErrors",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Email",
                table: "Usuarios",
                column: "Email",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LogErrors");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
