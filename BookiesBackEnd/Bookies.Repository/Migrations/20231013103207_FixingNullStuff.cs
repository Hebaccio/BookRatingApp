using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bookies.Repository.Migrations
{
    /// <inheritdoc />
    public partial class FixingNullStuff : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_RelatedBooks",
                table: "RelatedBooks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PersonSocial",
                table: "PersonSocial");

            migrationBuilder.DropColumn(
                name: "Relation",
                table: "RelatedBooks");

            migrationBuilder.RenameColumn(
                name: "Order",
                table: "RelatedBooks",
                newName: "RelationID");

            migrationBuilder.AddColumn<int>(
                name: "Count",
                table: "PersonSocial",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Website",
                table: "Person",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "Age",
                table: "Character",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "PageCount",
                table: "Book",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RelatedBooks",
                table: "RelatedBooks",
                columns: new[] { "Book1_ID", "Book2_ID", "RelationID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_PersonSocial",
                table: "PersonSocial",
                columns: new[] { "PersonID", "SocialMediaID", "Count" });

            migrationBuilder.CreateTable(
                name: "Relation",
                columns: table => new
                {
                    RelationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RelationName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RelationOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Relation", x => x.RelationID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RelatedBooks_RelationID",
                table: "RelatedBooks",
                column: "RelationID");

            migrationBuilder.AddForeignKey(
                name: "FK_RelatedBooks_Relation_RelationID",
                table: "RelatedBooks",
                column: "RelationID",
                principalTable: "Relation",
                principalColumn: "RelationID",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RelatedBooks_Relation_RelationID",
                table: "RelatedBooks");

            migrationBuilder.DropTable(
                name: "Relation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RelatedBooks",
                table: "RelatedBooks");

            migrationBuilder.DropIndex(
                name: "IX_RelatedBooks_RelationID",
                table: "RelatedBooks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PersonSocial",
                table: "PersonSocial");

            migrationBuilder.DropColumn(
                name: "Count",
                table: "PersonSocial");

            migrationBuilder.RenameColumn(
                name: "RelationID",
                table: "RelatedBooks",
                newName: "Order");

            migrationBuilder.AddColumn<string>(
                name: "Relation",
                table: "RelatedBooks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Website",
                table: "Person",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Age",
                table: "Character",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PageCount",
                table: "Book",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_RelatedBooks",
                table: "RelatedBooks",
                columns: new[] { "Book1_ID", "Book2_ID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_PersonSocial",
                table: "PersonSocial",
                columns: new[] { "PersonID", "SocialMediaID" });
        }
    }
}
