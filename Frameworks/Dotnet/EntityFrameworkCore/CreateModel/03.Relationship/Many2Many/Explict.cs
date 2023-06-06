//using Microsoft.EntityFrameworkCore.Migrations;

//#nullable disable

//namespace Relationship.Migrations
//{
//    /// <inheritdoc />
//    public partial class Explict : Migration
//    {
//        /// <inheritdoc />
//        protected override void Up(MigrationBuilder migrationBuilder)
//        {
//            migrationBuilder.CreateTable(
//                name: "Books",
//                columns: table => new
//                {
//                    Id = table.Column<int>(type: "int", nullable: false)
//                        .Annotation("SqlServer:Identity", "1, 1"),
//                    BookName = table.Column<string>(type: "nvarchar(max)", nullable: false)
//                },
//                constraints: table =>
//                {
//                    table.PrimaryKey("PK_Books", x => x.Id);
//                });

//            migrationBuilder.CreateTable(
//                name: "Users",
//                columns: table => new
//                {
//                    Id = table.Column<int>(type: "int", nullable: false)
//                        .Annotation("SqlServer:Identity", "1, 1"),
//                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false)
//                },
//                constraints: table =>
//                {
//                    table.PrimaryKey("PK_Users", x => x.Id);
//                });

//            migrationBuilder.CreateTable(
//                name: "BookAuthor",
//                columns: table => new
//                {
//                    booksId = table.Column<int>(type: "int", nullable: false),
//                    usersId = table.Column<int>(type: "int", nullable: false)
//                },
//                constraints: table =>
//                {
//                    table.PrimaryKey("PK_BookAuthor", x => new { x.booksId, x.usersId });
//                    table.ForeignKey(
//                        name: "FK_BookAuthor_Books_booksId",
//                        column: x => x.booksId,
//                        principalTable: "Books",
//                        principalColumn: "Id",
//                        onDelete: ReferentialAction.Cascade);
//                    table.ForeignKey(
//                        name: "FK_BookAuthor_Users_usersId",
//                        column: x => x.usersId,
//                        principalTable: "Users",
//                        principalColumn: "Id",
//                        onDelete: ReferentialAction.Cascade);
//                });

//            migrationBuilder.CreateIndex(
//                name: "IX_BookAuthor_usersId",
//                table: "BookAuthor",
//                column: "usersId");
//        }

//        /// <inheritdoc />
//        protected override void Down(MigrationBuilder migrationBuilder)
//        {
//            migrationBuilder.DropTable(
//                name: "BookAuthor");

//            migrationBuilder.DropTable(
//                name: "Books");

//            migrationBuilder.DropTable(
//                name: "Users");
//        }
//    }
//}
