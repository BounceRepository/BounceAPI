using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bounce_DbOps.Migrations
{
    public partial class subId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PaymentRequests_SubPlan_SubPlanId",
                table: "PaymentRequests");

            migrationBuilder.DropIndex(
                name: "IX_PaymentRequests_SubPlanId",
                table: "PaymentRequests");

            migrationBuilder.AlterColumn<long>(
                name: "SubPlanId",
                table: "PaymentRequests",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<long>(
                name: "SubId",
                table: "PaymentRequests",
                type: "bigint",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_PaymentRequests_SubId",
                table: "PaymentRequests",
                column: "SubId");

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentRequests_SubPlan_SubId",
                table: "PaymentRequests",
                column: "SubId",
                principalTable: "SubPlan",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PaymentRequests_SubPlan_SubId",
                table: "PaymentRequests");

            migrationBuilder.DropIndex(
                name: "IX_PaymentRequests_SubId",
                table: "PaymentRequests");

            migrationBuilder.DropColumn(
                name: "SubId",
                table: "PaymentRequests");

            migrationBuilder.AlterColumn<long>(
                name: "SubPlanId",
                table: "PaymentRequests",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_PaymentRequests_SubPlanId",
                table: "PaymentRequests",
                column: "SubPlanId");

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
