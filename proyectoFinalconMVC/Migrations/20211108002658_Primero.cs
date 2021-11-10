using Microsoft.EntityFrameworkCore.Migrations;

namespace proyectoFinalconMVC.Migrations
{
    public partial class Primero : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alumnos",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    alias = table.Column<string>(maxLength: 10, nullable: false),
                    nombreCompleto = table.Column<string>(nullable: false),
                    dni = table.Column<long>(nullable: false),
                    mail = table.Column<string>(nullable: false),
                    edad = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alumnos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Cursos",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(nullable: false),
                    categoria = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cursos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "InscripcionAlumno",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDalumno = table.Column<int>(nullable: false),
                    IDcurso = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InscripcionAlumno", x => x.id);
                    table.ForeignKey(
                        name: "FK_InscripcionAlumno_Alumnos_IDalumno",
                        column: x => x.IDalumno,
                        principalTable: "Alumnos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InscripcionAlumno_Cursos_IDcurso",
                        column: x => x.IDcurso,
                        principalTable: "Cursos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alumnos_dni",
                table: "Alumnos",
                column: "dni",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InscripcionAlumno_IDalumno",
                table: "InscripcionAlumno",
                column: "IDalumno");

            migrationBuilder.CreateIndex(
                name: "IX_InscripcionAlumno_IDcurso",
                table: "InscripcionAlumno",
                column: "IDcurso");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InscripcionAlumno");

            migrationBuilder.DropTable(
                name: "Alumnos");

            migrationBuilder.DropTable(
                name: "Cursos");
        }
    }
}
