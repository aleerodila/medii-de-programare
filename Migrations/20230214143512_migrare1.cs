using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Salon.Migrations
{
    public partial class migrare1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orar",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Numeorar = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orar", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Profesionist",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prenume = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profesionist", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Serviciu",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Numeserviciu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pret = table.Column<decimal>(type: "decimal(6,2)", nullable: false),
                    OrarID = table.Column<int>(type: "int", nullable: true),
                    ProfesionistID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Serviciu", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Serviciu_Orar_OrarID",
                        column: x => x.OrarID,
                        principalTable: "Orar",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Serviciu_Profesionist_ProfesionistID",
                        column: x => x.ProfesionistID,
                        principalTable: "Profesionist",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Serviciu_OrarID",
                table: "Serviciu",
                column: "OrarID");

            migrationBuilder.CreateIndex(
                name: "IX_Serviciu_ProfesionistID",
                table: "Serviciu",
                column: "ProfesionistID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Serviciu");

            migrationBuilder.DropTable(
                name: "Orar");

            migrationBuilder.DropTable(
                name: "Profesionist");
        }
    }
}
