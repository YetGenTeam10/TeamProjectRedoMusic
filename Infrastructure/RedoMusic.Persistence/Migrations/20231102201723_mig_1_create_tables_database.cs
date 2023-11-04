using System;
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

            migrationBuilder.DropForeignKey(
                name: "FK_Instruments_Categories_CategoryId",
                table: "Instruments");

            migrationBuilder.RenameColumn(
                name: "brandId",
                table: "Instruments",
                newName: "BrandId");

            migrationBuilder.RenameColumn(
                name: "Model",
                table: "Instruments",
                newName: "Picture");

            migrationBuilder.RenameIndex(
                name: "IX_Instruments_brandId",
                table: "Instruments",
                newName: "IX_Instruments_BrandId");

            migrationBuilder.AlterColumn<Guid>(
                name: "CategoryId",
                table: "Instruments",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Barcode",
                table: "Instruments",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description",
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

            migrationBuilder.AddForeignKey(
                name: "FK_Instruments_Categories_CategoryId",
                table: "Instruments",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Instruments_Brands_BrandId",
                table: "Instruments");

            migrationBuilder.DropForeignKey(
                name: "FK_Instruments_Categories_CategoryId",
                table: "Instruments");

            migrationBuilder.DropColumn(
                name: "Barcode",
                table: "Instruments");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Instruments");

            migrationBuilder.RenameColumn(
                name: "BrandId",
                table: "Instruments",
                newName: "brandId");

            migrationBuilder.RenameColumn(
                name: "Picture",
                table: "Instruments",
                newName: "Model");

            migrationBuilder.RenameIndex(
                name: "IX_Instruments_BrandId",
                table: "Instruments",
                newName: "IX_Instruments_brandId");

            migrationBuilder.AlterColumn<Guid>(
                name: "CategoryId",
                table: "Instruments",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_Instruments_Brands_brandId",
                table: "Instruments",
                column: "brandId",
                principalTable: "Brands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Instruments_Categories_CategoryId",
                table: "Instruments",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id");
        }
    }
}
