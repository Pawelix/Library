using Microsoft.EntityFrameworkCore.Migrations;

namespace Pawel.Cms.Domain.Migrations
{
    public partial class book_author_rename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AuthorName",
                schema: "Book",
                table: "Books",
                newName: "Author");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Author",
                schema: "Book",
                table: "Books",
                newName: "AuthorName");
        }
    }
}
