using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCProjekt.Data.Migrations
{
    public partial class PridaniTelefonu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Client",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Client");
        }
    }
}
