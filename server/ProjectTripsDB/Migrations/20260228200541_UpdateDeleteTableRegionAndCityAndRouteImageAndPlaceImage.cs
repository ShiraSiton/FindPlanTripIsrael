using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectTripsDB.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDeleteTableRegionAndCityAndRouteImageAndPlaceImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Places_RegionAndCitys_RegionAndCityId",
                table: "Places");

            migrationBuilder.DropForeignKey(
                name: "FK_RoutePlaces_Places_PlaceId",
                table: "RoutePlaces");

            migrationBuilder.DropForeignKey(
                name: "FK_RoutePlaces_Routes_RouteId",
                table: "RoutePlaces");

            migrationBuilder.DropForeignKey(
                name: "FK_Routes_RegionAndCitys_RegionAndCityId",
                table: "Routes");

            migrationBuilder.DropTable(
                name: "PlaceImages");

            migrationBuilder.DropTable(
                name: "Ratings");

            migrationBuilder.DropTable(
                name: "RegionAndCitys");

            migrationBuilder.DropTable(
                name: "RouteImages");

            migrationBuilder.DropIndex(
                name: "IX_Routes_RegionAndCityId",
                table: "Routes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoutePlaces",
                table: "RoutePlaces");

            migrationBuilder.DropColumn(
                name: "RegionAndCityId",
                table: "Routes");

            migrationBuilder.RenameTable(
                name: "RoutePlaces",
                newName: "RoutePoints");

            migrationBuilder.RenameColumn(
                name: "RegionAndCityId",
                table: "Places",
                newName: "RegionId");

            migrationBuilder.RenameIndex(
                name: "IX_Places_RegionAndCityId",
                table: "Places",
                newName: "IX_Places_RegionId");

            migrationBuilder.RenameIndex(
                name: "IX_RoutePlaces_RouteId",
                table: "RoutePoints",
                newName: "IX_RoutePoints_RouteId");

            migrationBuilder.RenameIndex(
                name: "IX_RoutePlaces_PlaceId",
                table: "RoutePoints",
                newName: "IX_RoutePoints_PlaceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoutePoints",
                table: "RoutePoints",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemType = table.Column<int>(type: "int", nullable: false),
                    RouteId = table.Column<int>(type: "int", nullable: true),
                    PlaceId = table.Column<int>(type: "int", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsMain = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Images_Places_PlaceId",
                        column: x => x.PlaceId,
                        principalTable: "Places",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Images_Routes_RouteId",
                        column: x => x.RouteId,
                        principalTable: "Routes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Images_Users_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateOnly(2026, 2, 28));

            migrationBuilder.CreateIndex(
                name: "IX_Images_CreatedByUserId",
                table: "Images",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_PlaceId",
                table: "Images",
                column: "PlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_RouteId",
                table: "Images",
                column: "RouteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Places_Regions_RegionId",
                table: "Places",
                column: "RegionId",
                principalTable: "Regions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoutePoints_Places_PlaceId",
                table: "RoutePoints",
                column: "PlaceId",
                principalTable: "Places",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RoutePoints_Routes_RouteId",
                table: "RoutePoints",
                column: "RouteId",
                principalTable: "Routes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Places_Regions_RegionId",
                table: "Places");

            migrationBuilder.DropForeignKey(
                name: "FK_RoutePoints_Places_PlaceId",
                table: "RoutePoints");

            migrationBuilder.DropForeignKey(
                name: "FK_RoutePoints_Routes_RouteId",
                table: "RoutePoints");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoutePoints",
                table: "RoutePoints");

            migrationBuilder.RenameTable(
                name: "RoutePoints",
                newName: "RoutePlaces");

            migrationBuilder.RenameColumn(
                name: "RegionId",
                table: "Places",
                newName: "RegionAndCityId");

            migrationBuilder.RenameIndex(
                name: "IX_Places_RegionId",
                table: "Places",
                newName: "IX_Places_RegionAndCityId");

            migrationBuilder.RenameIndex(
                name: "IX_RoutePoints_RouteId",
                table: "RoutePlaces",
                newName: "IX_RoutePlaces_RouteId");

            migrationBuilder.RenameIndex(
                name: "IX_RoutePoints_PlaceId",
                table: "RoutePlaces",
                newName: "IX_RoutePlaces_PlaceId");

            migrationBuilder.AddColumn<int>(
                name: "RegionAndCityId",
                table: "Routes",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoutePlaces",
                table: "RoutePlaces",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "PlaceImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: false),
                    PlaceId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateOnly>(type: "date", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsMain = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlaceImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlaceImages_Places_PlaceId",
                        column: x => x.PlaceId,
                        principalTable: "Places",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlaceImages_Users_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Ratings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DayTripId = table.Column<int>(type: "int", nullable: true),
                    PlaceId = table.Column<int>(type: "int", nullable: true),
                    RouteId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ContentType = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateOnly>(type: "date", nullable: false),
                    RatingValue = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ratings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ratings_DayTrips_DayTripId",
                        column: x => x.DayTripId,
                        principalTable: "DayTrips",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Ratings_Places_PlaceId",
                        column: x => x.PlaceId,
                        principalTable: "Places",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Ratings_Routes_RouteId",
                        column: x => x.RouteId,
                        principalTable: "Routes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Ratings_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RegionAndCitys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegionId = table.Column<int>(type: "int", nullable: false),
                    RegionAndCityName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegionAndCitys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RegionAndCitys_Regions_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Regions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RouteImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: false),
                    RouteId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateOnly>(type: "date", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsMain = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RouteImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RouteImages_Routes_RouteId",
                        column: x => x.RouteId,
                        principalTable: "Routes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RouteImages_Users_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateOnly(2026, 2, 25));

            migrationBuilder.CreateIndex(
                name: "IX_Routes_RegionAndCityId",
                table: "Routes",
                column: "RegionAndCityId");

            migrationBuilder.CreateIndex(
                name: "IX_PlaceImages_CreatedByUserId",
                table: "PlaceImages",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PlaceImages_PlaceId",
                table: "PlaceImages",
                column: "PlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_DayTripId",
                table: "Ratings",
                column: "DayTripId");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_PlaceId",
                table: "Ratings",
                column: "PlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_RouteId",
                table: "Ratings",
                column: "RouteId");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_UserId",
                table: "Ratings",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RegionAndCitys_RegionId",
                table: "RegionAndCitys",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_RouteImages_CreatedByUserId",
                table: "RouteImages",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_RouteImages_RouteId",
                table: "RouteImages",
                column: "RouteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Places_RegionAndCitys_RegionAndCityId",
                table: "Places",
                column: "RegionAndCityId",
                principalTable: "RegionAndCitys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoutePlaces_Places_PlaceId",
                table: "RoutePlaces",
                column: "PlaceId",
                principalTable: "Places",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RoutePlaces_Routes_RouteId",
                table: "RoutePlaces",
                column: "RouteId",
                principalTable: "Routes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Routes_RegionAndCitys_RegionAndCityId",
                table: "Routes",
                column: "RegionAndCityId",
                principalTable: "RegionAndCitys",
                principalColumn: "Id");
        }
    }
}
