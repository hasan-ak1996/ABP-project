using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AbpIoTest.Migrations
{
    public partial class updatemigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "DeleterId",
                table: "AppOrder",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "AppOrder",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "AppOrder",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "DeleterId",
                table: "AppItem",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "AppItem",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "AppItem",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ItemId",
                table: "AppItem",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AppItem_ItemId",
                table: "AppItem",
                column: "ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppItem_AppItem_ItemId",
                table: "AppItem",
                column: "ItemId",
                principalTable: "AppItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppItem_AppItem_ItemId",
                table: "AppItem");

            migrationBuilder.DropIndex(
                name: "IX_AppItem_ItemId",
                table: "AppItem");

            migrationBuilder.DropColumn(
                name: "DeleterId",
                table: "AppOrder");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "AppOrder");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "AppOrder");

            migrationBuilder.DropColumn(
                name: "DeleterId",
                table: "AppItem");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "AppItem");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "AppItem");

            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "AppItem");
        }
    }
}
