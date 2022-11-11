using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bounce_DbOps.Migrations
{
    public partial class modifiedtransaction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Decription",
                table: "Transactions",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<DateTime>(
                name: "CompletionTime",
                table: "Transactions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "PaymentResponse",
                table: "Transactions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UserId",
                table: "Transactions",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "WalletRequestId",
                table: "Transactions",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "status",
                table: "Transactions",
                type: "nvarchar(max)",
                nullable: true);

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
                name: "IX_Transactions_UserId",
                table: "Transactions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_WalletRequestId",
                table: "Transactions",
                column: "WalletRequestId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_AspNetUsers_UserId",
                table: "Transactions",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_WalletRequests_WalletRequestId",
                table: "Transactions",
                column: "WalletRequestId",
                principalTable: "WalletRequests",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_AspNetUsers_UserId",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_WalletRequests_WalletRequestId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_UserId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_WalletRequestId",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "CompletionTime",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "PaymentResponse",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "WalletRequestId",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "status",
                table: "Transactions");

            migrationBuilder.AlterColumn<string>(
                name: "Decription",
                table: "Transactions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Plan",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 10, 27, 13, 24, 57, 607, DateTimeKind.Local).AddTicks(6702), new DateTime(2022, 10, 27, 13, 24, 57, 607, DateTimeKind.Local).AddTicks(6711) });

            migrationBuilder.UpdateData(
                table: "Plan",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 10, 27, 13, 24, 57, 607, DateTimeKind.Local).AddTicks(6738), new DateTime(2022, 10, 27, 13, 24, 57, 607, DateTimeKind.Local).AddTicks(6738) });

            migrationBuilder.UpdateData(
                table: "Plan",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 10, 27, 13, 24, 57, 607, DateTimeKind.Local).AddTicks(6748), new DateTime(2022, 10, 27, 13, 24, 57, 607, DateTimeKind.Local).AddTicks(6748) });
        }
    }
}
