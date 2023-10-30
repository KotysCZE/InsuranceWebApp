using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCProjekt.Data.Migrations
{
    public partial class Uprava_modelu_client : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Insurance_name",
                table: "Client");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Insurance_name",
                table: "Client",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
