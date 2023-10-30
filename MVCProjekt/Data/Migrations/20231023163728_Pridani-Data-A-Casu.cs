using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCProjekt.Data.Migrations
{
    public partial class PridaniDataACasu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfInsert",
                table: "Comment",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOfInsert",
                table: "Comment");
        }
    }
}
