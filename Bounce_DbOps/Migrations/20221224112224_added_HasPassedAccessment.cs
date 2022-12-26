using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bounce_DbOps.Migrations
{
    public partial class added_HasPassedAccessment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "PassedAccessment",
                table: "TherapistProfiles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 24, 12, 22, 22, 838, DateTimeKind.Local).AddTicks(23), new DateTime(2022, 12, 24, 12, 22, 22, 838, DateTimeKind.Local).AddTicks(25) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 24, 12, 22, 22, 838, DateTimeKind.Local).AddTicks(51), new DateTime(2022, 12, 24, 12, 22, 22, 838, DateTimeKind.Local).AddTicks(52) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 24, 12, 22, 22, 838, DateTimeKind.Local).AddTicks(74), new DateTime(2022, 12, 24, 12, 22, 22, 838, DateTimeKind.Local).AddTicks(75) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 24, 12, 22, 22, 838, DateTimeKind.Local).AddTicks(106), new DateTime(2022, 12, 24, 12, 22, 22, 838, DateTimeKind.Local).AddTicks(107) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 24, 12, 22, 22, 838, DateTimeKind.Local).AddTicks(137), new DateTime(2022, 12, 24, 12, 22, 22, 838, DateTimeKind.Local).AddTicks(138) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 24, 12, 22, 22, 838, DateTimeKind.Local).AddTicks(164), new DateTime(2022, 12, 24, 12, 22, 22, 838, DateTimeKind.Local).AddTicks(164) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 24, 12, 22, 22, 838, DateTimeKind.Local).AddTicks(186), new DateTime(2022, 12, 24, 12, 22, 22, 838, DateTimeKind.Local).AddTicks(187) });

            migrationBuilder.UpdateData(
                table: "Plan",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 24, 12, 22, 22, 837, DateTimeKind.Local).AddTicks(9448), new DateTime(2022, 12, 24, 12, 22, 22, 837, DateTimeKind.Local).AddTicks(9467) });

            migrationBuilder.UpdateData(
                table: "Plan",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 24, 12, 22, 22, 837, DateTimeKind.Local).AddTicks(9532), new DateTime(2022, 12, 24, 12, 22, 22, 837, DateTimeKind.Local).AddTicks(9534) });

            migrationBuilder.UpdateData(
                table: "Plan",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 24, 12, 22, 22, 837, DateTimeKind.Local).AddTicks(9583), new DateTime(2022, 12, 24, 12, 22, 22, 837, DateTimeKind.Local).AddTicks(9584) });

            migrationBuilder.UpdateData(
                table: "SubPlan",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 24, 12, 22, 22, 837, DateTimeKind.Local).AddTicks(9674), new DateTime(2022, 12, 24, 12, 22, 22, 837, DateTimeKind.Local).AddTicks(9674) });

            migrationBuilder.UpdateData(
                table: "SubPlan",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 24, 12, 22, 22, 837, DateTimeKind.Local).AddTicks(9711), new DateTime(2022, 12, 24, 12, 22, 22, 837, DateTimeKind.Local).AddTicks(9713) });

            migrationBuilder.UpdateData(
                table: "SubPlan",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 24, 12, 22, 22, 837, DateTimeKind.Local).AddTicks(9784), new DateTime(2022, 12, 24, 12, 22, 22, 837, DateTimeKind.Local).AddTicks(9796) });

            migrationBuilder.UpdateData(
                table: "SubPlan",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 24, 12, 22, 22, 837, DateTimeKind.Local).AddTicks(9842), new DateTime(2022, 12, 24, 12, 22, 22, 837, DateTimeKind.Local).AddTicks(9843) });

            migrationBuilder.UpdateData(
                table: "SubPlan",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 24, 12, 22, 22, 837, DateTimeKind.Local).AddTicks(9866), new DateTime(2022, 12, 24, 12, 22, 22, 837, DateTimeKind.Local).AddTicks(9867) });

            migrationBuilder.UpdateData(
                table: "SubPlan",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 24, 12, 22, 22, 837, DateTimeKind.Local).AddTicks(9914), new DateTime(2022, 12, 24, 12, 22, 22, 837, DateTimeKind.Local).AddTicks(9915) });

            migrationBuilder.UpdateData(
                table: "SubPlan",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 24, 12, 22, 22, 837, DateTimeKind.Local).AddTicks(9938), new DateTime(2022, 12, 24, 12, 22, 22, 837, DateTimeKind.Local).AddTicks(9939) });

            migrationBuilder.UpdateData(
                table: "SubPlan",
                keyColumn: "Id",
                keyValue: 8L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 24, 12, 22, 22, 837, DateTimeKind.Local).AddTicks(9961), new DateTime(2022, 12, 24, 12, 22, 22, 837, DateTimeKind.Local).AddTicks(9962) });

            migrationBuilder.UpdateData(
                table: "SubPlan",
                keyColumn: "Id",
                keyValue: 9L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 24, 12, 22, 22, 837, DateTimeKind.Local).AddTicks(9984), new DateTime(2022, 12, 24, 12, 22, 22, 837, DateTimeKind.Local).AddTicks(9986) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PassedAccessment",
                table: "TherapistProfiles");

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 24, 9, 39, 27, 927, DateTimeKind.Local).AddTicks(1785), new DateTime(2022, 12, 24, 9, 39, 27, 927, DateTimeKind.Local).AddTicks(1786) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 24, 9, 39, 27, 927, DateTimeKind.Local).AddTicks(1794), new DateTime(2022, 12, 24, 9, 39, 27, 927, DateTimeKind.Local).AddTicks(1795) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 24, 9, 39, 27, 927, DateTimeKind.Local).AddTicks(1801), new DateTime(2022, 12, 24, 9, 39, 27, 927, DateTimeKind.Local).AddTicks(1801) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 24, 9, 39, 27, 927, DateTimeKind.Local).AddTicks(1807), new DateTime(2022, 12, 24, 9, 39, 27, 927, DateTimeKind.Local).AddTicks(1808) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 24, 9, 39, 27, 927, DateTimeKind.Local).AddTicks(1814), new DateTime(2022, 12, 24, 9, 39, 27, 927, DateTimeKind.Local).AddTicks(1815) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 24, 9, 39, 27, 927, DateTimeKind.Local).AddTicks(1821), new DateTime(2022, 12, 24, 9, 39, 27, 927, DateTimeKind.Local).AddTicks(1822) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 24, 9, 39, 27, 927, DateTimeKind.Local).AddTicks(1828), new DateTime(2022, 12, 24, 9, 39, 27, 927, DateTimeKind.Local).AddTicks(1829) });

            migrationBuilder.UpdateData(
                table: "Plan",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 24, 9, 39, 27, 927, DateTimeKind.Local).AddTicks(1452), new DateTime(2022, 12, 24, 9, 39, 27, 927, DateTimeKind.Local).AddTicks(1462) });

            migrationBuilder.UpdateData(
                table: "Plan",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 24, 9, 39, 27, 927, DateTimeKind.Local).AddTicks(1485), new DateTime(2022, 12, 24, 9, 39, 27, 927, DateTimeKind.Local).AddTicks(1486) });

            migrationBuilder.UpdateData(
                table: "Plan",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 24, 9, 39, 27, 927, DateTimeKind.Local).AddTicks(1493), new DateTime(2022, 12, 24, 9, 39, 27, 927, DateTimeKind.Local).AddTicks(1493) });

            migrationBuilder.UpdateData(
                table: "SubPlan",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 24, 9, 39, 27, 927, DateTimeKind.Local).AddTicks(1534), new DateTime(2022, 12, 24, 9, 39, 27, 927, DateTimeKind.Local).AddTicks(1534) });

            migrationBuilder.UpdateData(
                table: "SubPlan",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 24, 9, 39, 27, 927, DateTimeKind.Local).AddTicks(1546), new DateTime(2022, 12, 24, 9, 39, 27, 927, DateTimeKind.Local).AddTicks(1547) });

            migrationBuilder.UpdateData(
                table: "SubPlan",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 24, 9, 39, 27, 927, DateTimeKind.Local).AddTicks(1555), new DateTime(2022, 12, 24, 9, 39, 27, 927, DateTimeKind.Local).AddTicks(1555) });

            migrationBuilder.UpdateData(
                table: "SubPlan",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 24, 9, 39, 27, 927, DateTimeKind.Local).AddTicks(1562), new DateTime(2022, 12, 24, 9, 39, 27, 927, DateTimeKind.Local).AddTicks(1563) });

            migrationBuilder.UpdateData(
                table: "SubPlan",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 24, 9, 39, 27, 927, DateTimeKind.Local).AddTicks(1569), new DateTime(2022, 12, 24, 9, 39, 27, 927, DateTimeKind.Local).AddTicks(1570) });

            migrationBuilder.UpdateData(
                table: "SubPlan",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 24, 9, 39, 27, 927, DateTimeKind.Local).AddTicks(1746), new DateTime(2022, 12, 24, 9, 39, 27, 927, DateTimeKind.Local).AddTicks(1746) });

            migrationBuilder.UpdateData(
                table: "SubPlan",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 24, 9, 39, 27, 927, DateTimeKind.Local).AddTicks(1754), new DateTime(2022, 12, 24, 9, 39, 27, 927, DateTimeKind.Local).AddTicks(1755) });

            migrationBuilder.UpdateData(
                table: "SubPlan",
                keyColumn: "Id",
                keyValue: 8L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 24, 9, 39, 27, 927, DateTimeKind.Local).AddTicks(1762), new DateTime(2022, 12, 24, 9, 39, 27, 927, DateTimeKind.Local).AddTicks(1762) });

            migrationBuilder.UpdateData(
                table: "SubPlan",
                keyColumn: "Id",
                keyValue: 9L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 24, 9, 39, 27, 927, DateTimeKind.Local).AddTicks(1769), new DateTime(2022, 12, 24, 9, 39, 27, 927, DateTimeKind.Local).AddTicks(1769) });
        }
    }
}
