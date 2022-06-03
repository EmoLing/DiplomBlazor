using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ads.Migrations
{
    public partial class Add4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "Guid",
                table: "Images",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Animals_ColorOfAnimalGuid",
                table: "Animals",
                column: "ColorOfAnimalGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Animals_KindOfAnimalGuid",
                table: "Animals",
                column: "KindOfAnimalGuid");

            migrationBuilder.AddForeignKey(
                name: "FK_Animals_ColorsOfAnimals_ColorOfAnimalGuid",
                table: "Animals",
                column: "ColorOfAnimalGuid",
                principalTable: "ColorsOfAnimals",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Animals_KindsOfAnimals_KindOfAnimalGuid",
                table: "Animals",
                column: "KindOfAnimalGuid",
                principalTable: "KindsOfAnimals",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Animals_ColorsOfAnimals_ColorOfAnimalGuid",
                table: "Animals");

            migrationBuilder.DropForeignKey(
                name: "FK_Animals_KindsOfAnimals_KindOfAnimalGuid",
                table: "Animals");

            migrationBuilder.DropIndex(
                name: "IX_Animals_ColorOfAnimalGuid",
                table: "Animals");

            migrationBuilder.DropIndex(
                name: "IX_Animals_KindOfAnimalGuid",
                table: "Animals");

            migrationBuilder.DropColumn(
                name: "Guid",
                table: "Images");
        }
    }
}
