using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bounce_DbOps.Migrations
{
    public partial class addedsubPlansseed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PaymentRequests_Plan_PlanId",
                table: "PaymentRequests");

            migrationBuilder.DropColumn(
                name: "AvailableBalance",
                table: "Wallets");

            migrationBuilder.RenameColumn(
                name: "PlanId",
                table: "PaymentRequests",
                newName: "SubPlanId");

            migrationBuilder.RenameIndex(
                name: "IX_PaymentRequests_PlanId",
                table: "PaymentRequests",
                newName: "IX_PaymentRequests_SubPlanId");

            migrationBuilder.CreateTable(
                name: "SubPlan",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PLanId = table.Column<long>(type: "bigint", nullable: false),
                    FreeTrialCount = table.Column<int>(type: "int", nullable: false),
                    NumberOfMeditation = table.Column<int>(type: "int", nullable: false),
                    Cost = table.Column<double>(type: "float", nullable: false),
                    TherapistCount = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedTimeOffset = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    ModifiedTimeOffset = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubPlan", x => x.Id);
                });

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

            migrationBuilder.InsertData(
                table: "SubPlan",
                columns: new[] { "Id", "Cost", "CreatedTimeOffset", "DateCreated", "DateModified", "FreeTrialCount", "IsActive", "IsDeleted", "LastModifiedBy", "ModifiedTimeOffset", "NumberOfMeditation", "PLanId", "TherapistCount", "Title" },
                values: new object[,]
                {
                    { 1L, 100000.0, null, new DateTime(2022, 12, 12, 9, 21, 14, 139, DateTimeKind.Local).AddTicks(9002), new DateTime(2022, 12, 12, 9, 21, 14, 139, DateTimeKind.Local).AddTicks(9002), 50, false, false, null, null, 100, 3L, 50, "Annual" },
                    { 2L, 80000.0, null, new DateTime(2022, 12, 12, 9, 21, 14, 139, DateTimeKind.Local).AddTicks(9014), new DateTime(2022, 12, 12, 9, 21, 14, 139, DateTimeKind.Local).AddTicks(9014), 30, false, false, null, null, 50, 3L, 36, "Quarter" },
                    { 3L, 500000.0, null, new DateTime(2022, 12, 12, 9, 21, 14, 139, DateTimeKind.Local).AddTicks(9022), new DateTime(2022, 12, 12, 9, 21, 14, 139, DateTimeKind.Local).AddTicks(9022), 20, false, false, null, null, 30, 3L, 30, "Month" },
                    { 4L, 50000.0, null, new DateTime(2022, 12, 12, 9, 21, 14, 139, DateTimeKind.Local).AddTicks(9029), new DateTime(2022, 12, 12, 9, 21, 14, 139, DateTimeKind.Local).AddTicks(9030), 20, false, false, null, null, 50, 2L, 30, "Annual" },
                    { 5L, 420000.0, null, new DateTime(2022, 12, 12, 9, 21, 14, 139, DateTimeKind.Local).AddTicks(9037), new DateTime(2022, 12, 12, 9, 21, 14, 139, DateTimeKind.Local).AddTicks(9037), 30, false, false, null, null, 40, 2L, 30, "Quarter" },
                    { 6L, 350000.0, null, new DateTime(2022, 12, 12, 9, 21, 14, 139, DateTimeKind.Local).AddTicks(9046), new DateTime(2022, 12, 12, 9, 21, 14, 139, DateTimeKind.Local).AddTicks(9046), 18, false, false, null, null, 30, 2L, 29, "Month" },
                    { 7L, 20000.0, null, new DateTime(2022, 12, 12, 9, 21, 14, 139, DateTimeKind.Local).AddTicks(9053), new DateTime(2022, 12, 12, 9, 21, 14, 139, DateTimeKind.Local).AddTicks(9054), 10, false, false, null, null, 30, 1L, 20, "Annual" },
                    { 8L, 10000.0, null, new DateTime(2022, 12, 12, 9, 21, 14, 139, DateTimeKind.Local).AddTicks(9061), new DateTime(2022, 12, 12, 9, 21, 14, 139, DateTimeKind.Local).AddTicks(9061), 5, false, false, null, null, 20, 1L, 15, "Quarter" },
                    { 9L, 5000.0, null, new DateTime(2022, 12, 12, 9, 21, 14, 139, DateTimeKind.Local).AddTicks(9068), new DateTime(2022, 12, 12, 9, 21, 14, 139, DateTimeKind.Local).AddTicks(9068), 2, false, false, null, null, 10, 2L, 10, "Month" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentRequests_SubPlan_SubPlanId",
                table: "PaymentRequests",
                column: "SubPlanId",
                principalTable: "SubPlan",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PaymentRequests_SubPlan_SubPlanId",
                table: "PaymentRequests");

            migrationBuilder.DropTable(
                name: "SubPlan");

            migrationBuilder.RenameColumn(
                name: "SubPlanId",
                table: "PaymentRequests",
                newName: "PlanId");

            migrationBuilder.RenameIndex(
                name: "IX_PaymentRequests_SubPlanId",
                table: "PaymentRequests",
                newName: "IX_PaymentRequests_PlanId");

            migrationBuilder.AddColumn<double>(
                name: "AvailableBalance",
                table: "Wallets",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 6, 15, 47, 48, 80, DateTimeKind.Local).AddTicks(2497), new DateTime(2022, 12, 6, 15, 47, 48, 80, DateTimeKind.Local).AddTicks(2498) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 6, 15, 47, 48, 80, DateTimeKind.Local).AddTicks(2508), new DateTime(2022, 12, 6, 15, 47, 48, 80, DateTimeKind.Local).AddTicks(2508) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 6, 15, 47, 48, 80, DateTimeKind.Local).AddTicks(2516), new DateTime(2022, 12, 6, 15, 47, 48, 80, DateTimeKind.Local).AddTicks(2516) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 6, 15, 47, 48, 80, DateTimeKind.Local).AddTicks(2523), new DateTime(2022, 12, 6, 15, 47, 48, 80, DateTimeKind.Local).AddTicks(2524) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 6, 15, 47, 48, 80, DateTimeKind.Local).AddTicks(2542), new DateTime(2022, 12, 6, 15, 47, 48, 80, DateTimeKind.Local).AddTicks(2543) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 6, 15, 47, 48, 80, DateTimeKind.Local).AddTicks(2551), new DateTime(2022, 12, 6, 15, 47, 48, 80, DateTimeKind.Local).AddTicks(2552) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 6, 15, 47, 48, 80, DateTimeKind.Local).AddTicks(2559), new DateTime(2022, 12, 6, 15, 47, 48, 80, DateTimeKind.Local).AddTicks(2560) });

            migrationBuilder.UpdateData(
                table: "Plan",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 6, 15, 47, 48, 80, DateTimeKind.Local).AddTicks(2431), new DateTime(2022, 12, 6, 15, 47, 48, 80, DateTimeKind.Local).AddTicks(2445) });

            migrationBuilder.UpdateData(
                table: "Plan",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 6, 15, 47, 48, 80, DateTimeKind.Local).AddTicks(2470), new DateTime(2022, 12, 6, 15, 47, 48, 80, DateTimeKind.Local).AddTicks(2470) });

            migrationBuilder.UpdateData(
                table: "Plan",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 6, 15, 47, 48, 80, DateTimeKind.Local).AddTicks(2479), new DateTime(2022, 12, 6, 15, 47, 48, 80, DateTimeKind.Local).AddTicks(2479) });

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentRequests_Plan_PlanId",
                table: "PaymentRequests",
                column: "PlanId",
                principalTable: "Plan",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
