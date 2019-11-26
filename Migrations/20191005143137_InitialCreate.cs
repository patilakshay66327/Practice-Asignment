using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PracticeAssignment.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LeadDetails",
                columns: table => new
                {
                    leadId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    leadFirstName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    leadLastName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    leadAddress = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    leadPhoneNumber = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    leadEmail = table.Column<string>(type: "nvarchar(30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeadDetails", x => x.leadId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LeadDetails");
        }
    }
}
