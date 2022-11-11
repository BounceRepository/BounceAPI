using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bounce_DbOps.Migrations
{
    public partial class added_UserProfile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserProfile",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MeansOfIdentification = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActivatePinLock = table.Column<bool>(type: "bit", nullable: false),
                    BecomeAnonymous = table.Column<bool>(type: "bit", nullable: false),
                    PhysicalHealthRate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MentalHealthRate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmotionalHealthRate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EatingHabit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfile", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserProfile_AspNetUsers_UserId",
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
                name: "IX_UserProfile_UserId",
                table: "UserProfile",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserProfile");

            migrationBuilder.UpdateData(
                table: "Plan",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 10, 20, 16, 46, 4, 228, DateTimeKind.Local).AddTicks(5016), new DateTime(2022, 10, 20, 16, 46, 4, 228, DateTimeKind.Local).AddTicks(5025) });

            migrationBuilder.UpdateData(
                table: "Plan",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 10, 20, 16, 46, 4, 228, DateTimeKind.Local).AddTicks(5052), new DateTime(2022, 10, 20, 16, 46, 4, 228, DateTimeKind.Local).AddTicks(5052) });

            migrationBuilder.UpdateData(
                table: "Plan",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 10, 20, 16, 46, 4, 228, DateTimeKind.Local).AddTicks(5063), new DateTime(2022, 10, 20, 16, 46, 4, 228, DateTimeKind.Local).AddTicks(5064) });
        }
    }
}
