using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectTripsDB.Migrations
{
    /// <inheritdoc />
    public partial class CalculatedFieldsToDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Accessibility",
                table: "Routes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "AllowRain",
                table: "Routes",
                type: "bit",
                nullable: false,
                defaultValue: false);

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

            migrationBuilder.AddColumn<bool>(
                name: "HasCommonWeather",
                table: "Routes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<double>(
                name: "LengthKm",
                table: "Routes",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "MaxCloudCoverage",
                table: "Routes",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "MaxHumidity",
                table: "Routes",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "MaxRainProbability",
                table: "Routes",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "MaxTemperature",
                table: "Routes",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "MaxWindSpeed",
                table: "Routes",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "MinTemperature",
                table: "Routes",
                type: "float",
                nullable: true);

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

            migrationBuilder.AddColumn<bool>(
                name: "AllowRain",
                table: "DayTrips",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Difficulty",
                table: "DayTrips",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "MaxCloudCoverage",
                table: "DayTrips",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "MaxHumidity",
                table: "DayTrips",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "MaxRainProbability",
                table: "DayTrips",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "MaxTemperature",
                table: "DayTrips",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "MaxWindSpeed",
                table: "DayTrips",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "MinTemperature",
                table: "DayTrips",
                type: "float",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Accessibility",
                table: "Routes");

            migrationBuilder.DropColumn(
                name: "AllowRain",
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
                name: "HasCommonWeather",
                table: "Routes");

            migrationBuilder.DropColumn(
                name: "LengthKm",
                table: "Routes");

            migrationBuilder.DropColumn(
                name: "MaxCloudCoverage",
                table: "Routes");

            migrationBuilder.DropColumn(
                name: "MaxHumidity",
                table: "Routes");

            migrationBuilder.DropColumn(
                name: "MaxRainProbability",
                table: "Routes");

            migrationBuilder.DropColumn(
                name: "MaxTemperature",
                table: "Routes");

            migrationBuilder.DropColumn(
                name: "MaxWindSpeed",
                table: "Routes");

            migrationBuilder.DropColumn(
                name: "MinTemperature",
                table: "Routes");

            migrationBuilder.DropColumn(
                name: "OpeningTime",
                table: "Routes");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Routes");

            migrationBuilder.DropColumn(
                name: "AllowRain",
                table: "DayTrips");

            migrationBuilder.DropColumn(
                name: "Difficulty",
                table: "DayTrips");

            migrationBuilder.DropColumn(
                name: "MaxCloudCoverage",
                table: "DayTrips");

            migrationBuilder.DropColumn(
                name: "MaxHumidity",
                table: "DayTrips");

            migrationBuilder.DropColumn(
                name: "MaxRainProbability",
                table: "DayTrips");

            migrationBuilder.DropColumn(
                name: "MaxTemperature",
                table: "DayTrips");

            migrationBuilder.DropColumn(
                name: "MaxWindSpeed",
                table: "DayTrips");

            migrationBuilder.DropColumn(
                name: "MinTemperature",
                table: "DayTrips");
        }
    }
}
