using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bounce_DbOps.Migrations
{
    public partial class added_status : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AgeRange",
                table: "AppointmentRequest",
                newName: "StartTimeToString");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "AppointmentRequest",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 15, 18, 17, 44, 394, DateTimeKind.Local).AddTicks(9521), new DateTime(2022, 12, 15, 18, 17, 44, 394, DateTimeKind.Local).AddTicks(9521) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 15, 18, 17, 44, 394, DateTimeKind.Local).AddTicks(9530), new DateTime(2022, 12, 15, 18, 17, 44, 394, DateTimeKind.Local).AddTicks(9530) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 15, 18, 17, 44, 394, DateTimeKind.Local).AddTicks(9538), new DateTime(2022, 12, 15, 18, 17, 44, 394, DateTimeKind.Local).AddTicks(9538) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 15, 18, 17, 44, 394, DateTimeKind.Local).AddTicks(9545), new DateTime(2022, 12, 15, 18, 17, 44, 394, DateTimeKind.Local).AddTicks(9545) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 15, 18, 17, 44, 394, DateTimeKind.Local).AddTicks(9552), new DateTime(2022, 12, 15, 18, 17, 44, 394, DateTimeKind.Local).AddTicks(9552) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 15, 18, 17, 44, 394, DateTimeKind.Local).AddTicks(9560), new DateTime(2022, 12, 15, 18, 17, 44, 394, DateTimeKind.Local).AddTicks(9560) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 15, 18, 17, 44, 394, DateTimeKind.Local).AddTicks(9567), new DateTime(2022, 12, 15, 18, 17, 44, 394, DateTimeKind.Local).AddTicks(9568) });

            migrationBuilder.UpdateData(
                table: "Plan",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 15, 18, 17, 44, 394, DateTimeKind.Local).AddTicks(9348), new DateTime(2022, 12, 15, 18, 17, 44, 394, DateTimeKind.Local).AddTicks(9357) });

            migrationBuilder.UpdateData(
                table: "Plan",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 15, 18, 17, 44, 394, DateTimeKind.Local).AddTicks(9379), new DateTime(2022, 12, 15, 18, 17, 44, 394, DateTimeKind.Local).AddTicks(9379) });

            migrationBuilder.UpdateData(
                table: "Plan",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 15, 18, 17, 44, 394, DateTimeKind.Local).AddTicks(9388), new DateTime(2022, 12, 15, 18, 17, 44, 394, DateTimeKind.Local).AddTicks(9388) });

            migrationBuilder.UpdateData(
                table: "SubPlan",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 15, 18, 17, 44, 394, DateTimeKind.Local).AddTicks(9437), new DateTime(2022, 12, 15, 18, 17, 44, 394, DateTimeKind.Local).AddTicks(9438) });

            migrationBuilder.UpdateData(
                table: "SubPlan",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 15, 18, 17, 44, 394, DateTimeKind.Local).AddTicks(9450), new DateTime(2022, 12, 15, 18, 17, 44, 394, DateTimeKind.Local).AddTicks(9450) });

            migrationBuilder.UpdateData(
                table: "SubPlan",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 15, 18, 17, 44, 394, DateTimeKind.Local).AddTicks(9459), new DateTime(2022, 12, 15, 18, 17, 44, 394, DateTimeKind.Local).AddTicks(9459) });

            migrationBuilder.UpdateData(
                table: "SubPlan",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 15, 18, 17, 44, 394, DateTimeKind.Local).AddTicks(9467), new DateTime(2022, 12, 15, 18, 17, 44, 394, DateTimeKind.Local).AddTicks(9467) });

            migrationBuilder.UpdateData(
                table: "SubPlan",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 15, 18, 17, 44, 394, DateTimeKind.Local).AddTicks(9474), new DateTime(2022, 12, 15, 18, 17, 44, 394, DateTimeKind.Local).AddTicks(9475) });

            migrationBuilder.UpdateData(
                table: "SubPlan",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 15, 18, 17, 44, 394, DateTimeKind.Local).AddTicks(9484), new DateTime(2022, 12, 15, 18, 17, 44, 394, DateTimeKind.Local).AddTicks(9484) });

            migrationBuilder.UpdateData(
                table: "SubPlan",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 15, 18, 17, 44, 394, DateTimeKind.Local).AddTicks(9491), new DateTime(2022, 12, 15, 18, 17, 44, 394, DateTimeKind.Local).AddTicks(9492) });

            migrationBuilder.UpdateData(
                table: "SubPlan",
                keyColumn: "Id",
                keyValue: 8L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 15, 18, 17, 44, 394, DateTimeKind.Local).AddTicks(9499), new DateTime(2022, 12, 15, 18, 17, 44, 394, DateTimeKind.Local).AddTicks(9500) });

            migrationBuilder.UpdateData(
                table: "SubPlan",
                keyColumn: "Id",
                keyValue: 9L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 15, 18, 17, 44, 394, DateTimeKind.Local).AddTicks(9507), new DateTime(2022, 12, 15, 18, 17, 44, 394, DateTimeKind.Local).AddTicks(9507) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "AppointmentRequest");

            migrationBuilder.RenameColumn(
                name: "StartTimeToString",
                table: "AppointmentRequest",
                newName: "AgeRange");

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 12, 11, 34, 59, 673, DateTimeKind.Local).AddTicks(331), new DateTime(2022, 12, 12, 11, 34, 59, 673, DateTimeKind.Local).AddTicks(332) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 12, 11, 34, 59, 673, DateTimeKind.Local).AddTicks(353), new DateTime(2022, 12, 12, 11, 34, 59, 673, DateTimeKind.Local).AddTicks(354) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 12, 11, 34, 59, 673, DateTimeKind.Local).AddTicks(362), new DateTime(2022, 12, 12, 11, 34, 59, 673, DateTimeKind.Local).AddTicks(362) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 12, 11, 34, 59, 673, DateTimeKind.Local).AddTicks(369), new DateTime(2022, 12, 12, 11, 34, 59, 673, DateTimeKind.Local).AddTicks(369) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 12, 11, 34, 59, 673, DateTimeKind.Local).AddTicks(376), new DateTime(2022, 12, 12, 11, 34, 59, 673, DateTimeKind.Local).AddTicks(377) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 12, 11, 34, 59, 673, DateTimeKind.Local).AddTicks(385), new DateTime(2022, 12, 12, 11, 34, 59, 673, DateTimeKind.Local).AddTicks(385) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 12, 11, 34, 59, 673, DateTimeKind.Local).AddTicks(392), new DateTime(2022, 12, 12, 11, 34, 59, 673, DateTimeKind.Local).AddTicks(393) });

            migrationBuilder.UpdateData(
                table: "Plan",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 12, 11, 34, 59, 673, DateTimeKind.Local).AddTicks(151), new DateTime(2022, 12, 12, 11, 34, 59, 673, DateTimeKind.Local).AddTicks(161) });

            migrationBuilder.UpdateData(
                table: "Plan",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 12, 11, 34, 59, 673, DateTimeKind.Local).AddTicks(191), new DateTime(2022, 12, 12, 11, 34, 59, 673, DateTimeKind.Local).AddTicks(192) });

            migrationBuilder.UpdateData(
                table: "Plan",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 12, 11, 34, 59, 673, DateTimeKind.Local).AddTicks(200), new DateTime(2022, 12, 12, 11, 34, 59, 673, DateTimeKind.Local).AddTicks(200) });

            migrationBuilder.UpdateData(
                table: "SubPlan",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 12, 11, 34, 59, 673, DateTimeKind.Local).AddTicks(243), new DateTime(2022, 12, 12, 11, 34, 59, 673, DateTimeKind.Local).AddTicks(244) });

            migrationBuilder.UpdateData(
                table: "SubPlan",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 12, 11, 34, 59, 673, DateTimeKind.Local).AddTicks(260), new DateTime(2022, 12, 12, 11, 34, 59, 673, DateTimeKind.Local).AddTicks(260) });

            migrationBuilder.UpdateData(
                table: "SubPlan",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 12, 11, 34, 59, 673, DateTimeKind.Local).AddTicks(268), new DateTime(2022, 12, 12, 11, 34, 59, 673, DateTimeKind.Local).AddTicks(268) });

            migrationBuilder.UpdateData(
                table: "SubPlan",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 12, 11, 34, 59, 673, DateTimeKind.Local).AddTicks(275), new DateTime(2022, 12, 12, 11, 34, 59, 673, DateTimeKind.Local).AddTicks(275) });

            migrationBuilder.UpdateData(
                table: "SubPlan",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 12, 11, 34, 59, 673, DateTimeKind.Local).AddTicks(282), new DateTime(2022, 12, 12, 11, 34, 59, 673, DateTimeKind.Local).AddTicks(283) });

            migrationBuilder.UpdateData(
                table: "SubPlan",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 12, 11, 34, 59, 673, DateTimeKind.Local).AddTicks(291), new DateTime(2022, 12, 12, 11, 34, 59, 673, DateTimeKind.Local).AddTicks(291) });

            migrationBuilder.UpdateData(
                table: "SubPlan",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 12, 11, 34, 59, 673, DateTimeKind.Local).AddTicks(298), new DateTime(2022, 12, 12, 11, 34, 59, 673, DateTimeKind.Local).AddTicks(299) });

            migrationBuilder.UpdateData(
                table: "SubPlan",
                keyColumn: "Id",
                keyValue: 8L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 12, 11, 34, 59, 673, DateTimeKind.Local).AddTicks(306), new DateTime(2022, 12, 12, 11, 34, 59, 673, DateTimeKind.Local).AddTicks(306) });

            migrationBuilder.UpdateData(
                table: "SubPlan",
                keyColumn: "Id",
                keyValue: 9L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 12, 11, 34, 59, 673, DateTimeKind.Local).AddTicks(313), new DateTime(2022, 12, 12, 11, 34, 59, 673, DateTimeKind.Local).AddTicks(314) });
        }
    }
}
