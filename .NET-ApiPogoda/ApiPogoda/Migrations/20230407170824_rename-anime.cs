using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiPogoda.Migrations
{
    /// <inheritdoc />
    public partial class renameanime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Quotes",
                newName: "Anime");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Anime",
                table: "Quotes",
                newName: "Title");
        }
    }
}
