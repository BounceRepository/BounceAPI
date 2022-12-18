using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bounce_DbOps.Migrations
{
    public partial class added_PlanFk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 12, 9, 33, 4, 639, DateTimeKind.Local).AddTicks(3471), new DateTime(2022, 12, 12, 9, 33, 4, 639, DateTimeKind.Local).AddTicks(3471) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 12, 9, 33, 4, 639, DateTimeKind.Local).AddTicks(3482), new DateTime(2022, 12, 12, 9, 33, 4, 639, DateTimeKind.Local).AddTicks(3482) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 12, 9, 33, 4, 639, DateTimeKind.Local).AddTicks(3491), new DateTime(2022, 12, 12, 9, 33, 4, 639, DateTimeKind.Local).AddTicks(3492) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 12, 9, 33, 4, 639, DateTimeKind.Local).AddTicks(3500), new DateTime(2022, 12, 12, 9, 33, 4, 639, DateTimeKind.Local).AddTicks(3500) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 12, 9, 33, 4, 639, DateTimeKind.Local).AddTicks(3508), new DateTime(2022, 12, 12, 9, 33, 4, 639, DateTimeKind.Local).AddTicks(3509) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 12, 9, 33, 4, 639, DateTimeKind.Local).AddTicks(3517), new DateTime(2022, 12, 12, 9, 33, 4, 639, DateTimeKind.Local).AddTicks(3518) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 12, 9, 33, 4, 639, DateTimeKind.Local).AddTicks(3526), new DateTime(2022, 12, 12, 9, 33, 4, 639, DateTimeKind.Local).AddTicks(3527) });

            migrationBuilder.UpdateData(
                table: "Plan",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 12, 9, 33, 4, 639, DateTimeKind.Local).AddTicks(3276), new DateTime(2022, 12, 12, 9, 33, 4, 639, DateTimeKind.Local).AddTicks(3288) });

            migrationBuilder.UpdateData(
                table: "Plan",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 12, 9, 33, 4, 639, DateTimeKind.Local).AddTicks(3312), new DateTime(2022, 12, 12, 9, 33, 4, 639, DateTimeKind.Local).AddTicks(3313) });

            migrationBuilder.UpdateData(
                table: "Plan",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 12, 9, 33, 4, 639, DateTimeKind.Local).AddTicks(3322), new DateTime(2022, 12, 12, 9, 33, 4, 639, DateTimeKind.Local).AddTicks(3323) });

            migrationBuilder.UpdateData(
                table: "SubPlan",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 12, 9, 33, 4, 639, DateTimeKind.Local).AddTicks(3366), new DateTime(2022, 12, 12, 9, 33, 4, 639, DateTimeKind.Local).AddTicks(3367) });

            migrationBuilder.UpdateData(
                table: "SubPlan",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 12, 9, 33, 4, 639, DateTimeKind.Local).AddTicks(3395), new DateTime(2022, 12, 12, 9, 33, 4, 639, DateTimeKind.Local).AddTicks(3395) });

            migrationBuilder.UpdateData(
                table: "SubPlan",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 12, 9, 33, 4, 639, DateTimeKind.Local).AddTicks(3404), new DateTime(2022, 12, 12, 9, 33, 4, 639, DateTimeKind.Local).AddTicks(3405) });

            migrationBuilder.UpdateData(
                table: "SubPlan",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 12, 9, 33, 4, 639, DateTimeKind.Local).AddTicks(3413), new DateTime(2022, 12, 12, 9, 33, 4, 639, DateTimeKind.Local).AddTicks(3413) });

            migrationBuilder.UpdateData(
                table: "SubPlan",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 12, 9, 33, 4, 639, DateTimeKind.Local).AddTicks(3421), new DateTime(2022, 12, 12, 9, 33, 4, 639, DateTimeKind.Local).AddTicks(3422) });

            migrationBuilder.UpdateData(
                table: "SubPlan",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 12, 9, 33, 4, 639, DateTimeKind.Local).AddTicks(3431), new DateTime(2022, 12, 12, 9, 33, 4, 639, DateTimeKind.Local).AddTicks(3431) });

            migrationBuilder.UpdateData(
                table: "SubPlan",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 12, 9, 33, 4, 639, DateTimeKind.Local).AddTicks(3439), new DateTime(2022, 12, 12, 9, 33, 4, 639, DateTimeKind.Local).AddTicks(3439) });

            migrationBuilder.UpdateData(
                table: "SubPlan",
                keyColumn: "Id",
                keyValue: 8L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 12, 9, 33, 4, 639, DateTimeKind.Local).AddTicks(3447), new DateTime(2022, 12, 12, 9, 33, 4, 639, DateTimeKind.Local).AddTicks(3448) });

            migrationBuilder.UpdateData(
                table: "SubPlan",
                keyColumn: "Id",
                keyValue: 9L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 12, 9, 33, 4, 639, DateTimeKind.Local).AddTicks(3456), new DateTime(2022, 12, 12, 9, 33, 4, 639, DateTimeKind.Local).AddTicks(3456) });

            migrationBuilder.CreateIndex(
                name: "IX_SubPlan_PLanId",
                table: "SubPlan",
                column: "PLanId");

            migrationBuilder.AddForeignKey(
                name: "FK_SubPlan_Plan_PLanId",
                table: "SubPlan",
                column: "PLanId",
                principalTable: "Plan",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubPlan_Plan_PLanId",
                table: "SubPlan");

            migrationBuilder.DropIndex(
                name: "IX_SubPlan_PLanId",
                table: "SubPlan");

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 12, 9, 21, 14, 139, DateTimeKind.Local).AddTicks(9092), new DateTime(2022, 12, 12, 9, 21, 14, 139, DateTimeKind.Local).AddTicks(9093) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 12, 9, 21, 14, 139, DateTimeKind.Local).AddTicks(9103), new DateTime(2022, 12, 12, 9, 21, 14, 139, DateTimeKind.Local).AddTicks(9103) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 12, 9, 21, 14, 139, DateTimeKind.Local).AddTicks(9111), new DateTime(2022, 12, 12, 9, 21, 14, 139, DateTimeKind.Local).AddTicks(9111) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 12, 9, 21, 14, 139, DateTimeKind.Local).AddTicks(9119), new DateTime(2022, 12, 12, 9, 21, 14, 139, DateTimeKind.Local).AddTicks(9120) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 12, 9, 21, 14, 139, DateTimeKind.Local).AddTicks(9127), new DateTime(2022, 12, 12, 9, 21, 14, 139, DateTimeKind.Local).AddTicks(9127) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 12, 9, 21, 14, 139, DateTimeKind.Local).AddTicks(9136), new DateTime(2022, 12, 12, 9, 21, 14, 139, DateTimeKind.Local).AddTicks(9136) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 12, 9, 21, 14, 139, DateTimeKind.Local).AddTicks(9143), new DateTime(2022, 12, 12, 9, 21, 14, 139, DateTimeKind.Local).AddTicks(9144) });

            migrationBuilder.UpdateData(
                table: "Plan",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 12, 9, 21, 14, 139, DateTimeKind.Local).AddTicks(8930), new DateTime(2022, 12, 12, 9, 21, 14, 139, DateTimeKind.Local).AddTicks(8940) });

            migrationBuilder.UpdateData(
                table: "Plan",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 12, 9, 21, 14, 139, DateTimeKind.Local).AddTicks(8962), new DateTime(2022, 12, 12, 9, 21, 14, 139, DateTimeKind.Local).AddTicks(8962) });

            migrationBuilder.UpdateData(
                table: "Plan",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 12, 9, 21, 14, 139, DateTimeKind.Local).AddTicks(8970), new DateTime(2022, 12, 12, 9, 21, 14, 139, DateTimeKind.Local).AddTicks(8971) });

            migrationBuilder.UpdateData(
                table: "SubPlan",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 12, 9, 21, 14, 139, DateTimeKind.Local).AddTicks(9002), new DateTime(2022, 12, 12, 9, 21, 14, 139, DateTimeKind.Local).AddTicks(9002) });

            migrationBuilder.UpdateData(
                table: "SubPlan",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 12, 9, 21, 14, 139, DateTimeKind.Local).AddTicks(9014), new DateTime(2022, 12, 12, 9, 21, 14, 139, DateTimeKind.Local).AddTicks(9014) });

            migrationBuilder.UpdateData(
                table: "SubPlan",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 12, 9, 21, 14, 139, DateTimeKind.Local).AddTicks(9022), new DateTime(2022, 12, 12, 9, 21, 14, 139, DateTimeKind.Local).AddTicks(9022) });

            migrationBuilder.UpdateData(
                table: "SubPlan",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 12, 9, 21, 14, 139, DateTimeKind.Local).AddTicks(9029), new DateTime(2022, 12, 12, 9, 21, 14, 139, DateTimeKind.Local).AddTicks(9030) });

            migrationBuilder.UpdateData(
                table: "SubPlan",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 12, 9, 21, 14, 139, DateTimeKind.Local).AddTicks(9037), new DateTime(2022, 12, 12, 9, 21, 14, 139, DateTimeKind.Local).AddTicks(9037) });

            migrationBuilder.UpdateData(
                table: "SubPlan",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 12, 9, 21, 14, 139, DateTimeKind.Local).AddTicks(9046), new DateTime(2022, 12, 12, 9, 21, 14, 139, DateTimeKind.Local).AddTicks(9046) });

            migrationBuilder.UpdateData(
                table: "SubPlan",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 12, 9, 21, 14, 139, DateTimeKind.Local).AddTicks(9053), new DateTime(2022, 12, 12, 9, 21, 14, 139, DateTimeKind.Local).AddTicks(9054) });

            migrationBuilder.UpdateData(
                table: "SubPlan",
                keyColumn: "Id",
                keyValue: 8L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 12, 9, 21, 14, 139, DateTimeKind.Local).AddTicks(9061), new DateTime(2022, 12, 12, 9, 21, 14, 139, DateTimeKind.Local).AddTicks(9061) });

            migrationBuilder.UpdateData(
                table: "SubPlan",
                keyColumn: "Id",
                keyValue: 9L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 12, 9, 21, 14, 139, DateTimeKind.Local).AddTicks(9068), new DateTime(2022, 12, 12, 9, 21, 14, 139, DateTimeKind.Local).AddTicks(9068) });
        }
    }
}
