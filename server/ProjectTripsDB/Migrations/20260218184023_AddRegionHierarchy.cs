using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectTripsDB.Migrations
{
    /// <inheritdoc />
    public partial class AddRegionHierarchy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "ParentRegionId",
                table: "Regions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Regions_ParentRegionId",
                table: "Regions",
                column: "ParentRegionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Regions_Regions_ParentRegionId",
                table: "Regions",
                column: "ParentRegionId",
                principalTable: "Regions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Regions_Regions_ParentRegionId",
                table: "Regions");

            migrationBuilder.DropIndex(
                name: "IX_Regions_ParentRegionId",
                table: "Regions");

            migrationBuilder.DropColumn(
                name: "ParentRegionId",
                table: "Regions");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "FirstName", "IsActive", "LastName", "Password", "Role" },
                values: new object[] { 1, new DateOnly(2026, 2, 18), "Admin@gmail.com", "Admin", true, "Admin", "Admin#613", 1 });
        }
    }
}
