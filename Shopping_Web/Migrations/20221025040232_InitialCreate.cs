using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopping_Web.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Produce",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SellingStarTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    SellingEndTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produce", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Produce");
        }
    }
}
