using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bookies.Repository.Migrations
{
    /// <inheritdoc />
    public partial class Removed_SeriesID_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_Series_SeriesID",
                table: "Book");

            migrationBuilder.DropForeignKey(
                name: "FK_Series_FictionalUniverse_FictionalUniverseID",
                table: "Series");

            migrationBuilder.DropIndex(
                name: "IX_Book_SeriesID",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "SeriesID",
                table: "Book");

            migrationBuilder.AlterColumn<int>(
                name: "FictionalUniverseID",
                table: "Series",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Series_FictionalUniverse_FictionalUniverseID",
                table: "Series",
                column: "FictionalUniverseID",
                principalTable: "FictionalUniverse",
                principalColumn: "UniverseID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Series_FictionalUniverse_FictionalUniverseID",
                table: "Series");

            migrationBuilder.AlterColumn<int>(
                name: "FictionalUniverseID",
                table: "Series",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SeriesID",
                table: "Book",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Book_SeriesID",
                table: "Book",
                column: "SeriesID");

            migrationBuilder.AddForeignKey(
                name: "FK_Book_Series_SeriesID",
                table: "Book",
                column: "SeriesID",
                principalTable: "Series",
                principalColumn: "SeriesID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Series_FictionalUniverse_FictionalUniverseID",
                table: "Series",
                column: "FictionalUniverseID",
                principalTable: "FictionalUniverse",
                principalColumn: "UniverseID",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
