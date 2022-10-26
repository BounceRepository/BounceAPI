using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bounce_DbOps.Migrations
{
    public partial class added_deviceId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DeviceId",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NotificationToken",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Plan",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 10, 26, 13, 19, 35, 757, DateTimeKind.Local).AddTicks(336), new DateTime(2022, 10, 26, 13, 19, 35, 757, DateTimeKind.Local).AddTicks(346) });

            migrationBuilder.UpdateData(
                table: "Plan",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 10, 26, 13, 19, 35, 757, DateTimeKind.Local).AddTicks(365), new DateTime(2022, 10, 26, 13, 19, 35, 757, DateTimeKind.Local).AddTicks(366) });

            migrationBuilder.UpdateData(
                table: "Plan",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 10, 26, 13, 19, 35, 757, DateTimeKind.Local).AddTicks(373), new DateTime(2022, 10, 26, 13, 19, 35, 757, DateTimeKind.Local).AddTicks(374) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeviceId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "NotificationToken",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "Plan",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 10, 23, 21, 26, 28, 562, DateTimeKind.Local).AddTicks(4880), new DateTime(2022, 10, 23, 21, 26, 28, 562, DateTimeKind.Local).AddTicks(4891) });

            migrationBuilder.UpdateData(
                table: "Plan",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 10, 23, 21, 26, 28, 562, DateTimeKind.Local).AddTicks(4927), new DateTime(2022, 10, 23, 21, 26, 28, 562, DateTimeKind.Local).AddTicks(4928) });

            migrationBuilder.UpdateData(
                table: "Plan",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 10, 23, 21, 26, 28, 562, DateTimeKind.Local).AddTicks(4942), new DateTime(2022, 10, 23, 21, 26, 28, 562, DateTimeKind.Local).AddTicks(4942) });
        }
    }
}
