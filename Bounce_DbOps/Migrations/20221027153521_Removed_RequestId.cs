using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bounce_DbOps.Migrations
{
    public partial class Removed_RequestId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_PaymentRequests_RequestId",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_WalletRequests_WalletRequestId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_RequestId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_WalletRequestId",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "WalletRequestId",
                table: "Transactions");

            migrationBuilder.AlterColumn<long>(
                name: "RequestId",
                table: "Transactions",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.UpdateData(
                table: "Plan",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 10, 27, 16, 35, 20, 776, DateTimeKind.Local).AddTicks(1338), new DateTime(2022, 10, 27, 16, 35, 20, 776, DateTimeKind.Local).AddTicks(1346) });

            migrationBuilder.UpdateData(
                table: "Plan",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 10, 27, 16, 35, 20, 776, DateTimeKind.Local).AddTicks(1374), new DateTime(2022, 10, 27, 16, 35, 20, 776, DateTimeKind.Local).AddTicks(1374) });

            migrationBuilder.UpdateData(
                table: "Plan",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 10, 27, 16, 35, 20, 776, DateTimeKind.Local).AddTicks(1395), new DateTime(2022, 10, 27, 16, 35, 20, 776, DateTimeKind.Local).AddTicks(1395) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "RequestId",
                table: "Transactions",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddColumn<long>(
                name: "WalletRequestId",
                table: "Transactions",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.UpdateData(
                table: "Plan",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 10, 27, 16, 10, 42, 230, DateTimeKind.Local).AddTicks(8372), new DateTime(2022, 10, 27, 16, 10, 42, 230, DateTimeKind.Local).AddTicks(8382) });

            migrationBuilder.UpdateData(
                table: "Plan",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 10, 27, 16, 10, 42, 230, DateTimeKind.Local).AddTicks(8402), new DateTime(2022, 10, 27, 16, 10, 42, 230, DateTimeKind.Local).AddTicks(8403) });

            migrationBuilder.UpdateData(
                table: "Plan",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 10, 27, 16, 10, 42, 230, DateTimeKind.Local).AddTicks(8410), new DateTime(2022, 10, 27, 16, 10, 42, 230, DateTimeKind.Local).AddTicks(8411) });

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_RequestId",
                table: "Transactions",
                column: "RequestId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_WalletRequestId",
                table: "Transactions",
                column: "WalletRequestId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_PaymentRequests_RequestId",
                table: "Transactions",
                column: "RequestId",
                principalTable: "PaymentRequests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_WalletRequests_WalletRequestId",
                table: "Transactions",
                column: "WalletRequestId",
                principalTable: "WalletRequests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
