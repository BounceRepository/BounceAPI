using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bounce_DbOps.Migrations
{
    public partial class add_subplanId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { new DateTime(2022, 12, 12, 11, 26, 13, 771, DateTimeKind.Local).AddTicks(6699), new DateTime(2022, 12, 12, 11, 26, 13, 771, DateTimeKind.Local).AddTicks(6699) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 12, 11, 26, 13, 771, DateTimeKind.Local).AddTicks(6708), new DateTime(2022, 12, 12, 11, 26, 13, 771, DateTimeKind.Local).AddTicks(6708) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 12, 11, 26, 13, 771, DateTimeKind.Local).AddTicks(6726), new DateTime(2022, 12, 12, 11, 26, 13, 771, DateTimeKind.Local).AddTicks(6727) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 12, 11, 26, 13, 771, DateTimeKind.Local).AddTicks(6734), new DateTime(2022, 12, 12, 11, 26, 13, 771, DateTimeKind.Local).AddTicks(6735) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 12, 11, 26, 13, 771, DateTimeKind.Local).AddTicks(6742), new DateTime(2022, 12, 12, 11, 26, 13, 771, DateTimeKind.Local).AddTicks(6743) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 12, 11, 26, 13, 771, DateTimeKind.Local).AddTicks(6751), new DateTime(2022, 12, 12, 11, 26, 13, 771, DateTimeKind.Local).AddTicks(6751) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 12, 11, 26, 13, 771, DateTimeKind.Local).AddTicks(6758), new DateTime(2022, 12, 12, 11, 26, 13, 771, DateTimeKind.Local).AddTicks(6759) });

            migrationBuilder.UpdateData(
                table: "Plan",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 12, 11, 26, 13, 771, DateTimeKind.Local).AddTicks(6521), new DateTime(2022, 12, 12, 11, 26, 13, 771, DateTimeKind.Local).AddTicks(6530) });

            migrationBuilder.UpdateData(
                table: "Plan",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 12, 11, 26, 13, 771, DateTimeKind.Local).AddTicks(6559), new DateTime(2022, 12, 12, 11, 26, 13, 771, DateTimeKind.Local).AddTicks(6559) });

            migrationBuilder.UpdateData(
                table: "Plan",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 12, 11, 26, 13, 771, DateTimeKind.Local).AddTicks(6568), new DateTime(2022, 12, 12, 11, 26, 13, 771, DateTimeKind.Local).AddTicks(6569) });

            migrationBuilder.UpdateData(
                table: "SubPlan",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 12, 11, 26, 13, 771, DateTimeKind.Local).AddTicks(6614), new DateTime(2022, 12, 12, 11, 26, 13, 771, DateTimeKind.Local).AddTicks(6614) });

            migrationBuilder.UpdateData(
                table: "SubPlan",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 12, 11, 26, 13, 771, DateTimeKind.Local).AddTicks(6627), new DateTime(2022, 12, 12, 11, 26, 13, 771, DateTimeKind.Local).AddTicks(6627) });

            migrationBuilder.UpdateData(
                table: "SubPlan",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 12, 11, 26, 13, 771, DateTimeKind.Local).AddTicks(6635), new DateTime(2022, 12, 12, 11, 26, 13, 771, DateTimeKind.Local).AddTicks(6635) });

            migrationBuilder.UpdateData(
                table: "SubPlan",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 12, 11, 26, 13, 771, DateTimeKind.Local).AddTicks(6642), new DateTime(2022, 12, 12, 11, 26, 13, 771, DateTimeKind.Local).AddTicks(6642) });

            migrationBuilder.UpdateData(
                table: "SubPlan",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 12, 11, 26, 13, 771, DateTimeKind.Local).AddTicks(6649), new DateTime(2022, 12, 12, 11, 26, 13, 771, DateTimeKind.Local).AddTicks(6650) });

            migrationBuilder.UpdateData(
                table: "SubPlan",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 12, 11, 26, 13, 771, DateTimeKind.Local).AddTicks(6658), new DateTime(2022, 12, 12, 11, 26, 13, 771, DateTimeKind.Local).AddTicks(6658) });

            migrationBuilder.UpdateData(
                table: "SubPlan",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 12, 11, 26, 13, 771, DateTimeKind.Local).AddTicks(6665), new DateTime(2022, 12, 12, 11, 26, 13, 771, DateTimeKind.Local).AddTicks(6666) });

            migrationBuilder.UpdateData(
                table: "SubPlan",
                keyColumn: "Id",
                keyValue: 8L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 12, 11, 26, 13, 771, DateTimeKind.Local).AddTicks(6672), new DateTime(2022, 12, 12, 11, 26, 13, 771, DateTimeKind.Local).AddTicks(6673) });

            migrationBuilder.UpdateData(
                table: "SubPlan",
                keyColumn: "Id",
                keyValue: 9L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 12, 11, 26, 13, 771, DateTimeKind.Local).AddTicks(6679), new DateTime(2022, 12, 12, 11, 26, 13, 771, DateTimeKind.Local).AddTicks(6680) });

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentRequests_SubPlan_SubPlanId",
                table: "PaymentRequests",
                column: "SubPlanId",
                principalTable: "SubPlan",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                onDelete: ReferentialAction.NoAction);
        }
    }
}
