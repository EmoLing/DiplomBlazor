using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ads.Migrations
{
    public partial class Ad5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsOtherKindName",
                table: "KindsOfAnimals");

            migrationBuilder.DropColumn(
                name: "OtherKindName",
                table: "KindsOfAnimals");

            migrationBuilder.DropColumn(
                name: "IsOtherColor",
                table: "ColorsOfAnimals");

            migrationBuilder.DropColumn(
                name: "OtherColorName",
                table: "ColorsOfAnimals");

            migrationBuilder.AddColumn<bool>(
                name: "IsOtherColorOfAnimal",
                table: "Animals",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsOtherKindOfAnimal",
                table: "Animals",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "OtherColorOfAnimal",
                table: "Animals",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OtherKindOfAnimal",
                table: "Animals",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsOtherColorOfAnimal",
                table: "Animals");

            migrationBuilder.DropColumn(
                name: "IsOtherKindOfAnimal",
                table: "Animals");

            migrationBuilder.DropColumn(
                name: "OtherColorOfAnimal",
                table: "Animals");

            migrationBuilder.DropColumn(
                name: "OtherKindOfAnimal",
                table: "Animals");

            migrationBuilder.AddColumn<bool>(
                name: "IsOtherKindName",
                table: "KindsOfAnimals",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "OtherKindName",
                table: "KindsOfAnimals",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsOtherColor",
                table: "ColorsOfAnimals",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "OtherColorName",
                table: "ColorsOfAnimals",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
