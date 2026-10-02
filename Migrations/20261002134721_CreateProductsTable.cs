using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PucPoc.Migrations
{
    /// <inheritdoc />
    public partial class CreateProductsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Mentorias",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_Mentorando = table.Column<int>(type: "int", nullable: false),
                    ID_Mentor = table.Column<int>(type: "int", nullable: false),
                    ID_Material_De_Apoio = table.Column<int>(type: "int", nullable: false),
                    ID_Anotacao = table.Column<int>(type: "int", nullable: false),
                    Horario_Inicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Horario_Fim = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mentorias", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Mentorias");
        }
    }
}
