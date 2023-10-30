using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RedoMusic.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_1_create_tables_database : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Instruments_Brands_brandId",
                table: "Instruments");

            migrationBuilder.RenameColumn(
                name: "brandId",
                table: "Instruments",
                newName: "BrandId");

            migrationBuilder.RenameIndex(
                name: "IX_Instruments_brandId",
                table: "Instruments",
                newName: "IX_Instruments_BrandId");

            migrationBuilder.AddColumn<string>(
                name: "Barcode",
                table: "Instruments",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Instruments_Brands_BrandId",
                table: "Instruments",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Instruments_Brands_BrandId",
                table: "Instruments");

            migrationBuilder.DropColumn(
                name: "Barcode",
                table: "Instruments");

            migrationBuilder.RenameColumn(
                name: "BrandId",
                table: "Instruments",
                newName: "brandId");

            migrationBuilder.RenameIndex(
                name: "IX_Instruments_BrandId",
                table: "Instruments",
                newName: "IX_Instruments_brandId");

            migrationBuilder.AddForeignKey(
                name: "FK_Instruments_Brands_brandId",
                table: "Instruments",
                column: "brandId",
                principalTable: "Brands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
