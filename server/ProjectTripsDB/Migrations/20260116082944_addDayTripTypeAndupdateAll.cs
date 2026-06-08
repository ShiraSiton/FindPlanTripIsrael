using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectTripsDB.Migrations
{
    /// <inheritdoc />
    public partial class addDayTripTypeAndupdateAll : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DayTrips_Region_RegionId",
                table: "DayTrips");

            migrationBuilder.DropForeignKey(
                name: "FK_Routes_Region_RegionId",
                table: "Routes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Region",
                table: "Region");

            migrationBuilder.RenameTable(
                name: "Region",
                newName: "Regions");

            migrationBuilder.AddColumn<int>(
                name: "DayTripTypeId",
                table: "DayTrips",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Regions",
                table: "Regions",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "DayTripTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DayTripTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DayTrips_DayTripTypeId",
                table: "DayTrips",
                column: "DayTripTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_DayTrips_DayTripTypes_DayTripTypeId",
                table: "DayTrips",
                column: "DayTripTypeId",
                principalTable: "DayTripTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DayTrips_Regions_RegionId",
                table: "DayTrips",
                column: "RegionId",
                principalTable: "Regions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Routes_Regions_RegionId",
                table: "Routes",
                column: "RegionId",
                principalTable: "Regions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DayTrips_DayTripTypes_DayTripTypeId",
                table: "DayTrips");

            migrationBuilder.DropForeignKey(
                name: "FK_DayTrips_Regions_RegionId",
                table: "DayTrips");

            migrationBuilder.DropForeignKey(
                name: "FK_Routes_Regions_RegionId",
                table: "Routes");

            migrationBuilder.DropTable(
                name: "DayTripTypes");

            migrationBuilder.DropIndex(
                name: "IX_DayTrips_DayTripTypeId",
                table: "DayTrips");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Regions",
                table: "Regions");

            migrationBuilder.DropColumn(
                name: "DayTripTypeId",
                table: "DayTrips");

            migrationBuilder.RenameTable(
                name: "Regions",
                newName: "Region");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Region",
                table: "Region",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DayTrips_Region_RegionId",
                table: "DayTrips",
                column: "RegionId",
                principalTable: "Region",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Routes_Region_RegionId",
                table: "Routes",
                column: "RegionId",
                principalTable: "Region",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
