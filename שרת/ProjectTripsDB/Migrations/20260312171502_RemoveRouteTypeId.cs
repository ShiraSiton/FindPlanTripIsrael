using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectTripsDB.Migrations
{
    /// <inheritdoc />
    public partial class RemoveRouteTypeId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DayTrips_DayTripTypes_DayTripTypeId",
                table: "DayTrips");

            migrationBuilder.DropForeignKey(
                name: "FK_Places_PlaceTypes_PlaceTypeId",
                table: "Places");

            migrationBuilder.DropForeignKey(
                name: "FK_Routes_RouteTypes_RouteTypeId",
                table: "Routes");

            migrationBuilder.DropTable(
                name: "DayTripTypes");

            migrationBuilder.DropTable(
                name: "PlaceTypes");

            migrationBuilder.DropTable(
                name: "RouteTypes");

            migrationBuilder.DropIndex(
                name: "IX_Routes_RouteTypeId",
                table: "Routes");

            migrationBuilder.DropIndex(
                name: "IX_Places_PlaceTypeId",
                table: "Places");

            migrationBuilder.DropIndex(
                name: "IX_DayTrips_DayTripTypeId",
                table: "DayTrips");

            migrationBuilder.DropColumn(
                name: "RouteTypeId",
                table: "Routes");

            migrationBuilder.DropColumn(
                name: "PlaceTypeId",
                table: "Places");

            migrationBuilder.DropColumn(
                name: "DayTripTypeId",
                table: "DayTrips");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RouteTypeId",
                table: "Routes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PlaceTypeId",
                table: "Places",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DayTripTypeId",
                table: "DayTrips",
                type: "int",
                nullable: true);

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

            migrationBuilder.CreateTable(
                name: "PlaceTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlaceTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RouteTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RouteTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Routes_RouteTypeId",
                table: "Routes",
                column: "RouteTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Places_PlaceTypeId",
                table: "Places",
                column: "PlaceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_DayTrips_DayTripTypeId",
                table: "DayTrips",
                column: "DayTripTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_DayTrips_DayTripTypes_DayTripTypeId",
                table: "DayTrips",
                column: "DayTripTypeId",
                principalTable: "DayTripTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Places_PlaceTypes_PlaceTypeId",
                table: "Places",
                column: "PlaceTypeId",
                principalTable: "PlaceTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Routes_RouteTypes_RouteTypeId",
                table: "Routes",
                column: "RouteTypeId",
                principalTable: "RouteTypes",
                principalColumn: "Id");
        }
    }
}
