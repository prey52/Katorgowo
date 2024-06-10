using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OfertyPracy.Migrations
{
    /// <inheritdoc />
    public partial class V12 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Tytuł",
                table: "OfertyPracy",
                newName: "Tytul");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Tytul",
                table: "OfertyPracy",
                newName: "Tytuł");
        }
    }
}
