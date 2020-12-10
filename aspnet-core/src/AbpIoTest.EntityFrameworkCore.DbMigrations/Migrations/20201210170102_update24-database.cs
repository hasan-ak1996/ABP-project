using Microsoft.EntityFrameworkCore.Migrations;

namespace AbpIoTest.Migrations
{
    public partial class update24database : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AttachmentMasterId",
                table: "AppOrder",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_AppOrder_AttachmentMasterId",
                table: "AppOrder",
                column: "AttachmentMasterId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppOrder_AppAttachmentMaster_AttachmentMasterId",
                table: "AppOrder",
                column: "AttachmentMasterId",
                principalTable: "AppAttachmentMaster",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
