using Microsoft.EntityFrameworkCore.Migrations;

namespace AbpIoTest.Migrations
{
    public partial class update25database : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {



        }
    }
}
