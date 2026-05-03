using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fornspar.Data.Migrations
{
    /// <inheritdoc />
    public partial class Geometies : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Remnants_RemnantPlacement_RemnantPlacementDbId",
                table: "Remnants");

            migrationBuilder.DropForeignKey(
                name: "FK_Remnants_RemnantType_RemnantTypeDbId",
                table: "Remnants");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RemnantType",
                table: "RemnantType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RemnantPlacement",
                table: "RemnantPlacement");

            migrationBuilder.RenameTable(
                name: "RemnantType",
                newName: "RemnantTypes");

            migrationBuilder.RenameTable(
                name: "RemnantPlacement",
                newName: "RemnantPlacements");

            migrationBuilder.RenameColumn(
                name: "Geometry",
                table: "Remnants",
                newName: "Geometries");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RemnantTypes",
                table: "RemnantTypes",
                column: "DbId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RemnantPlacements",
                table: "RemnantPlacements",
                column: "DbId");

            migrationBuilder.AddForeignKey(
                name: "FK_Remnants_RemnantPlacements_RemnantPlacementDbId",
                table: "Remnants",
                column: "RemnantPlacementDbId",
                principalTable: "RemnantPlacements",
                principalColumn: "DbId");

            migrationBuilder.AddForeignKey(
                name: "FK_Remnants_RemnantTypes_RemnantTypeDbId",
                table: "Remnants",
                column: "RemnantTypeDbId",
                principalTable: "RemnantTypes",
                principalColumn: "DbId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Remnants_RemnantPlacements_RemnantPlacementDbId",
                table: "Remnants");

            migrationBuilder.DropForeignKey(
                name: "FK_Remnants_RemnantTypes_RemnantTypeDbId",
                table: "Remnants");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RemnantTypes",
                table: "RemnantTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RemnantPlacements",
                table: "RemnantPlacements");

            migrationBuilder.RenameTable(
                name: "RemnantTypes",
                newName: "RemnantType");

            migrationBuilder.RenameTable(
                name: "RemnantPlacements",
                newName: "RemnantPlacement");

            migrationBuilder.RenameColumn(
                name: "Geometries",
                table: "Remnants",
                newName: "Geometry");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RemnantType",
                table: "RemnantType",
                column: "DbId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RemnantPlacement",
                table: "RemnantPlacement",
                column: "DbId");

            migrationBuilder.AddForeignKey(
                name: "FK_Remnants_RemnantPlacement_RemnantPlacementDbId",
                table: "Remnants",
                column: "RemnantPlacementDbId",
                principalTable: "RemnantPlacement",
                principalColumn: "DbId");

            migrationBuilder.AddForeignKey(
                name: "FK_Remnants_RemnantType_RemnantTypeDbId",
                table: "Remnants",
                column: "RemnantTypeDbId",
                principalTable: "RemnantType",
                principalColumn: "DbId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
