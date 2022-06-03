using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ads.Migrations
{
    public partial class Ads11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Ads_AdGuid1",
                table: "Images");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Images",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Images_AdGuid1",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "AdGuid1",
                table: "Images");

            migrationBuilder.AddColumn<Guid>(
                name: "Guid",
                table: "Animals",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Images",
                table: "Images",
                column: "Guid");

            migrationBuilder.CreateIndex(
                name: "IX_Images_AdGuid",
                table: "Images",
                column: "AdGuid");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Ads_AdGuid",
                table: "Images",
                column: "AdGuid",
                principalTable: "Ads",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Ads_AdGuid",
                table: "Images");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Images",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Images_AdGuid",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "Guid",
                table: "Animals");

            migrationBuilder.AddColumn<Guid>(
                name: "AdGuid1",
                table: "Images",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Images",
                table: "Images",
                column: "AdGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Images_AdGuid1",
                table: "Images",
                column: "AdGuid1");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Ads_AdGuid1",
                table: "Images",
                column: "AdGuid1",
                principalTable: "Ads",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
