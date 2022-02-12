using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ElOrientalVirtualMarcoMoreno.Migrations
{
    public partial class migracionRelac : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ModuloVirtual",
                columns: table => new
                {
                    IdModulo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPropietario = table.Column<string>(maxLength: 20, nullable: false),
                    DescripcionModulo = table.Column<string>(maxLength: 500, nullable: false),
                    FechaCreacion = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModuloVirtual", x => x.IdModulo);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ModuloVirtual");
        }
    }
}
