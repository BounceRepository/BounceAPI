using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bounce_DbOps.Migrations
{
    public partial class Added_gendertoBioDataTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "BioDatas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gender",
                table: "BioDatas");
        }
    }
}
