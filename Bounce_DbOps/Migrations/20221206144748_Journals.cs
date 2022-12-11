using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bounce_DbOps.Migrations
{
    public partial class Journals : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Journals",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedById = table.Column<long>(type: "bigint", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedTimeOffset = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    ModifiedTimeOffset = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Journals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Journals_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 6, 15, 47, 48, 80, DateTimeKind.Local).AddTicks(2497), new DateTime(2022, 12, 6, 15, 47, 48, 80, DateTimeKind.Local).AddTicks(2498) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 6, 15, 47, 48, 80, DateTimeKind.Local).AddTicks(2508), new DateTime(2022, 12, 6, 15, 47, 48, 80, DateTimeKind.Local).AddTicks(2508) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 6, 15, 47, 48, 80, DateTimeKind.Local).AddTicks(2516), new DateTime(2022, 12, 6, 15, 47, 48, 80, DateTimeKind.Local).AddTicks(2516) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 6, 15, 47, 48, 80, DateTimeKind.Local).AddTicks(2523), new DateTime(2022, 12, 6, 15, 47, 48, 80, DateTimeKind.Local).AddTicks(2524) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 6, 15, 47, 48, 80, DateTimeKind.Local).AddTicks(2542), new DateTime(2022, 12, 6, 15, 47, 48, 80, DateTimeKind.Local).AddTicks(2543) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 6, 15, 47, 48, 80, DateTimeKind.Local).AddTicks(2551), new DateTime(2022, 12, 6, 15, 47, 48, 80, DateTimeKind.Local).AddTicks(2552) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 6, 15, 47, 48, 80, DateTimeKind.Local).AddTicks(2559), new DateTime(2022, 12, 6, 15, 47, 48, 80, DateTimeKind.Local).AddTicks(2560) });

            migrationBuilder.UpdateData(
                table: "Plan",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 6, 15, 47, 48, 80, DateTimeKind.Local).AddTicks(2431), new DateTime(2022, 12, 6, 15, 47, 48, 80, DateTimeKind.Local).AddTicks(2445) });

            migrationBuilder.UpdateData(
                table: "Plan",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 6, 15, 47, 48, 80, DateTimeKind.Local).AddTicks(2470), new DateTime(2022, 12, 6, 15, 47, 48, 80, DateTimeKind.Local).AddTicks(2470) });

            migrationBuilder.UpdateData(
                table: "Plan",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 6, 15, 47, 48, 80, DateTimeKind.Local).AddTicks(2479), new DateTime(2022, 12, 6, 15, 47, 48, 80, DateTimeKind.Local).AddTicks(2479) });

            migrationBuilder.CreateIndex(
                name: "IX_Journals_CreatedById",
                table: "Journals",
                column: "CreatedById");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Journals");

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 3, 20, 55, 48, 839, DateTimeKind.Local).AddTicks(250), new DateTime(2022, 12, 3, 20, 55, 48, 839, DateTimeKind.Local).AddTicks(250) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 3, 20, 55, 48, 839, DateTimeKind.Local).AddTicks(264), new DateTime(2022, 12, 3, 20, 55, 48, 839, DateTimeKind.Local).AddTicks(264) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 3, 20, 55, 48, 839, DateTimeKind.Local).AddTicks(273), new DateTime(2022, 12, 3, 20, 55, 48, 839, DateTimeKind.Local).AddTicks(273) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 3, 20, 55, 48, 839, DateTimeKind.Local).AddTicks(282), new DateTime(2022, 12, 3, 20, 55, 48, 839, DateTimeKind.Local).AddTicks(282) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 3, 20, 55, 48, 839, DateTimeKind.Local).AddTicks(291), new DateTime(2022, 12, 3, 20, 55, 48, 839, DateTimeKind.Local).AddTicks(291) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 3, 20, 55, 48, 839, DateTimeKind.Local).AddTicks(301), new DateTime(2022, 12, 3, 20, 55, 48, 839, DateTimeKind.Local).AddTicks(302) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 3, 20, 55, 48, 839, DateTimeKind.Local).AddTicks(324), new DateTime(2022, 12, 3, 20, 55, 48, 839, DateTimeKind.Local).AddTicks(324) });

            migrationBuilder.UpdateData(
                table: "Plan",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 3, 20, 55, 48, 839, DateTimeKind.Local).AddTicks(183), new DateTime(2022, 12, 3, 20, 55, 48, 839, DateTimeKind.Local).AddTicks(193) });

            migrationBuilder.UpdateData(
                table: "Plan",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 3, 20, 55, 48, 839, DateTimeKind.Local).AddTicks(223), new DateTime(2022, 12, 3, 20, 55, 48, 839, DateTimeKind.Local).AddTicks(223) });

            migrationBuilder.UpdateData(
                table: "Plan",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 3, 20, 55, 48, 839, DateTimeKind.Local).AddTicks(235), new DateTime(2022, 12, 3, 20, 55, 48, 839, DateTimeKind.Local).AddTicks(235) });
        }
    }
}
