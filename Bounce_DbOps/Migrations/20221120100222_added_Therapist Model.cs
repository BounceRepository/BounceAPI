using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bounce_DbOps.Migrations
{
    public partial class added_TherapistModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Descipline",
                table: "TherapistProfiles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "ServiceCharge",
                table: "TherapistProfiles",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReviewComment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RateCount = table.Column<int>(type: "int", nullable: false),
                    Time = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    TherapistUserId = table.Column<long>(type: "bigint", nullable: true),
                    PatientUserId = table.Column<long>(type: "bigint", nullable: true),
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
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_AspNetUsers_TherapistUserId",
                        column: x => x.TherapistUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 11, 20, 11, 2, 21, 773, DateTimeKind.Local).AddTicks(5563), new DateTime(2022, 11, 20, 11, 2, 21, 773, DateTimeKind.Local).AddTicks(5563) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 11, 20, 11, 2, 21, 773, DateTimeKind.Local).AddTicks(5585), new DateTime(2022, 11, 20, 11, 2, 21, 773, DateTimeKind.Local).AddTicks(5585) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 11, 20, 11, 2, 21, 773, DateTimeKind.Local).AddTicks(5593), new DateTime(2022, 11, 20, 11, 2, 21, 773, DateTimeKind.Local).AddTicks(5593) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 11, 20, 11, 2, 21, 773, DateTimeKind.Local).AddTicks(5600), new DateTime(2022, 11, 20, 11, 2, 21, 773, DateTimeKind.Local).AddTicks(5600) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 11, 20, 11, 2, 21, 773, DateTimeKind.Local).AddTicks(5606), new DateTime(2022, 11, 20, 11, 2, 21, 773, DateTimeKind.Local).AddTicks(5607) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 11, 20, 11, 2, 21, 773, DateTimeKind.Local).AddTicks(5615), new DateTime(2022, 11, 20, 11, 2, 21, 773, DateTimeKind.Local).AddTicks(5616) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 11, 20, 11, 2, 21, 773, DateTimeKind.Local).AddTicks(5622), new DateTime(2022, 11, 20, 11, 2, 21, 773, DateTimeKind.Local).AddTicks(5622) });

            migrationBuilder.UpdateData(
                table: "Plan",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 11, 20, 11, 2, 21, 773, DateTimeKind.Local).AddTicks(5501), new DateTime(2022, 11, 20, 11, 2, 21, 773, DateTimeKind.Local).AddTicks(5512) });

            migrationBuilder.UpdateData(
                table: "Plan",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 11, 20, 11, 2, 21, 773, DateTimeKind.Local).AddTicks(5539), new DateTime(2022, 11, 20, 11, 2, 21, 773, DateTimeKind.Local).AddTicks(5540) });

            migrationBuilder.UpdateData(
                table: "Plan",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 11, 20, 11, 2, 21, 773, DateTimeKind.Local).AddTicks(5547), new DateTime(2022, 11, 20, 11, 2, 21, 773, DateTimeKind.Local).AddTicks(5548) });

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_TherapistUserId",
                table: "Reviews",
                column: "TherapistUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropColumn(
                name: "Descipline",
                table: "TherapistProfiles");

            migrationBuilder.DropColumn(
                name: "ServiceCharge",
                table: "TherapistProfiles");

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 11, 20, 9, 1, 32, 153, DateTimeKind.Local).AddTicks(1596), new DateTime(2022, 11, 20, 9, 1, 32, 153, DateTimeKind.Local).AddTicks(1596) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 11, 20, 9, 1, 32, 153, DateTimeKind.Local).AddTicks(1611), new DateTime(2022, 11, 20, 9, 1, 32, 153, DateTimeKind.Local).AddTicks(1611) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 11, 20, 9, 1, 32, 153, DateTimeKind.Local).AddTicks(1623), new DateTime(2022, 11, 20, 9, 1, 32, 153, DateTimeKind.Local).AddTicks(1624) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 11, 20, 9, 1, 32, 153, DateTimeKind.Local).AddTicks(1634), new DateTime(2022, 11, 20, 9, 1, 32, 153, DateTimeKind.Local).AddTicks(1635) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 11, 20, 9, 1, 32, 153, DateTimeKind.Local).AddTicks(1659), new DateTime(2022, 11, 20, 9, 1, 32, 153, DateTimeKind.Local).AddTicks(1660) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 11, 20, 9, 1, 32, 153, DateTimeKind.Local).AddTicks(1676), new DateTime(2022, 11, 20, 9, 1, 32, 153, DateTimeKind.Local).AddTicks(1676) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 11, 20, 9, 1, 32, 153, DateTimeKind.Local).AddTicks(1687), new DateTime(2022, 11, 20, 9, 1, 32, 153, DateTimeKind.Local).AddTicks(1688) });

            migrationBuilder.UpdateData(
                table: "Plan",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 11, 20, 9, 1, 32, 153, DateTimeKind.Local).AddTicks(1512), new DateTime(2022, 11, 20, 9, 1, 32, 153, DateTimeKind.Local).AddTicks(1526) });

            migrationBuilder.UpdateData(
                table: "Plan",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 11, 20, 9, 1, 32, 153, DateTimeKind.Local).AddTicks(1558), new DateTime(2022, 11, 20, 9, 1, 32, 153, DateTimeKind.Local).AddTicks(1559) });

            migrationBuilder.UpdateData(
                table: "Plan",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 11, 20, 9, 1, 32, 153, DateTimeKind.Local).AddTicks(1571), new DateTime(2022, 11, 20, 9, 1, 32, 153, DateTimeKind.Local).AddTicks(1572) });
        }
    }
}
