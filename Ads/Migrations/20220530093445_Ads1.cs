using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ads.Migrations
{
    public partial class Ads1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ads",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeAd = table.Column<int>(type: "int", nullable: false),
                    StatusAd = table.Column<int>(type: "int", nullable: false),
                    DateCreate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ads", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "ColorsOfAnimals",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ColorName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsOtherColor = table.Column<bool>(type: "bit", nullable: false),
                    OtherColorName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ColorsOfAnimals", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "KindsOfAnimals",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    KindName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsOtherKindName = table.Column<bool>(type: "bit", nullable: false),
                    OtherKindName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KindsOfAnimals", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "AdCoordinates",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AdGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Latitude = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Longitude = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdCoordinates", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_AdCoordinates_Ads_AdGuid",
                        column: x => x.AdGuid,
                        principalTable: "Ads",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Animals",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AnimalName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    KindOfAnimalGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SexAnimal = table.Column<int>(type: "int", nullable: false),
                    ColorOfAnimalGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animals", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_Animals_Ads_AdGuid",
                        column: x => x.AdGuid,
                        principalTable: "Ads",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AdGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImageHash = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_Images_Ads_AdGuid",
                        column: x => x.AdGuid,
                        principalTable: "Ads",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdCoordinates_AdGuid",
                table: "AdCoordinates",
                column: "AdGuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Animals_AdGuid",
                table: "Animals",
                column: "AdGuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Images_AdGuid",
                table: "Images",
                column: "AdGuid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdCoordinates");

            migrationBuilder.DropTable(
                name: "Animals");

            migrationBuilder.DropTable(
                name: "ColorsOfAnimals");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "KindsOfAnimals");

            migrationBuilder.DropTable(
                name: "Ads");
        }
    }
}
