using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ElOrientalVirtualMarcoMoreno.Migrations
{
    public partial class _2432022 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "NombrePropietario",
                table: "ModuloVirtual",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NombrePropietario",
                table: "ModuloVirtual");

            migrationBuilder.AlterColumn<int>(
                name: "IdPropietario",
                table: "ModuloVirtual",
                type: "int",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.CreateTable(
                name: "Propietario",
                columns: table => new
                {
                    IdPropietario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaCeacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NombrePropietario = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
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
    }
}
