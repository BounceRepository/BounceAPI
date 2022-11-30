using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bounce_DbOps.Migrations
{
    public partial class added_EmailRequest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "EndTime",
                table: "AppointmentRequest",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "StartTime",
                table: "AppointmentRequest",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "FailedEmailRequests",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    To = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false),
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
                    table.PrimaryKey("PK_FailedEmailRequests", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 11, 30, 17, 23, 31, 873, DateTimeKind.Local).AddTicks(8912), new DateTime(2022, 11, 30, 17, 23, 31, 873, DateTimeKind.Local).AddTicks(8913) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 11, 30, 17, 23, 31, 873, DateTimeKind.Local).AddTicks(8923), new DateTime(2022, 11, 30, 17, 23, 31, 873, DateTimeKind.Local).AddTicks(8924) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 11, 30, 17, 23, 31, 873, DateTimeKind.Local).AddTicks(8931), new DateTime(2022, 11, 30, 17, 23, 31, 873, DateTimeKind.Local).AddTicks(8931) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 11, 30, 17, 23, 31, 873, DateTimeKind.Local).AddTicks(8938), new DateTime(2022, 11, 30, 17, 23, 31, 873, DateTimeKind.Local).AddTicks(8939) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 11, 30, 17, 23, 31, 873, DateTimeKind.Local).AddTicks(8946), new DateTime(2022, 11, 30, 17, 23, 31, 873, DateTimeKind.Local).AddTicks(8946) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 11, 30, 17, 23, 31, 873, DateTimeKind.Local).AddTicks(8956), new DateTime(2022, 11, 30, 17, 23, 31, 873, DateTimeKind.Local).AddTicks(8956) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 11, 30, 17, 23, 31, 873, DateTimeKind.Local).AddTicks(8963), new DateTime(2022, 11, 30, 17, 23, 31, 873, DateTimeKind.Local).AddTicks(8964) });

            migrationBuilder.UpdateData(
                table: "Plan",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 11, 30, 17, 23, 31, 873, DateTimeKind.Local).AddTicks(8854), new DateTime(2022, 11, 30, 17, 23, 31, 873, DateTimeKind.Local).AddTicks(8864) });

            migrationBuilder.UpdateData(
                table: "Plan",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 11, 30, 17, 23, 31, 873, DateTimeKind.Local).AddTicks(8888), new DateTime(2022, 11, 30, 17, 23, 31, 873, DateTimeKind.Local).AddTicks(8888) });

            migrationBuilder.UpdateData(
                table: "Plan",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 11, 30, 17, 23, 31, 873, DateTimeKind.Local).AddTicks(8897), new DateTime(2022, 11, 30, 17, 23, 31, 873, DateTimeKind.Local).AddTicks(8897) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FailedEmailRequests");

            migrationBuilder.DropColumn(
                name: "EndTime",
                table: "AppointmentRequest");

            migrationBuilder.DropColumn(
                name: "StartTime",
                table: "AppointmentRequest");

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
        }
    }
}
