using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Shop.Web1.Data.Migrations
{
    public partial class InitialDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PrimerApellido",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SegundoApellido",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "paises",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_paises", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "productos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(maxLength: 50, nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ImageUrl = table.Column<string>(nullable: true),
                    UltComp = table.Column<DateTime>(nullable: true),
                    UltVent = table.Column<DateTime>(nullable: true),
                    Disponi = table.Column<bool>(nullable: false),
                    Stock = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UsuariosId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_productos_AspNetUsers_UsuariosId",
                        column: x => x.UsuariosId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_productos_UsuariosId",
                table: "productos",
                column: "UsuariosId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "paises");

            migrationBuilder.DropTable(
                name: "productos");

            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PrimerApellido",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "SegundoApellido",
                table: "AspNetUsers");
        }
    }
}
