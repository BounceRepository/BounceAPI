using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bounce_DbOps.Migrations
{
    public partial class added_ModetouserProfile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Mood",
                table: "UserProfile",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 26, 5, 34, 46, 442, DateTimeKind.Local).AddTicks(6874), new DateTime(2022, 12, 26, 5, 34, 46, 442, DateTimeKind.Local).AddTicks(6875) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 26, 5, 34, 46, 442, DateTimeKind.Local).AddTicks(6884), new DateTime(2022, 12, 26, 5, 34, 46, 442, DateTimeKind.Local).AddTicks(6884) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 26, 5, 34, 46, 442, DateTimeKind.Local).AddTicks(6892), new DateTime(2022, 12, 26, 5, 34, 46, 442, DateTimeKind.Local).AddTicks(6892) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 26, 5, 34, 46, 442, DateTimeKind.Local).AddTicks(6899), new DateTime(2022, 12, 26, 5, 34, 46, 442, DateTimeKind.Local).AddTicks(6899) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 26, 5, 34, 46, 442, DateTimeKind.Local).AddTicks(6906), new DateTime(2022, 12, 26, 5, 34, 46, 442, DateTimeKind.Local).AddTicks(6906) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 26, 5, 34, 46, 442, DateTimeKind.Local).AddTicks(6914), new DateTime(2022, 12, 26, 5, 34, 46, 442, DateTimeKind.Local).AddTicks(6914) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 26, 5, 34, 46, 442, DateTimeKind.Local).AddTicks(6921), new DateTime(2022, 12, 26, 5, 34, 46, 442, DateTimeKind.Local).AddTicks(6922) });

            migrationBuilder.UpdateData(
                table: "Plan",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 26, 5, 34, 46, 442, DateTimeKind.Local).AddTicks(6704), new DateTime(2022, 12, 26, 5, 34, 46, 442, DateTimeKind.Local).AddTicks(6718) });

            migrationBuilder.UpdateData(
                table: "Plan",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 26, 5, 34, 46, 442, DateTimeKind.Local).AddTicks(6739), new DateTime(2022, 12, 26, 5, 34, 46, 442, DateTimeKind.Local).AddTicks(6740) });

            migrationBuilder.UpdateData(
                table: "Plan",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 26, 5, 34, 46, 442, DateTimeKind.Local).AddTicks(6757), new DateTime(2022, 12, 26, 5, 34, 46, 442, DateTimeKind.Local).AddTicks(6758) });

            migrationBuilder.UpdateData(
                table: "SubPlan",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 26, 5, 34, 46, 442, DateTimeKind.Local).AddTicks(6795), new DateTime(2022, 12, 26, 5, 34, 46, 442, DateTimeKind.Local).AddTicks(6796) });

            migrationBuilder.UpdateData(
                table: "SubPlan",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 26, 5, 34, 46, 442, DateTimeKind.Local).AddTicks(6808), new DateTime(2022, 12, 26, 5, 34, 46, 442, DateTimeKind.Local).AddTicks(6809) });

            migrationBuilder.UpdateData(
                table: "SubPlan",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 26, 5, 34, 46, 442, DateTimeKind.Local).AddTicks(6816), new DateTime(2022, 12, 26, 5, 34, 46, 442, DateTimeKind.Local).AddTicks(6817) });

            migrationBuilder.UpdateData(
                table: "SubPlan",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 26, 5, 34, 46, 442, DateTimeKind.Local).AddTicks(6823), new DateTime(2022, 12, 26, 5, 34, 46, 442, DateTimeKind.Local).AddTicks(6824) });

            migrationBuilder.UpdateData(
                table: "SubPlan",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 26, 5, 34, 46, 442, DateTimeKind.Local).AddTicks(6830), new DateTime(2022, 12, 26, 5, 34, 46, 442, DateTimeKind.Local).AddTicks(6831) });

            migrationBuilder.UpdateData(
                table: "SubPlan",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 26, 5, 34, 46, 442, DateTimeKind.Local).AddTicks(6838), new DateTime(2022, 12, 26, 5, 34, 46, 442, DateTimeKind.Local).AddTicks(6839) });

            migrationBuilder.UpdateData(
                table: "SubPlan",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 26, 5, 34, 46, 442, DateTimeKind.Local).AddTicks(6846), new DateTime(2022, 12, 26, 5, 34, 46, 442, DateTimeKind.Local).AddTicks(6846) });

            migrationBuilder.UpdateData(
                table: "SubPlan",
                keyColumn: "Id",
                keyValue: 8L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 26, 5, 34, 46, 442, DateTimeKind.Local).AddTicks(6853), new DateTime(2022, 12, 26, 5, 34, 46, 442, DateTimeKind.Local).AddTicks(6853) });

            migrationBuilder.UpdateData(
                table: "SubPlan",
                keyColumn: "Id",
                keyValue: 9L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 26, 5, 34, 46, 442, DateTimeKind.Local).AddTicks(6860), new DateTime(2022, 12, 26, 5, 34, 46, 442, DateTimeKind.Local).AddTicks(6860) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Mood",
                table: "UserProfile");

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
    }
}
