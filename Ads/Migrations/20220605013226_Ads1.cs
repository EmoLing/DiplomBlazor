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
                    UserGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    Position = table.Column<int>(type: "int", nullable: false)
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
                    Position = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KindsOfAnimals", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "AdCoordinates",
                columns: table => new
                {
                    AdGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Latitude = table.Column<decimal>(type: "decimal(36,18)", precision: 36, scale: 18, nullable: false),
                    Longitude = table.Column<decimal>(type: "decimal(36,18)", precision: 36, scale: 18, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdCoordinates", x => x.AdGuid);
                    table.ForeignKey(
                        name: "FK_AdCoordinates_Ads_AdGuid",
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

            migrationBuilder.CreateTable(
                name: "Animals",
                columns: table => new
                {
                    AdGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AnimalName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KindOfAnimalGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SexAnimal = table.Column<int>(type: "int", nullable: false),
                    ColorOfAnimalGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsOtherKindOfAnimal = table.Column<bool>(type: "bit", nullable: false),
                    OtherKindOfAnimal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsOtherColorOfAnimal = table.Column<bool>(type: "bit", nullable: false),
                    OtherColorOfAnimal = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animals", x => x.AdGuid);
                    table.ForeignKey(
                        name: "FK_Animals_Ads_AdGuid",
                        column: x => x.AdGuid,
                        principalTable: "Ads",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Animals_ColorsOfAnimals_ColorOfAnimalGuid",
                        column: x => x.ColorOfAnimalGuid,
                        principalTable: "ColorsOfAnimals",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Animals_KindsOfAnimals_KindOfAnimalGuid",
                        column: x => x.KindOfAnimalGuid,
                        principalTable: "KindsOfAnimals",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Animals_ColorOfAnimalGuid",
                table: "Animals",
                column: "ColorOfAnimalGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Animals_KindOfAnimalGuid",
                table: "Animals",
                column: "KindOfAnimalGuid");

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
                name: "Images");

            migrationBuilder.DropTable(
                name: "ColorsOfAnimals");

            migrationBuilder.DropTable(
                name: "KindsOfAnimals");

            migrationBuilder.DropTable(
                name: "Ads");
        }
    }
}
