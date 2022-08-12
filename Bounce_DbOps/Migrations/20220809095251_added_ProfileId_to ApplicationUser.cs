using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bounce_DbOps.Migrations
{
    public partial class added_ProfileId_toApplicationUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_BioDatas_UserId",
                table: "BioDatas");

            migrationBuilder.AddColumn<long>(
                name: "ProfileId",
                table: "AspNetUsers",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BioDatas_UserId",
                table: "BioDatas",
                column: "UserId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_BioDatas_UserId",
                table: "BioDatas");

            migrationBuilder.DropColumn(
                name: "ProfileId",
                table: "AspNetUsers");

            migrationBuilder.CreateIndex(
                name: "IX_BioDatas_UserId",
                table: "BioDatas",
                column: "UserId");
        }
    }
}
