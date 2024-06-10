using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecruitmentProcess.Migrations
{
    /// <inheritdoc />
    public partial class first : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rekrutacja",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdAplikacji = table.Column<int>(type: "int", nullable: false),
                    IdOgloszenia = table.Column<int>(type: "int", nullable: false),
                    IdRekrutera = table.Column<int>(type: "int", nullable: false),
                    IdUzytkownika = table.Column<int>(type: "int", nullable: false),
                    Tresc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataAplikacji = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PlikCV = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rekrutacja", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ZgloszeniaModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdAplikacji = table.Column<int>(type: "int", nullable: false),
                    DataZgloszenia = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TrescZgloszenia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZgloszeniaModel", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rekrutacja");

            migrationBuilder.DropTable(
                name: "ZgloszeniaModel");
        }
    }
}
