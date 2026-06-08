using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectTripsDB.Migrations
{
    /// <inheritdoc />
    public partial class AddTypeTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TypeId",
                table: "Routes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TypeId",
                table: "Places",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TypeId",
                table: "DayTrips",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Types",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContentType = table.Column<int>(type: "int", nullable: false),
                    TypeName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Types", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateOnly(2026, 3, 12));

            migrationBuilder.CreateIndex(
                name: "IX_Routes_TypeId",
                table: "Routes",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Places_TypeId",
                table: "Places",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_DayTrips_TypeId",
                table: "DayTrips",
                column: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_DayTrips_Types_TypeId",
                table: "DayTrips",
                column: "TypeId",
                principalTable: "Types",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Places_Types_TypeId",
                table: "Places",
                column: "TypeId",
                principalTable: "Types",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Routes_Types_TypeId",
                table: "Routes",
                column: "TypeId",
                principalTable: "Types",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DayTrips_Types_TypeId",
                table: "DayTrips");

            migrationBuilder.DropForeignKey(
                name: "FK_Places_Types_TypeId",
                table: "Places");

            migrationBuilder.DropForeignKey(
                name: "FK_Routes_Types_TypeId",
                table: "Routes");

            migrationBuilder.DropTable(
                name: "Types");

            migrationBuilder.DropIndex(
                name: "IX_Routes_TypeId",
                table: "Routes");

            migrationBuilder.DropIndex(
                name: "IX_Places_TypeId",
                table: "Places");

            migrationBuilder.DropIndex(
                name: "IX_DayTrips_TypeId",
                table: "DayTrips");

            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "Routes");

            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "Places");

            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "DayTrips");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateOnly(2026, 3, 11));
        }
    }
}
