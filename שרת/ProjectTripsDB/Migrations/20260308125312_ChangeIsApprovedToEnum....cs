using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectTripsDB.Migrations
{
    /// <inheritdoc />
    public partial class ChangeIsApprovedToEnum : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "Routes");

            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "Places");

            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "DayTrips");

            migrationBuilder.AddColumn<int>(
                name: "ApprovalStatus",
                table: "Routes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "ApprovedAt",
                table: "Routes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RejectReason",
                table: "Routes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ApprovalStatus",
                table: "Places",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "ApprovedAt",
                table: "Places",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RejectReason",
                table: "Places",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ApprovalStatus",
                table: "DayTrips",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "ApprovedAt",
                table: "DayTrips",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RejectReason",
                table: "DayTrips",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApprovalStatus",
                table: "Routes");

            migrationBuilder.DropColumn(
                name: "ApprovedAt",
                table: "Routes");

            migrationBuilder.DropColumn(
                name: "RejectReason",
                table: "Routes");

            migrationBuilder.DropColumn(
                name: "ApprovalStatus",
                table: "Places");

            migrationBuilder.DropColumn(
                name: "ApprovedAt",
                table: "Places");

            migrationBuilder.DropColumn(
                name: "RejectReason",
                table: "Places");

            migrationBuilder.DropColumn(
                name: "ApprovalStatus",
                table: "DayTrips");

            migrationBuilder.DropColumn(
                name: "ApprovedAt",
                table: "DayTrips");

            migrationBuilder.DropColumn(
                name: "RejectReason",
                table: "DayTrips");

            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "Routes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "Places",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "DayTrips",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
