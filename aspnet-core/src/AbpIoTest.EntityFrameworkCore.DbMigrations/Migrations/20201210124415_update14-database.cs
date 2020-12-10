using Microsoft.EntityFrameworkCore.Migrations;

namespace AbpIoTest.Migrations
{
    public partial class update14database : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppAttachmentDetail_AppAttachmentMaster_AttachmentMasterId1",
                table: "AppAttachmentDetail");

            migrationBuilder.DropIndex(
                name: "IX_AppAttachmentDetail_AttachmentMasterId1",
                table: "AppAttachmentDetail");

            migrationBuilder.DropColumn(
                name: "AttachmentMasterId1",
                table: "AppAttachmentDetail");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AttachmentMasterId1",
                table: "AppAttachmentDetail",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AppAttachmentDetail_AttachmentMasterId1",
                table: "AppAttachmentDetail",
                column: "AttachmentMasterId1");

            migrationBuilder.AddForeignKey(
                name: "FK_AppAttachmentDetail_AppAttachmentMaster_AttachmentMasterId1",
                table: "AppAttachmentDetail",
                column: "AttachmentMasterId1",
                principalTable: "AppAttachmentMaster",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
