using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bounce_DbOps.Migrations
{
    public partial class refNumber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Plan",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 10, 27, 13, 24, 57, 607, DateTimeKind.Local).AddTicks(6702), new DateTime(2022, 10, 27, 13, 24, 57, 607, DateTimeKind.Local).AddTicks(6711) });

            migrationBuilder.UpdateData(
                table: "Plan",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 10, 27, 13, 24, 57, 607, DateTimeKind.Local).AddTicks(6738), new DateTime(2022, 10, 27, 13, 24, 57, 607, DateTimeKind.Local).AddTicks(6738) });

            migrationBuilder.UpdateData(
                table: "Plan",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 10, 27, 13, 24, 57, 607, DateTimeKind.Local).AddTicks(6748), new DateTime(2022, 10, 27, 13, 24, 57, 607, DateTimeKind.Local).AddTicks(6748) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Plan",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 10, 27, 13, 24, 18, 540, DateTimeKind.Local).AddTicks(7474), new DateTime(2022, 10, 27, 13, 24, 18, 540, DateTimeKind.Local).AddTicks(7487) });

            migrationBuilder.UpdateData(
                table: "Plan",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 10, 27, 13, 24, 18, 540, DateTimeKind.Local).AddTicks(7513), new DateTime(2022, 10, 27, 13, 24, 18, 540, DateTimeKind.Local).AddTicks(7513) });

            migrationBuilder.UpdateData(
                table: "Plan",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 10, 27, 13, 24, 18, 540, DateTimeKind.Local).AddTicks(7521), new DateTime(2022, 10, 27, 13, 24, 18, 540, DateTimeKind.Local).AddTicks(7522) });
        }
    }
}
