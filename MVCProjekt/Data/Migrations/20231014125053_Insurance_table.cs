using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCProjekt.Data.Migrations
{
    public partial class Insurance_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Insurance",
                columns: table => new
                {
                    InsuranceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    InsuranceName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InsuranceValue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ObjectOfInsurance = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Insurance", x => x.InsuranceId);
                    table.ForeignKey(
                        name: "FK_Insurance_Client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Client",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Insurance_ClientId",
                table: "Insurance",
                column: "ClientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Insurance");
        }
    }
}
