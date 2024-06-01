using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OfertyPracy.Migrations
{
    /// <inheritdoc />
    public partial class V2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WaznoscDni",
                table: "OfertyPracy");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WaznoscDni",
                table: "OfertyPracy",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
