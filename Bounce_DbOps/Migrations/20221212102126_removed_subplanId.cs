using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bounce_DbOps.Migrations
{
    public partial class removed_subplanId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PaymentRequests_SubPlan_SubPlanId",
                table: "PaymentRequests");

            migrationBuilder.RenameColumn(
                name: "SubPlanId",
                table: "PaymentRequests",
                newName: "SubPlanId1");

            migrationBuilder.RenameIndex(
                name: "IX_PaymentRequests_SubPlanId",
                table: "PaymentRequests",
                newName: "IX_PaymentRequests_SubPlanId1");

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 12, 11, 21, 25, 388, DateTimeKind.Local).AddTicks(8459), new DateTime(2022, 12, 12, 11, 21, 25, 388, DateTimeKind.Local).AddTicks(8459) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 12, 11, 21, 25, 388, DateTimeKind.Local).AddTicks(8471), new DateTime(2022, 12, 12, 11, 21, 25, 388, DateTimeKind.Local).AddTicks(8472) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 12, 11, 21, 25, 388, DateTimeKind.Local).AddTicks(8480), new DateTime(2022, 12, 12, 11, 21, 25, 388, DateTimeKind.Local).AddTicks(8481) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 12, 11, 21, 25, 388, DateTimeKind.Local).AddTicks(8488), new DateTime(2022, 12, 12, 11, 21, 25, 388, DateTimeKind.Local).AddTicks(8489) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 12, 11, 21, 25, 388, DateTimeKind.Local).AddTicks(8496), new DateTime(2022, 12, 12, 11, 21, 25, 388, DateTimeKind.Local).AddTicks(8497) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 12, 11, 21, 25, 388, DateTimeKind.Local).AddTicks(8505), new DateTime(2022, 12, 12, 11, 21, 25, 388, DateTimeKind.Local).AddTicks(8506) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 12, 11, 21, 25, 388, DateTimeKind.Local).AddTicks(8525), new DateTime(2022, 12, 12, 11, 21, 25, 388, DateTimeKind.Local).AddTicks(8526) });

            migrationBuilder.UpdateData(
                table: "Plan",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 12, 11, 21, 25, 388, DateTimeKind.Local).AddTicks(8195), new DateTime(2022, 12, 12, 11, 21, 25, 388, DateTimeKind.Local).AddTicks(8208) });

            migrationBuilder.UpdateData(
                table: "Plan",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 12, 11, 21, 25, 388, DateTimeKind.Local).AddTicks(8263), new DateTime(2022, 12, 12, 11, 21, 25, 388, DateTimeKind.Local).AddTicks(8264) });

            migrationBuilder.UpdateData(
                table: "Plan",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 12, 11, 21, 25, 388, DateTimeKind.Local).AddTicks(8280), new DateTime(2022, 12, 12, 11, 21, 25, 388, DateTimeKind.Local).AddTicks(8281) });

            migrationBuilder.UpdateData(
                table: "SubPlan",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 12, 11, 21, 25, 388, DateTimeKind.Local).AddTicks(8347), new DateTime(2022, 12, 12, 11, 21, 25, 388, DateTimeKind.Local).AddTicks(8348) });

            migrationBuilder.UpdateData(
                table: "SubPlan",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 12, 11, 21, 25, 388, DateTimeKind.Local).AddTicks(8364), new DateTime(2022, 12, 12, 11, 21, 25, 388, DateTimeKind.Local).AddTicks(8365) });

            migrationBuilder.UpdateData(
                table: "SubPlan",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 12, 11, 21, 25, 388, DateTimeKind.Local).AddTicks(8375), new DateTime(2022, 12, 12, 11, 21, 25, 388, DateTimeKind.Local).AddTicks(8375) });

            migrationBuilder.UpdateData(
                table: "SubPlan",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 12, 11, 21, 25, 388, DateTimeKind.Local).AddTicks(8383), new DateTime(2022, 12, 12, 11, 21, 25, 388, DateTimeKind.Local).AddTicks(8383) });

            migrationBuilder.UpdateData(
                table: "SubPlan",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 12, 11, 21, 25, 388, DateTimeKind.Local).AddTicks(8391), new DateTime(2022, 12, 12, 11, 21, 25, 388, DateTimeKind.Local).AddTicks(8392) });

            migrationBuilder.UpdateData(
                table: "SubPlan",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 12, 11, 21, 25, 388, DateTimeKind.Local).AddTicks(8401), new DateTime(2022, 12, 12, 11, 21, 25, 388, DateTimeKind.Local).AddTicks(8402) });

            migrationBuilder.UpdateData(
                table: "SubPlan",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 12, 11, 21, 25, 388, DateTimeKind.Local).AddTicks(8410), new DateTime(2022, 12, 12, 11, 21, 25, 388, DateTimeKind.Local).AddTicks(8411) });

            migrationBuilder.UpdateData(
                table: "SubPlan",
                keyColumn: "Id",
                keyValue: 8L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 12, 11, 21, 25, 388, DateTimeKind.Local).AddTicks(8418), new DateTime(2022, 12, 12, 11, 21, 25, 388, DateTimeKind.Local).AddTicks(8419) });

            migrationBuilder.UpdateData(
                table: "SubPlan",
                keyColumn: "Id",
                keyValue: 9L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 12, 11, 21, 25, 388, DateTimeKind.Local).AddTicks(8427), new DateTime(2022, 12, 12, 11, 21, 25, 388, DateTimeKind.Local).AddTicks(8427) });

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentRequests_SubPlan_SubPlanId1",
                table: "PaymentRequests",
                column: "SubPlanId1",
                principalTable: "SubPlan",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PaymentRequests_SubPlan_SubPlanId1",
                table: "PaymentRequests");

            migrationBuilder.RenameColumn(
                name: "SubPlanId1",
                table: "PaymentRequests",
                newName: "SubPlanId");

            migrationBuilder.RenameIndex(
                name: "IX_PaymentRequests_SubPlanId1",
                table: "PaymentRequests",
                newName: "IX_PaymentRequests_SubPlanId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentRequests_SubPlan_SubPlanId",
                table: "PaymentRequests",
                column: "SubPlanId",
                principalTable: "SubPlan",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
