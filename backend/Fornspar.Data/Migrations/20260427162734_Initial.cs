using Microsoft.EntityFrameworkCore.Migrations;
using NetTopologySuite.Geometries;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Fornspar.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:PostgresExtension:postgis", ",,");

            migrationBuilder.CreateTable(
                name: "RemnantPlacement",
                columns: table => new
                {
                    DbId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Identifier = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RemnantPlacement", x => x.DbId);
                });

            migrationBuilder.CreateTable(
                name: "RemnantType",
                columns: table => new
                {
                    DbId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Identifier = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RemnantType", x => x.DbId);
                });

            migrationBuilder.CreateTable(
                name: "Remnants",
                columns: table => new
                {
                    DbId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Identifier = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Terrain = table.Column<string>(type: "text", nullable: true),
                    Orientation = table.Column<string>(type: "text", nullable: true),
                    Geometry = table.Column<Geometry>(type: "geometry", nullable: false),
                    RemnantTypeDbId = table.Column<int>(type: "integer", nullable: false),
                    RemnantPlacementDbId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Remnants", x => x.DbId);
                    table.ForeignKey(
                        name: "FK_Remnants_RemnantPlacement_RemnantPlacementDbId",
                        column: x => x.RemnantPlacementDbId,
                        principalTable: "RemnantPlacement",
                        principalColumn: "DbId");
                    table.ForeignKey(
                        name: "FK_Remnants_RemnantType_RemnantTypeDbId",
                        column: x => x.RemnantTypeDbId,
                        principalTable: "RemnantType",
                        principalColumn: "DbId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Remnants_RemnantPlacementDbId",
                table: "Remnants",
                column: "RemnantPlacementDbId");

            migrationBuilder.CreateIndex(
                name: "IX_Remnants_RemnantTypeDbId",
                table: "Remnants",
                column: "RemnantTypeDbId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Remnants");

            migrationBuilder.DropTable(
                name: "RemnantPlacement");

            migrationBuilder.DropTable(
                name: "RemnantType");
        }
    }
}
