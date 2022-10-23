using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bounce_DbOps.Migrations
{
    public partial class removed_Biodata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BioData");

            migrationBuilder.AddColumn<string>(
                name: "Feelings",
                table: "UserProfile",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "ProfileId",
                table: "AspNetUsers",
                type: "bigint",
                nullable: true,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Plan",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 10, 23, 10, 22, 54, 493, DateTimeKind.Local).AddTicks(8447), new DateTime(2022, 10, 23, 10, 22, 54, 493, DateTimeKind.Local).AddTicks(8457) });

            migrationBuilder.UpdateData(
                table: "Plan",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 10, 23, 10, 22, 54, 493, DateTimeKind.Local).AddTicks(8481), new DateTime(2022, 10, 23, 10, 22, 54, 493, DateTimeKind.Local).AddTicks(8481) });

            migrationBuilder.UpdateData(
                table: "Plan",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 10, 23, 10, 22, 54, 493, DateTimeKind.Local).AddTicks(8490), new DateTime(2022, 10, 23, 10, 22, 54, 493, DateTimeKind.Local).AddTicks(8491) });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ProfileId",
                table: "AspNetUsers",
                column: "ProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_UserProfile_ProfileId",
                table: "AspNetUsers",
                column: "ProfileId",
                principalTable: "UserProfile",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_UserProfile_ProfileId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ProfileId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Feelings",
                table: "UserProfile");

            migrationBuilder.AlterColumn<long>(
                name: "ProfileId",
                table: "AspNetUsers",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.CreateTable(
                name: "BioData",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    ActivatePinLock = table.Column<bool>(type: "bit", nullable: false),
                    BecomeAnonymous = table.Column<bool>(type: "bit", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EatingHabit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmotionalHealthRate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MeansOfIdentification = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MentalHealthRate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhysicalHealthRate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BioData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BioData_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Plan",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 10, 23, 10, 4, 57, 344, DateTimeKind.Local).AddTicks(2705), new DateTime(2022, 10, 23, 10, 4, 57, 344, DateTimeKind.Local).AddTicks(2716) });

            migrationBuilder.UpdateData(
                table: "Plan",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 10, 23, 10, 4, 57, 344, DateTimeKind.Local).AddTicks(2751), new DateTime(2022, 10, 23, 10, 4, 57, 344, DateTimeKind.Local).AddTicks(2752) });

            migrationBuilder.UpdateData(
                table: "Plan",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 10, 23, 10, 4, 57, 344, DateTimeKind.Local).AddTicks(2767), new DateTime(2022, 10, 23, 10, 4, 57, 344, DateTimeKind.Local).AddTicks(2767) });

            migrationBuilder.CreateIndex(
                name: "IX_BioData_UserId",
                table: "BioData",
                column: "UserId",
                unique: true);
        }
    }
}
