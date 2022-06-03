using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ads.Migrations
{
    public partial class Add3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropPrimaryKey(
                name: "PK_Animals",
                table: "Animals");

            migrationBuilder.DropIndex(
                name: "IX_Animals_AdGuid",
                table: "Animals");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AdCoordinates",
                table: "AdCoordinates");

            migrationBuilder.DropIndex(
                name: "IX_AdCoordinates_AdGuid",
                table: "AdCoordinates");

            migrationBuilder.DropColumn(
                name: "Guid",
                table: "AdCoordinates");

            migrationBuilder.RenameColumn(
                name: "Guid",
                table: "Images",
                newName: "AdGuid1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Images",
                table: "Images",
                column: "AdGuid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Animals",
                table: "Animals",
                column: "AdGuid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AdCoordinates",
                table: "AdCoordinates",
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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropPrimaryKey(
                name: "PK_Animals",
                table: "Animals");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AdCoordinates",
                table: "AdCoordinates");

            migrationBuilder.RenameColumn(
                name: "AdGuid1",
                table: "Images",
                newName: "Guid");

            migrationBuilder.AddColumn<Guid>(
                name: "Guid",
                table: "AdCoordinates",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Images",
                table: "Images",
                column: "Guid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Animals",
                table: "Animals",
                column: "Guid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AdCoordinates",
                table: "AdCoordinates",
                column: "Guid");

            migrationBuilder.CreateIndex(
                name: "IX_Images_AdGuid",
                table: "Images",
                column: "AdGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Animals_AdGuid",
                table: "Animals",
                column: "AdGuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AdCoordinates_AdGuid",
                table: "AdCoordinates",
                column: "AdGuid",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Ads_AdGuid",
                table: "Images",
                column: "AdGuid",
                principalTable: "Ads",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
