using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectTripsDB.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCangeTableRouteRoutePoint : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoutePlaces_Places_PlaceId",
                table: "RoutePlaces");

            migrationBuilder.AlterColumn<double>(
                name: "DurationMinutes",
                table: "Routes",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "RegionAndCityId",
                table: "Routes",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PlaceId",
                table: "RoutePlaces",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "RoutePlaces",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "EstimatedStayMinutes",
                table: "RoutePlaces",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsEndPoint",
                table: "RoutePlaces",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsStartPoint",
                table: "RoutePlaces",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "RoutePlaces",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<double>(
                name: "EstimatedDuration",
                table: "DayTripItems",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Mode",
                table: "DayTripItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.AddForeignKey(
                name: "FK_RoutePlaces_Places_PlaceId",
                table: "RoutePlaces",
                column: "PlaceId",
                principalTable: "Places",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Routes_RegionAndCitys_RegionAndCityId",
                table: "Routes",
                column: "RegionAndCityId",
                principalTable: "RegionAndCitys",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoutePlaces_Places_PlaceId",
                table: "RoutePlaces");

            migrationBuilder.DropForeignKey(
                name: "FK_Routes_RegionAndCitys_RegionAndCityId",
                table: "Routes");

            migrationBuilder.DropIndex(
                name: "IX_Routes_RegionAndCityId",
                table: "Routes");

            migrationBuilder.DropColumn(
                name: "RegionAndCityId",
                table: "Routes");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "RoutePlaces");

            migrationBuilder.DropColumn(
                name: "EstimatedStayMinutes",
                table: "RoutePlaces");

            migrationBuilder.DropColumn(
                name: "IsEndPoint",
                table: "RoutePlaces");

            migrationBuilder.DropColumn(
                name: "IsStartPoint",
                table: "RoutePlaces");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "RoutePlaces");

            migrationBuilder.DropColumn(
                name: "Mode",
                table: "DayTripItems");

            migrationBuilder.AlterColumn<int>(
                name: "DurationMinutes",
                table: "Routes",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<int>(
                name: "PlaceId",
                table: "RoutePlaces",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EstimatedDuration",
                table: "DayTripItems",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateOnly(2026, 2, 22));

            migrationBuilder.AddForeignKey(
                name: "FK_RoutePlaces_Places_PlaceId",
                table: "RoutePlaces",
                column: "PlaceId",
                principalTable: "Places",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
