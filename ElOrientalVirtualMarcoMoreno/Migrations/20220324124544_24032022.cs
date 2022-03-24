using Microsoft.EntityFrameworkCore.Migrations;

namespace ElOrientalVirtualMarcoMoreno.Migrations
{
    public partial class _24032022 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdModulo",
                table: "Producto",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Producto_IdModulo",
                table: "Producto",
                column: "IdModulo");

            migrationBuilder.AddForeignKey(
                name: "FK_Producto_ModuloVirtual_IdModulo",
                table: "Producto",
                column: "IdModulo",
                principalTable: "ModuloVirtual",
                principalColumn: "IdModulo",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Producto_ModuloVirtual_IdModulo",
                table: "Producto");

            migrationBuilder.DropIndex(
                name: "IX_Producto_IdModulo",
                table: "Producto");

            migrationBuilder.DropColumn(
                name: "IdModulo",
                table: "Producto");
        }
    }
}
