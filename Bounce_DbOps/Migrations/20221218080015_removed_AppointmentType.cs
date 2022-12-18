using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bounce_DbOps.Migrations
{
    public partial class removed_AppointmentType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AppointmentType",
                table: "AppointmentRequest");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "AppointmentRequest");

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 18, 9, 0, 15, 433, DateTimeKind.Local).AddTicks(6473), new DateTime(2022, 12, 18, 9, 0, 15, 433, DateTimeKind.Local).AddTicks(6473) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 18, 9, 0, 15, 433, DateTimeKind.Local).AddTicks(6483), new DateTime(2022, 12, 18, 9, 0, 15, 433, DateTimeKind.Local).AddTicks(6483) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 18, 9, 0, 15, 433, DateTimeKind.Local).AddTicks(6490), new DateTime(2022, 12, 18, 9, 0, 15, 433, DateTimeKind.Local).AddTicks(6490) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 18, 9, 0, 15, 433, DateTimeKind.Local).AddTicks(6496), new DateTime(2022, 12, 18, 9, 0, 15, 433, DateTimeKind.Local).AddTicks(6497) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 18, 9, 0, 15, 433, DateTimeKind.Local).AddTicks(6503), new DateTime(2022, 12, 18, 9, 0, 15, 433, DateTimeKind.Local).AddTicks(6503) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 18, 9, 0, 15, 433, DateTimeKind.Local).AddTicks(6510), new DateTime(2022, 12, 18, 9, 0, 15, 433, DateTimeKind.Local).AddTicks(6511) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 18, 9, 0, 15, 433, DateTimeKind.Local).AddTicks(6517), new DateTime(2022, 12, 18, 9, 0, 15, 433, DateTimeKind.Local).AddTicks(6517) });

            migrationBuilder.UpdateData(
                table: "Plan",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 18, 9, 0, 15, 433, DateTimeKind.Local).AddTicks(6307), new DateTime(2022, 12, 18, 9, 0, 15, 433, DateTimeKind.Local).AddTicks(6317) });

            migrationBuilder.UpdateData(
                table: "Plan",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 18, 9, 0, 15, 433, DateTimeKind.Local).AddTicks(6340), new DateTime(2022, 12, 18, 9, 0, 15, 433, DateTimeKind.Local).AddTicks(6341) });

            migrationBuilder.UpdateData(
                table: "Plan",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 18, 9, 0, 15, 433, DateTimeKind.Local).AddTicks(6348), new DateTime(2022, 12, 18, 9, 0, 15, 433, DateTimeKind.Local).AddTicks(6348) });

            migrationBuilder.UpdateData(
                table: "SubPlan",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 18, 9, 0, 15, 433, DateTimeKind.Local).AddTicks(6387), new DateTime(2022, 12, 18, 9, 0, 15, 433, DateTimeKind.Local).AddTicks(6388) });

            migrationBuilder.UpdateData(
                table: "SubPlan",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 18, 9, 0, 15, 433, DateTimeKind.Local).AddTicks(6400), new DateTime(2022, 12, 18, 9, 0, 15, 433, DateTimeKind.Local).AddTicks(6400) });

            migrationBuilder.UpdateData(
                table: "SubPlan",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 18, 9, 0, 15, 433, DateTimeKind.Local).AddTicks(6407), new DateTime(2022, 12, 18, 9, 0, 15, 433, DateTimeKind.Local).AddTicks(6407) });

            migrationBuilder.UpdateData(
                table: "SubPlan",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 18, 9, 0, 15, 433, DateTimeKind.Local).AddTicks(6413), new DateTime(2022, 12, 18, 9, 0, 15, 433, DateTimeKind.Local).AddTicks(6414) });

            migrationBuilder.UpdateData(
                table: "SubPlan",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 18, 9, 0, 15, 433, DateTimeKind.Local).AddTicks(6429), new DateTime(2022, 12, 18, 9, 0, 15, 433, DateTimeKind.Local).AddTicks(6429) });

            migrationBuilder.UpdateData(
                table: "SubPlan",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 18, 9, 0, 15, 433, DateTimeKind.Local).AddTicks(6436), new DateTime(2022, 12, 18, 9, 0, 15, 433, DateTimeKind.Local).AddTicks(6437) });

            migrationBuilder.UpdateData(
                table: "SubPlan",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 18, 9, 0, 15, 433, DateTimeKind.Local).AddTicks(6443), new DateTime(2022, 12, 18, 9, 0, 15, 433, DateTimeKind.Local).AddTicks(6443) });

            migrationBuilder.UpdateData(
                table: "SubPlan",
                keyColumn: "Id",
                keyValue: 8L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 18, 9, 0, 15, 433, DateTimeKind.Local).AddTicks(6450), new DateTime(2022, 12, 18, 9, 0, 15, 433, DateTimeKind.Local).AddTicks(6450) });

            migrationBuilder.UpdateData(
                table: "SubPlan",
                keyColumn: "Id",
                keyValue: 9L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 18, 9, 0, 15, 433, DateTimeKind.Local).AddTicks(6456), new DateTime(2022, 12, 18, 9, 0, 15, 433, DateTimeKind.Local).AddTicks(6456) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AppointmentType",
                table: "AppointmentRequest",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "AppointmentRequest",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 18, 8, 17, 35, 196, DateTimeKind.Local).AddTicks(9062), new DateTime(2022, 12, 18, 8, 17, 35, 196, DateTimeKind.Local).AddTicks(9062) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 18, 8, 17, 35, 196, DateTimeKind.Local).AddTicks(9072), new DateTime(2022, 12, 18, 8, 17, 35, 196, DateTimeKind.Local).AddTicks(9072) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 18, 8, 17, 35, 196, DateTimeKind.Local).AddTicks(9079), new DateTime(2022, 12, 18, 8, 17, 35, 196, DateTimeKind.Local).AddTicks(9079) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 18, 8, 17, 35, 196, DateTimeKind.Local).AddTicks(9086), new DateTime(2022, 12, 18, 8, 17, 35, 196, DateTimeKind.Local).AddTicks(9086) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 18, 8, 17, 35, 196, DateTimeKind.Local).AddTicks(9092), new DateTime(2022, 12, 18, 8, 17, 35, 196, DateTimeKind.Local).AddTicks(9093) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 18, 8, 17, 35, 196, DateTimeKind.Local).AddTicks(9100), new DateTime(2022, 12, 18, 8, 17, 35, 196, DateTimeKind.Local).AddTicks(9100) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 18, 8, 17, 35, 196, DateTimeKind.Local).AddTicks(9107), new DateTime(2022, 12, 18, 8, 17, 35, 196, DateTimeKind.Local).AddTicks(9107) });

            migrationBuilder.UpdateData(
                table: "Plan",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 18, 8, 17, 35, 196, DateTimeKind.Local).AddTicks(8891), new DateTime(2022, 12, 18, 8, 17, 35, 196, DateTimeKind.Local).AddTicks(8901) });

            migrationBuilder.UpdateData(
                table: "Plan",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 18, 8, 17, 35, 196, DateTimeKind.Local).AddTicks(8924), new DateTime(2022, 12, 18, 8, 17, 35, 196, DateTimeKind.Local).AddTicks(8925) });

            migrationBuilder.UpdateData(
                table: "Plan",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 18, 8, 17, 35, 196, DateTimeKind.Local).AddTicks(8932), new DateTime(2022, 12, 18, 8, 17, 35, 196, DateTimeKind.Local).AddTicks(8932) });

            migrationBuilder.UpdateData(
                table: "SubPlan",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 18, 8, 17, 35, 196, DateTimeKind.Local).AddTicks(8982), new DateTime(2022, 12, 18, 8, 17, 35, 196, DateTimeKind.Local).AddTicks(8983) });

            migrationBuilder.UpdateData(
                table: "SubPlan",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 18, 8, 17, 35, 196, DateTimeKind.Local).AddTicks(8994), new DateTime(2022, 12, 18, 8, 17, 35, 196, DateTimeKind.Local).AddTicks(8995) });

            migrationBuilder.UpdateData(
                table: "SubPlan",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 18, 8, 17, 35, 196, DateTimeKind.Local).AddTicks(9003), new DateTime(2022, 12, 18, 8, 17, 35, 196, DateTimeKind.Local).AddTicks(9003) });

            migrationBuilder.UpdateData(
                table: "SubPlan",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 18, 8, 17, 35, 196, DateTimeKind.Local).AddTicks(9010), new DateTime(2022, 12, 18, 8, 17, 35, 196, DateTimeKind.Local).AddTicks(9011) });

            migrationBuilder.UpdateData(
                table: "SubPlan",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 18, 8, 17, 35, 196, DateTimeKind.Local).AddTicks(9018), new DateTime(2022, 12, 18, 8, 17, 35, 196, DateTimeKind.Local).AddTicks(9018) });

            migrationBuilder.UpdateData(
                table: "SubPlan",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 18, 8, 17, 35, 196, DateTimeKind.Local).AddTicks(9026), new DateTime(2022, 12, 18, 8, 17, 35, 196, DateTimeKind.Local).AddTicks(9026) });

            migrationBuilder.UpdateData(
                table: "SubPlan",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 18, 8, 17, 35, 196, DateTimeKind.Local).AddTicks(9033), new DateTime(2022, 12, 18, 8, 17, 35, 196, DateTimeKind.Local).AddTicks(9033) });

            migrationBuilder.UpdateData(
                table: "SubPlan",
                keyColumn: "Id",
                keyValue: 8L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 18, 8, 17, 35, 196, DateTimeKind.Local).AddTicks(9040), new DateTime(2022, 12, 18, 8, 17, 35, 196, DateTimeKind.Local).AddTicks(9040) });

            migrationBuilder.UpdateData(
                table: "SubPlan",
                keyColumn: "Id",
                keyValue: 9L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 18, 8, 17, 35, 196, DateTimeKind.Local).AddTicks(9047), new DateTime(2022, 12, 18, 8, 17, 35, 196, DateTimeKind.Local).AddTicks(9048) });
        }
    }
}
