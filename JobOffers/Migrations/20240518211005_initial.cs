﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OfertyPracy.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OfertyPracy",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdRekrutera = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tytuł = table.Column<int>(type: "int", nullable: false),
                    Kategoria = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataDodania = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataPublikacji = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataWaznosci = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Wymagania = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Wynagrodzenie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WymiarPracy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RodzajUmowy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Benefity = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfertyPracy", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OfertyPracy");
        }
    }
}
