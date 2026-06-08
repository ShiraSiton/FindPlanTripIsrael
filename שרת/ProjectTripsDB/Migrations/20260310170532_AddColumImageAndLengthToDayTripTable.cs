using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectTripsDB.Migrations
{
    /// <inheritdoc />
    public partial class AddColumImageAndLengthToDayTripTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "DayTrips",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "TotalLengteKM",
                table: "DayTrips",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "DayTrips");

            migrationBuilder.DropColumn(
                name: "TotalLengteKM",
                table: "DayTrips");

        }
    }
}
