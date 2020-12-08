using Microsoft.EntityFrameworkCore.Migrations;

namespace AbpIoTest.Migrations
{
    public partial class updateitem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppItem_AppItem_ItemId",
                table: "AppItem");

            migrationBuilder.DropIndex(
                name: "IX_AppItem_ItemId",
                table: "AppItem");

            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "AppItem");

            migrationBuilder.CreateIndex(
                name: "IX_AppItem_OrderId",
                table: "AppItem",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppItem_AppOrder_OrderId",
                table: "AppItem",
                column: "OrderId",
                principalTable: "AppOrder",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppItem_AppOrder_OrderId",
                table: "AppItem");

            migrationBuilder.DropIndex(
                name: "IX_AppItem_OrderId",
                table: "AppItem");

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
    }
}
