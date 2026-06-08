using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectTripsDB.Migrations
{
    /// <inheritdoc />
    public partial class ChangeTypeColumen : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DayTrips_DayTripTypes_DayTripTypeId",
                table: "DayTrips");

            migrationBuilder.DropForeignKey(
                name: "FK_DayTrips_Types_TypeId",
                table: "DayTrips");

            migrationBuilder.DropForeignKey(
                name: "FK_Places_PlaceTypes_PlaceTypeId",
                table: "Places");

            migrationBuilder.DropForeignKey(
                name: "FK_Places_Types_TypeId",
                table: "Places");

            migrationBuilder.DropForeignKey(
                name: "FK_Routes_RouteTypes_RouteTypeId",
                table: "Routes");

            migrationBuilder.DropForeignKey(
                name: "FK_Routes_Types_TypeId",
                table: "Routes");

            migrationBuilder.AlterColumn<int>(
                name: "TypeId",
                table: "Routes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RouteTypeId",
                table: "Routes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "TypeId",
                table: "Places",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PlaceTypeId",
                table: "Places",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "TypeId",
                table: "DayTrips",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DayTripTypeId",
                table: "DayTrips",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_DayTrips_DayTripTypes_DayTripTypeId",
                table: "DayTrips",
                column: "DayTripTypeId",
                principalTable: "DayTripTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DayTrips_Types_TypeId",
                table: "DayTrips",
                column: "TypeId",
                principalTable: "Types",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Places_PlaceTypes_PlaceTypeId",
                table: "Places",
                column: "PlaceTypeId",
                principalTable: "PlaceTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Places_Types_TypeId",
                table: "Places",
                column: "TypeId",
                principalTable: "Types",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Routes_RouteTypes_RouteTypeId",
                table: "Routes",
                column: "RouteTypeId",
                principalTable: "RouteTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Routes_Types_TypeId",
                table: "Routes",
                column: "TypeId",
                principalTable: "Types",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DayTrips_DayTripTypes_DayTripTypeId",
                table: "DayTrips");

            migrationBuilder.DropForeignKey(
                name: "FK_DayTrips_Types_TypeId",
                table: "DayTrips");

            migrationBuilder.DropForeignKey(
                name: "FK_Places_PlaceTypes_PlaceTypeId",
                table: "Places");

            migrationBuilder.DropForeignKey(
                name: "FK_Places_Types_TypeId",
                table: "Places");

            migrationBuilder.DropForeignKey(
                name: "FK_Routes_RouteTypes_RouteTypeId",
                table: "Routes");

            migrationBuilder.DropForeignKey(
                name: "FK_Routes_Types_TypeId",
                table: "Routes");

            migrationBuilder.AlterColumn<int>(
                name: "TypeId",
                table: "Routes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "RouteTypeId",
                table: "Routes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TypeId",
                table: "Places",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "PlaceTypeId",
                table: "Places",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TypeId",
                table: "DayTrips",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "DayTripTypeId",
                table: "DayTrips",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DayTrips_DayTripTypes_DayTripTypeId",
                table: "DayTrips",
                column: "DayTripTypeId",
                principalTable: "DayTripTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DayTrips_Types_TypeId",
                table: "DayTrips",
                column: "TypeId",
                principalTable: "Types",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Places_PlaceTypes_PlaceTypeId",
                table: "Places",
                column: "PlaceTypeId",
                principalTable: "PlaceTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Places_Types_TypeId",
                table: "Places",
                column: "TypeId",
                principalTable: "Types",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Routes_RouteTypes_RouteTypeId",
                table: "Routes",
                column: "RouteTypeId",
                principalTable: "RouteTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Routes_Types_TypeId",
                table: "Routes",
                column: "TypeId",
                principalTable: "Types",
                principalColumn: "Id");
        }
    }
}
