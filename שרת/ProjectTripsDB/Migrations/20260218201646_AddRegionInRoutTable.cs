using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectTripsDB.Migrations
{
    /// <inheritdoc />
    public partial class AddRegionInRoutTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RegionId",
                table: "Routes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Routes_RegionId",
                table: "Routes",
                column: "RegionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Routes_Regions_RegionId",
                table: "Routes",
                column: "RegionId",
                principalTable: "Regions",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Routes_Regions_RegionId",
                table: "Routes");

            migrationBuilder.DropIndex(
                name: "IX_Routes_RegionId",
                table: "Routes");

            migrationBuilder.DropColumn(
                name: "RegionId",
                table: "Routes");
        }
    }
}
