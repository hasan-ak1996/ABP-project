using Microsoft.EntityFrameworkCore.Migrations;

namespace AbpIoTest.Migrations
{
    public partial class update2item : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrderId1",
                table: "AppItem",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AppItem_OrderId1",
                table: "AppItem",
                column: "OrderId1");

            migrationBuilder.AddForeignKey(
                name: "FK_AppItem_AppOrder_OrderId1",
                table: "AppItem",
                column: "OrderId1",
                principalTable: "AppOrder",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppItem_AppOrder_OrderId1",
                table: "AppItem");

            migrationBuilder.DropIndex(
                name: "IX_AppItem_OrderId1",
                table: "AppItem");

            migrationBuilder.DropColumn(
                name: "OrderId1",
                table: "AppItem");
        }
    }
}
