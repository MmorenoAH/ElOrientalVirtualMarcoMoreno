using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ElOrientalVirtualMarcoMoreno.Migrations
{
    public partial class _26022022 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "IdPropietario",
                table: "ModuloVirtual",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.CreateTable(
                name: "Propietario",
                columns: table => new
                {
                    IdPropietario = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombrePropietario = table.Column<string>(maxLength: 50, nullable: false),
                    FechaCeacion = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Propietario", x => x.IdPropietario);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ModuloVirtual_IdPropietario",
                table: "ModuloVirtual",
                column: "IdPropietario");

            migrationBuilder.AddForeignKey(
                name: "FK_ModuloVirtual_Propietario_IdPropietario",
                table: "ModuloVirtual",
                column: "IdPropietario",
                principalTable: "Propietario",
                principalColumn: "IdPropietario",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ModuloVirtual_Propietario_IdPropietario",
                table: "ModuloVirtual");

            migrationBuilder.DropTable(
                name: "Propietario");

            migrationBuilder.DropIndex(
                name: "IX_ModuloVirtual_IdPropietario",
                table: "ModuloVirtual");

            migrationBuilder.AlterColumn<string>(
                name: "IdPropietario",
                table: "ModuloVirtual",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(int));
        }
    }
}
