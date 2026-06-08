using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectTripsDB.Migrations
{
    /// <inheritdoc />
    public partial class DeleteTableWeather : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DayTripWeathers");

            migrationBuilder.DropTable(
                name: "PlaceWeathers");

            migrationBuilder.DropTable(
                name: "RouteWeathers");

            migrationBuilder.DropTable(
                name: "WeatherConditions");

            migrationBuilder.AddColumn<bool>(
                name: "AllowRain",
                table: "Places",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<double>(
                name: "MaxCloudCoverage",
                table: "Places",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "MaxHumidity",
                table: "Places",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "MaxRainProbability",
                table: "Places",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "MaxTemperature",
                table: "Places",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "MaxWindSpeed",
                table: "Places",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "MinTemperature",
                table: "Places",
                type: "float",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateOnly(2026, 2, 22));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AllowRain",
                table: "Places");

            migrationBuilder.DropColumn(
                name: "MaxCloudCoverage",
                table: "Places");

            migrationBuilder.DropColumn(
                name: "MaxHumidity",
                table: "Places");

            migrationBuilder.DropColumn(
                name: "MaxRainProbability",
                table: "Places");

            migrationBuilder.DropColumn(
                name: "MaxTemperature",
                table: "Places");

            migrationBuilder.DropColumn(
                name: "MaxWindSpeed",
                table: "Places");

            migrationBuilder.DropColumn(
                name: "MinTemperature",
                table: "Places");

            migrationBuilder.CreateTable(
                name: "WeatherConditions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConditionName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeatherConditions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DayTripWeathers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DayTripId = table.Column<int>(type: "int", nullable: false),
                    WeatherId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DayTripWeathers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DayTripWeathers_DayTrips_DayTripId",
                        column: x => x.DayTripId,
                        principalTable: "DayTrips",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DayTripWeathers_WeatherConditions_WeatherId",
                        column: x => x.WeatherId,
                        principalTable: "WeatherConditions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlaceWeathers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlaceId = table.Column<int>(type: "int", nullable: false),
                    WeatherId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlaceWeathers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlaceWeathers_Places_PlaceId",
                        column: x => x.PlaceId,
                        principalTable: "Places",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlaceWeathers_WeatherConditions_WeatherId",
                        column: x => x.WeatherId,
                        principalTable: "WeatherConditions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RouteWeathers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RouteId = table.Column<int>(type: "int", nullable: false),
                    WeatherId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RouteWeathers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RouteWeathers_Routes_RouteId",
                        column: x => x.RouteId,
                        principalTable: "Routes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RouteWeathers_WeatherConditions_WeatherId",
                        column: x => x.WeatherId,
                        principalTable: "WeatherConditions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateOnly(2026, 2, 20));

            migrationBuilder.CreateIndex(
                name: "IX_DayTripWeathers_DayTripId",
                table: "DayTripWeathers",
                column: "DayTripId");

            migrationBuilder.CreateIndex(
                name: "IX_DayTripWeathers_WeatherId",
                table: "DayTripWeathers",
                column: "WeatherId");

            migrationBuilder.CreateIndex(
                name: "IX_PlaceWeathers_PlaceId",
                table: "PlaceWeathers",
                column: "PlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_PlaceWeathers_WeatherId",
                table: "PlaceWeathers",
                column: "WeatherId");

            migrationBuilder.CreateIndex(
                name: "IX_RouteWeathers_RouteId",
                table: "RouteWeathers",
                column: "RouteId");

            migrationBuilder.CreateIndex(
                name: "IX_RouteWeathers_WeatherId",
                table: "RouteWeathers",
                column: "WeatherId");
        }
    }
}
