using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bounce_DbOps.Migrations
{
    public partial class addsubscriptionseedsss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BioDatas_AspNetUsers_UserId",
                table: "BioDatas");

            migrationBuilder.DropForeignKey(
                name: "FK_PaymentRequests_Plans_PlanId",
                table: "PaymentRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_Subscriptions_Plans_PlanId",
                table: "Subscriptions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Plans",
                table: "Plans");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BioDatas",
                table: "BioDatas");

            migrationBuilder.RenameTable(
                name: "Plans",
                newName: "Plan");

            migrationBuilder.RenameTable(
                name: "BioDatas",
                newName: "BioData");

            migrationBuilder.RenameIndex(
                name: "IX_BioDatas_UserId",
                table: "BioData",
                newName: "IX_BioData_UserId");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Plan",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "DailyMeditationCount",
                table: "Plan",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FreeTrialCount",
                table: "Plan",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TherapistCount",
                table: "Plan",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Plan",
                table: "Plan",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BioData",
                table: "BioData",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Plan",
                columns: new[] { "Id", "Cost", "DailyMeditationCount", "DateCreated", "DateModified", "Description", "Duration", "FreeTrialCount", "IsActive", "IsDeleted", "LastModifiedBy", "Name", "TherapistCount" },
                values: new object[] { 1L, 50000.0, 100, new DateTime(2022, 10, 20, 16, 46, 4, 228, DateTimeKind.Local).AddTicks(5016), new DateTime(2022, 10, 20, 16, 46, 4, 228, DateTimeKind.Local).AddTicks(5025), null, 0, 7, false, false, null, "Bronze", 100 });

            migrationBuilder.InsertData(
                table: "Plan",
                columns: new[] { "Id", "Cost", "DailyMeditationCount", "DateCreated", "DateModified", "Description", "Duration", "FreeTrialCount", "IsActive", "IsDeleted", "LastModifiedBy", "Name", "TherapistCount" },
                values: new object[] { 2L, 100000.0, 200, new DateTime(2022, 10, 20, 16, 46, 4, 228, DateTimeKind.Local).AddTicks(5052), new DateTime(2022, 10, 20, 16, 46, 4, 228, DateTimeKind.Local).AddTicks(5052), null, 0, 7, false, false, null, "Silver", 200 });

            migrationBuilder.InsertData(
                table: "Plan",
                columns: new[] { "Id", "Cost", "DailyMeditationCount", "DateCreated", "DateModified", "Description", "Duration", "FreeTrialCount", "IsActive", "IsDeleted", "LastModifiedBy", "Name", "TherapistCount" },
                values: new object[] { 3L, 200000.0, 500, new DateTime(2022, 10, 20, 16, 46, 4, 228, DateTimeKind.Local).AddTicks(5063), new DateTime(2022, 10, 20, 16, 46, 4, 228, DateTimeKind.Local).AddTicks(5064), null, 0, 7, false, false, null, "Gold", 500 });

            migrationBuilder.AddForeignKey(
                name: "FK_BioData_AspNetUsers_UserId",
                table: "BioData",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentRequests_Plan_PlanId",
                table: "PaymentRequests",
                column: "PlanId",
                principalTable: "Plan",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Subscriptions_Plan_PlanId",
                table: "Subscriptions",
                column: "PlanId",
                principalTable: "Plan",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BioData_AspNetUsers_UserId",
                table: "BioData");

            migrationBuilder.DropForeignKey(
                name: "FK_PaymentRequests_Plan_PlanId",
                table: "PaymentRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_Subscriptions_Plan_PlanId",
                table: "Subscriptions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Plan",
                table: "Plan");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BioData",
                table: "BioData");

            migrationBuilder.DeleteData(
                table: "Plan",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Plan",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Plan",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DropColumn(
                name: "DailyMeditationCount",
                table: "Plan");

            migrationBuilder.DropColumn(
                name: "FreeTrialCount",
                table: "Plan");

            migrationBuilder.DropColumn(
                name: "TherapistCount",
                table: "Plan");

            migrationBuilder.RenameTable(
                name: "Plan",
                newName: "Plans");

            migrationBuilder.RenameTable(
                name: "BioData",
                newName: "BioDatas");

            migrationBuilder.RenameIndex(
                name: "IX_BioData_UserId",
                table: "BioDatas",
                newName: "IX_BioDatas_UserId");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Plans",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Plans",
                table: "Plans",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BioDatas",
                table: "BioDatas",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BioDatas_AspNetUsers_UserId",
                table: "BioDatas",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentRequests_Plans_PlanId",
                table: "PaymentRequests",
                column: "PlanId",
                principalTable: "Plans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Subscriptions_Plans_PlanId",
                table: "Subscriptions",
                column: "PlanId",
                principalTable: "Plans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
