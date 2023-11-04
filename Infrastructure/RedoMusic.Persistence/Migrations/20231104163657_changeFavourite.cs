using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RedoMusic.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class changeFavourite : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Favorites_Instruments_InstrumentId",
                table: "Favorites");

            migrationBuilder.DropForeignKey(
                name: "FK_Favorites_Users_UserId",
                table: "Favorites");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Favorites",
                table: "Favorites");

            migrationBuilder.RenameTable(
                name: "Favorites",
                newName: "Favourites");

            migrationBuilder.RenameIndex(
                name: "IX_Favorites_UserId",
                table: "Favourites",
                newName: "IX_Favourites_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Favorites_InstrumentId",
                table: "Favourites",
                newName: "IX_Favourites_InstrumentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Favourites",
                table: "Favourites",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Favourites_Instruments_InstrumentId",
                table: "Favourites",
                column: "InstrumentId",
                principalTable: "Instruments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Favourites_Users_UserId",
                table: "Favourites",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Favourites_Instruments_InstrumentId",
                table: "Favourites");

            migrationBuilder.DropForeignKey(
                name: "FK_Favourites_Users_UserId",
                table: "Favourites");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Favourites",
                table: "Favourites");

            migrationBuilder.RenameTable(
                name: "Favourites",
                newName: "Favorites");

            migrationBuilder.RenameIndex(
                name: "IX_Favourites_UserId",
                table: "Favorites",
                newName: "IX_Favorites_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Favourites_InstrumentId",
                table: "Favorites",
                newName: "IX_Favorites_InstrumentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Favorites",
                table: "Favorites",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Favorites_Instruments_InstrumentId",
                table: "Favorites",
                column: "InstrumentId",
                principalTable: "Instruments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Favorites_Users_UserId",
                table: "Favorites",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
