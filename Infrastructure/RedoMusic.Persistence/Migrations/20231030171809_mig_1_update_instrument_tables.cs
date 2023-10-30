using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RedoMusic.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_1_update_instrument_tables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Model",
                table: "Instruments",
                newName: "Picture");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Instruments",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Instruments");

            migrationBuilder.RenameColumn(
                name: "Picture",
                table: "Instruments",
                newName: "Model");
        }
    }
}
