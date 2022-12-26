using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bounce_DbOps.Migrations
{
    public partial class modified_subscrition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subscriptions_Plan_PlanId",
                table: "Subscriptions");

            migrationBuilder.RenameColumn(
                name: "PlanId",
                table: "Subscriptions",
                newName: "SubPlanId");

            migrationBuilder.RenameIndex(
                name: "IX_Subscriptions_PlanId",
                table: "Subscriptions",
                newName: "IX_Subscriptions_SubPlanId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Subscriptions_SubPlan_SubPlanId",
                table: "Subscriptions",
                column: "SubPlanId",
                principalTable: "SubPlan",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subscriptions_SubPlan_SubPlanId",
                table: "Subscriptions");

            migrationBuilder.RenameColumn(
                name: "SubPlanId",
                table: "Subscriptions",
                newName: "PlanId");

            migrationBuilder.RenameIndex(
                name: "IX_Subscriptions_SubPlanId",
                table: "Subscriptions",
                newName: "IX_Subscriptions_PlanId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Subscriptions_Plan_PlanId",
                table: "Subscriptions",
                column: "PlanId",
                principalTable: "Plan",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
