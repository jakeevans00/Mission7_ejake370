using Microsoft.EntityFrameworkCore.Migrations;

namespace Mission7_ejake370.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CategoryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "movies",
                columns: table => new
                {
                    MovieId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    title = table.Column<string>(nullable: false),
                    year = table.Column<string>(nullable: false),
                    director = table.Column<string>(nullable: false),
                    rating = table.Column<string>(nullable: false),
                    edited = table.Column<bool>(nullable: false),
                    lentTo = table.Column<string>(nullable: true),
                    notes = table.Column<string>(maxLength: 25, nullable: true),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_movies", x => x.MovieId);
                    table.ForeignKey(
                        name: "FK_movies_categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[] { 1, "Action/Adventure" });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[] { 2, "Comedy" });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[] { 3, "Drama" });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[] { 4, "Family" });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[] { 5, "Horror/Suspense" });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[] { 6, "Miscellaneous" });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[] { 7, "Television" });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[] { 8, "VHS" });

            migrationBuilder.InsertData(
                table: "movies",
                columns: new[] { "MovieId", "CategoryId", "director", "edited", "lentTo", "notes", "rating", "title", "year" },
                values: new object[] { 1, 1, "Christopher Nolan", true, "", "Amazing movie", "PG-13", "Batman Begins", "2005" });

            migrationBuilder.InsertData(
                table: "movies",
                columns: new[] { "MovieId", "CategoryId", "director", "edited", "lentTo", "notes", "rating", "title", "year" },
                values: new object[] { 2, 1, "Christopher Nolan", true, "", "eveeen better movie!", "PG-13", "The Dark Knight", "2008" });

            migrationBuilder.InsertData(
                table: "movies",
                columns: new[] { "MovieId", "CategoryId", "director", "edited", "lentTo", "notes", "rating", "title", "year" },
                values: new object[] { 3, 3, "Billie August", false, "Dave", "An honest tear-jerker", "PG-13", "Les Miserables", "1998" });

            migrationBuilder.CreateIndex(
                name: "IX_movies_CategoryId",
                table: "movies",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "movies");

            migrationBuilder.DropTable(
                name: "categories");
        }
    }
}
