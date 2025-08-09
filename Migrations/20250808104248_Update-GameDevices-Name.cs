using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GamerCorner.Migrations
{
    /// <inheritdoc />
    public partial class UpdateGameDevicesName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_GameDevices",
                table: "GameDevices");

            migrationBuilder.DropColumn(
                name: "DeciceId",
                table: "GameDevices");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GameDevices",
                table: "GameDevices",
                columns: new[] { "GameId", "DeviceId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_GameDevices",
                table: "GameDevices");

            migrationBuilder.AddColumn<int>(
                name: "DeciceId",
                table: "GameDevices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_GameDevices",
                table: "GameDevices",
                columns: new[] { "GameId", "DeciceId" });
        }
    }
}
