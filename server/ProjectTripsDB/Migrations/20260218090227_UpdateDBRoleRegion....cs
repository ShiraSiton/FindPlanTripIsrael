using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectTripsDB.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDBRoleRegion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Routes_Regions_RegionId",
                table: "Routes");

            migrationBuilder.DropIndex(
                name: "IX_Routes_RegionId",
                table: "Routes");

            migrationBuilder.DropColumn(
                name: "RegionId",
                table: "Routes");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Email" },
                values: new object[] { new DateOnly(2026, 2, 18), "Admin@gmail.com" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RegionId",
                table: "Routes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Email" },
                values: new object[] { new DateOnly(2026, 2, 16), "Admin@admin.com" });

            migrationBuilder.CreateIndex(
                name: "IX_Routes_RegionId",
                table: "Routes",
                column: "RegionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Routes_Regions_RegionId",
                table: "Routes",
                column: "RegionId",
                principalTable: "Regions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
