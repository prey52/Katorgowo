using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobOffers.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "JobOffers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecruiterId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<int>(type: "int", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PublishDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Requitements = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salary = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkingTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContractType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Benefits = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobOffers", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JobOffers");
        }
    }
}
