using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectTripsDB.Migrations
{
    /// <inheritdoc />
    public partial class AddFieldLatAndLngToRouteTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "EndLatitude",
                table: "Routes",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "EndLongitude",
                table: "Routes",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "StartLatitude",
                table: "Routes",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "StartLongitude",
                table: "Routes",
                type: "float",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndLatitude",
                table: "Routes");

            migrationBuilder.DropColumn(
                name: "EndLongitude",
                table: "Routes");

            migrationBuilder.DropColumn(
                name: "StartLatitude",
                table: "Routes");

            migrationBuilder.DropColumn(
                name: "StartLongitude",
                table: "Routes");
        }
    }
}
