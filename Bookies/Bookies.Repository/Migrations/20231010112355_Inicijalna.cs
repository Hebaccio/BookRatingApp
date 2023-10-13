using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bookies.Repository.Migrations
{
    /// <inheritdoc />
    public partial class Inicijalna : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Character",
                columns: table => new
                {
                    CharacterID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Picture = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    About = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Character", x => x.CharacterID);
                });

            migrationBuilder.CreateTable(
                name: "FictionalUniverse",
                columns: table => new
                {
                    UniverseID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UniverseName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UniverseDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UniverseNotes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FictionalUniverse", x => x.UniverseID);
                });

            migrationBuilder.CreateTable(
                name: "Genre",
                columns: table => new
                {
                    GenreID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GenreName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GenreDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genre", x => x.GenreID);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    PersonID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Picture = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Bio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Website = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.PersonID);
                });

            migrationBuilder.CreateTable(
                name: "Publisher",
                columns: table => new
                {
                    PublisherID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PublisherName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PublisherPicture = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PublisherBio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PublisherWebsite = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publisher", x => x.PublisherID);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    RoleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.RoleID);
                });

            migrationBuilder.CreateTable(
                name: "SocialMedia",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SocialMediaName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Picture = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialMedia", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Tag",
                columns: table => new
                {
                    TagID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TagName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TagDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tag", x => x.TagID);
                });

            migrationBuilder.CreateTable(
                name: "Series",
                columns: table => new
                {
                    SeriesID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SeriesName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SeriesDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SeriesNotes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FictionalUniverseID = table.Column<int>(type: "int", nullable: false),
                    UniverseID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Series", x => x.SeriesID);
                    table.ForeignKey(
                        name: "FK_Series_FictionalUniverse_FictionalUniverseID",
                        column: x => x.FictionalUniverseID,
                        principalTable: "FictionalUniverse",
                        principalColumn: "UniverseID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonSocial",
                columns: table => new
                {
                    PersonID = table.Column<int>(type: "int", nullable: false),
                    SocialMediaID = table.Column<int>(type: "int", nullable: false),
                    URL = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonSocial", x => new { x.PersonID, x.SocialMediaID });
                    table.ForeignKey(
                        name: "FK_PersonSocial_Person_PersonID",
                        column: x => x.PersonID,
                        principalTable: "Person",
                        principalColumn: "PersonID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonSocial_SocialMedia_SocialMediaID",
                        column: x => x.SocialMediaID,
                        principalTable: "SocialMedia",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Book",
                columns: table => new
                {
                    BookID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Picture = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BookStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PublishDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PageCount = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<float>(type: "real", nullable: false),
                    SeriesID = table.Column<int>(type: "int", nullable: false),
                    PublisherID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book", x => x.BookID);
                    table.ForeignKey(
                        name: "FK_Book_Publisher_PublisherID",
                        column: x => x.PublisherID,
                        principalTable: "Publisher",
                        principalColumn: "PublisherID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Book_Series_SeriesID",
                        column: x => x.SeriesID,
                        principalTable: "Series",
                        principalColumn: "SeriesID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookCharacter",
                columns: table => new
                {
                    BookID = table.Column<int>(type: "int", nullable: false),
                    CharacterID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookCharacter", x => new { x.BookID, x.CharacterID });
                    table.ForeignKey(
                        name: "FK_BookCharacter_Book_BookID",
                        column: x => x.BookID,
                        principalTable: "Book",
                        principalColumn: "BookID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookCharacter_Character_CharacterID",
                        column: x => x.CharacterID,
                        principalTable: "Character",
                        principalColumn: "CharacterID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookGenre",
                columns: table => new
                {
                    GenreID = table.Column<int>(type: "int", nullable: false),
                    BookID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookGenre", x => new { x.GenreID, x.BookID });
                    table.ForeignKey(
                        name: "FK_BookGenre_Book_BookID",
                        column: x => x.BookID,
                        principalTable: "Book",
                        principalColumn: "BookID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookGenre_Genre_GenreID",
                        column: x => x.GenreID,
                        principalTable: "Genre",
                        principalColumn: "GenreID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookStaff",
                columns: table => new
                {
                    BookID = table.Column<int>(type: "int", nullable: false),
                    PersonID = table.Column<int>(type: "int", nullable: false),
                    RoleID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookStaff", x => new { x.BookID, x.PersonID, x.RoleID });
                    table.ForeignKey(
                        name: "FK_BookStaff_Book_BookID",
                        column: x => x.BookID,
                        principalTable: "Book",
                        principalColumn: "BookID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookStaff_Person_PersonID",
                        column: x => x.PersonID,
                        principalTable: "Person",
                        principalColumn: "PersonID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookStaff_Role_RoleID",
                        column: x => x.RoleID,
                        principalTable: "Role",
                        principalColumn: "RoleID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookTag",
                columns: table => new
                {
                    TagID = table.Column<int>(type: "int", nullable: false),
                    BookID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookTag", x => new { x.TagID, x.BookID });
                    table.ForeignKey(
                        name: "FK_BookTag_Book_BookID",
                        column: x => x.BookID,
                        principalTable: "Book",
                        principalColumn: "BookID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookTag_Tag_TagID",
                        column: x => x.TagID,
                        principalTable: "Tag",
                        principalColumn: "TagID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RelatedBooks",
                columns: table => new
                {
                    Book1_ID = table.Column<int>(type: "int", nullable: false),
                    Book2_ID = table.Column<int>(type: "int", nullable: false),
                    Relation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RelatedBooks", x => new { x.Book1_ID, x.Book2_ID });
                    table.ForeignKey(
                        name: "FK_RelatedBooks_Book_Book1_ID",
                        column: x => x.Book1_ID,
                        principalTable: "Book",
                        principalColumn: "BookID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_RelatedBooks_Book_Book2_ID",
                        column: x => x.Book2_ID,
                        principalTable: "Book",
                        principalColumn: "BookID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Book_PublisherID",
                table: "Book",
                column: "PublisherID");

            migrationBuilder.CreateIndex(
                name: "IX_Book_SeriesID",
                table: "Book",
                column: "SeriesID");

            migrationBuilder.CreateIndex(
                name: "IX_BookCharacter_CharacterID",
                table: "BookCharacter",
                column: "CharacterID");

            migrationBuilder.CreateIndex(
                name: "IX_BookGenre_BookID",
                table: "BookGenre",
                column: "BookID");

            migrationBuilder.CreateIndex(
                name: "IX_BookStaff_PersonID",
                table: "BookStaff",
                column: "PersonID");

            migrationBuilder.CreateIndex(
                name: "IX_BookStaff_RoleID",
                table: "BookStaff",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_BookTag_BookID",
                table: "BookTag",
                column: "BookID");

            migrationBuilder.CreateIndex(
                name: "IX_PersonSocial_SocialMediaID",
                table: "PersonSocial",
                column: "SocialMediaID");

            migrationBuilder.CreateIndex(
                name: "IX_RelatedBooks_Book2_ID",
                table: "RelatedBooks",
                column: "Book2_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Series_FictionalUniverseID",
                table: "Series",
                column: "FictionalUniverseID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookCharacter");

            migrationBuilder.DropTable(
                name: "BookGenre");

            migrationBuilder.DropTable(
                name: "BookStaff");

            migrationBuilder.DropTable(
                name: "BookTag");

            migrationBuilder.DropTable(
                name: "PersonSocial");

            migrationBuilder.DropTable(
                name: "RelatedBooks");

            migrationBuilder.DropTable(
                name: "Character");

            migrationBuilder.DropTable(
                name: "Genre");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "Tag");

            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DropTable(
                name: "SocialMedia");

            migrationBuilder.DropTable(
                name: "Book");

            migrationBuilder.DropTable(
                name: "Publisher");

            migrationBuilder.DropTable(
                name: "Series");

            migrationBuilder.DropTable(
                name: "FictionalUniverse");
        }
    }
}
