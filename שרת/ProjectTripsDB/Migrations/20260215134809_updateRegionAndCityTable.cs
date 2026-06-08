using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectTripsDB.Migrations
{
    /// <inheritdoc />
    public partial class updateRegionAndCityTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RegionName",
                table: "RegionAndCitys",
                newName: "RegionAndCityName");

            migrationBuilder.AddColumn<int>(
                name: "RegionId",
                table: "RegionAndCitys",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_RegionAndCitys_RegionId",
                table: "RegionAndCitys",
                column: "RegionId");

            migrationBuilder.AddForeignKey(
                name: "FK_RegionAndCitys_Regions_RegionId",
                table: "RegionAndCitys",
                column: "RegionId",
                principalTable: "Regions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RegionAndCitys_Regions_RegionId",
                table: "RegionAndCitys");

            migrationBuilder.DropIndex(
                name: "IX_RegionAndCitys_RegionId",
                table: "RegionAndCitys");

            migrationBuilder.DropColumn(
                name: "RegionId",
                table: "RegionAndCitys");

            migrationBuilder.RenameColumn(
                name: "RegionAndCityName",
                table: "RegionAndCitys",
                newName: "RegionName");
        }
    }
}
