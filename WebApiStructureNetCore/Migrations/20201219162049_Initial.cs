using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiStructureNetCore.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(128)", nullable: false),
                    Email = table.Column<string>(type: "varchar(254)", nullable: false),
                    Senha = table.Column<string>(type: "varchar(128)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(35)", nullable: false),
                    Sobrenome = table.Column<string>(type: "nvarchar(35)", nullable: false),
                    CriadoEm = table.Column<string>(type: "smalldatetime", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
