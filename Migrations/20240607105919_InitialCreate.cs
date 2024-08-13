using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Device_Migration_Admin_Portal.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Devices",
                columns: table => new
                {
                    DeviceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IntuneStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AzureAdJoinStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserDetailsVerification = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OnedriveUnlinking = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OutlookProfileRemoval = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MigrationProcess = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TargetedUser = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Devices", x => x.DeviceId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Devices");
        }
    }
}
