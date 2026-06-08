using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectTripsDB.Migrations
{
    /// <inheritdoc />
    public partial class nameTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Places_RegionAndCities_RegionAndCityId",
                table: "Places");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RegionAndCities",
                table: "RegionAndCities");

            migrationBuilder.RenameTable(
                name: "RegionAndCities",
                newName: "RegionAndCitys");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RegionAndCitys",
                table: "RegionAndCitys",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Places_RegionAndCitys_RegionAndCityId",
                table: "Places",
                column: "RegionAndCityId",
                principalTable: "RegionAndCitys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Places_RegionAndCitys_RegionAndCityId",
                table: "Places");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RegionAndCitys",
                table: "RegionAndCitys");

            migrationBuilder.RenameTable(
                name: "RegionAndCitys",
                newName: "RegionAndCities");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RegionAndCities",
                table: "RegionAndCities",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Places_RegionAndCities_RegionAndCityId",
                table: "Places",
                column: "RegionAndCityId",
                principalTable: "RegionAndCities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
