using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectTripsDB.Migrations
{
    /// <inheritdoc />
    public partial class updateRouteTableRemoveCalculatedFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Accessibility",
                table: "Routes");

            migrationBuilder.DropColumn(
                name: "ClosingTime",
                table: "Routes");

            migrationBuilder.DropColumn(
                name: "Difficulty",
                table: "Routes");

            migrationBuilder.DropColumn(
                name: "DurationMinutes",
                table: "Routes");

            migrationBuilder.DropColumn(
                name: "LengthKm",
                table: "Routes");

            migrationBuilder.DropColumn(
                name: "OpeningTime",
                table: "Routes");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Routes");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Accessibility",
                table: "Routes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<TimeOnly>(
                name: "ClosingTime",
                table: "Routes",
                type: "time",
                nullable: false,
                defaultValue: new TimeOnly(0, 0, 0));

            migrationBuilder.AddColumn<int>(
                name: "Difficulty",
                table: "Routes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "DurationMinutes",
                table: "Routes",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "LengthKm",
                table: "Routes",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<TimeOnly>(
                name: "OpeningTime",
                table: "Routes",
                type: "time",
                nullable: false,
                defaultValue: new TimeOnly(0, 0, 0));

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "Routes",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
