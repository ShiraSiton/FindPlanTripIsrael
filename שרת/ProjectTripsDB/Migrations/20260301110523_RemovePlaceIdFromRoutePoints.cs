using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectTripsDB.Migrations
{
    /// <inheritdoc />
    public partial class RemovePlaceIdFromRoutePoints : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoutePoints_Places_PlaceId",
                table: "RoutePoints");

            migrationBuilder.DropIndex(
                name: "IX_RoutePoints_PlaceId",
                table: "RoutePoints");

            migrationBuilder.DropColumn(
                name: "PlaceId",
                table: "RoutePoints");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateOnly(2026, 3, 1));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PlaceId",
                table: "RoutePoints",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RoutePoints_PlaceId",
                table: "RoutePoints",
                column: "PlaceId");

            migrationBuilder.AddForeignKey(
                name: "FK_RoutePoints_Places_PlaceId",
                table: "RoutePoints",
                column: "PlaceId",
                principalTable: "Places",
                principalColumn: "Id");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateOnly(2026, 2, 28));
        }
    }
}
