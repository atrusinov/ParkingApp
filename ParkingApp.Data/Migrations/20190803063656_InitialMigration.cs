using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ParkingApp.Data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ParkingLots",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParkingLots", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ParkingLevels",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ParkingId = table.Column<int>(nullable: false),
                    Level = table.Column<int>(nullable: false),
                    IsFull = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParkingLevels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ParkingLevels_ParkingLots_ParkingId",
                        column: x => x.ParkingId,
                        principalTable: "ParkingLots",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ParkingSpaces",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SpaceNumber = table.Column<int>(nullable: false),
                    IsTaken = table.Column<bool>(nullable: false),
                    ParkingLevelId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParkingSpaces", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ParkingSpaces_ParkingLevels_ParkingLevelId",
                        column: x => x.ParkingLevelId,
                        principalTable: "ParkingLevels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ParkingLevels_Level",
                table: "ParkingLevels",
                column: "Level",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ParkingLevels_ParkingId",
                table: "ParkingLevels",
                column: "ParkingId");

            migrationBuilder.CreateIndex(
                name: "IX_ParkingSpaces_ParkingLevelId",
                table: "ParkingSpaces",
                column: "ParkingLevelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ParkingSpaces");

            migrationBuilder.DropTable(
                name: "ParkingLevels");

            migrationBuilder.DropTable(
                name: "ParkingLots");
        }
    }
}
