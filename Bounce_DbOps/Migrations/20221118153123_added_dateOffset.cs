using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bounce_DbOps.Migrations
{
    public partial class added_dateOffset : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedTimeOffset",
                table: "Wallets",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "ModifiedTimeOffset",
                table: "Wallets",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedTimeOffset",
                table: "WalletRequests",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "ModifiedTimeOffset",
                table: "WalletRequests",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedTimeOffset",
                table: "UserProfile",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "ModifiedTimeOffset",
                table: "UserProfile",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedTimeOffset",
                table: "Transactions",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "ModifiedTimeOffset",
                table: "Transactions",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedTimeOffset",
                table: "Tokens",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "ModifiedTimeOffset",
                table: "Tokens",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedTimeOffset",
                table: "TherapistmedicalRegistrations",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "ModifiedTimeOffset",
                table: "TherapistmedicalRegistrations",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedTimeOffset",
                table: "TherapistHospitalInformations",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "ModifiedTimeOffset",
                table: "TherapistHospitalInformations",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedTimeOffset",
                table: "Subscriptions",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "ModifiedTimeOffset",
                table: "Subscriptions",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedTimeOffset",
                table: "SerialNumbers",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "ModifiedTimeOffset",
                table: "SerialNumbers",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedTimeOffset",
                table: "Plan",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "ModifiedTimeOffset",
                table: "Plan",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedTimeOffset",
                table: "PaymentRequests",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "ModifiedTimeOffset",
                table: "PaymentRequests",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedTimeOffset",
                table: "Notification",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "ModifiedTimeOffset",
                table: "Notification",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedTimeOffset",
                table: "InteractiveSessions",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "ModifiedTimeOffset",
                table: "InteractiveSessions",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedTimeOffset",
                table: "Errors",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "ModifiedTimeOffset",
                table: "Errors",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedTimeOffset",
                table: "Chats",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "ModifiedTimeOffset",
                table: "Chats",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedTimeOffset",
                table: "BankAccountDetails",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "ModifiedTimeOffset",
                table: "BankAccountDetails",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedTimeOffset",
                table: "Articles",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "ModifiedTimeOffset",
                table: "Articles",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedTimeOffset",
                table: "Appointments",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "ModifiedTimeOffset",
                table: "Appointments",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedTimeOffset",
                table: "AppointmentRequest",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "ModifiedTimeOffset",
                table: "AppointmentRequest",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Plan",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 11, 18, 15, 31, 22, 605, DateTimeKind.Utc).AddTicks(5182), new DateTime(2022, 11, 18, 15, 31, 22, 605, DateTimeKind.Utc).AddTicks(5187) });

            migrationBuilder.UpdateData(
                table: "Plan",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 11, 18, 15, 31, 22, 605, DateTimeKind.Utc).AddTicks(6122), new DateTime(2022, 11, 18, 15, 31, 22, 605, DateTimeKind.Utc).AddTicks(6123) });

            migrationBuilder.UpdateData(
                table: "Plan",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 11, 18, 15, 31, 22, 605, DateTimeKind.Utc).AddTicks(6146), new DateTime(2022, 11, 18, 15, 31, 22, 605, DateTimeKind.Utc).AddTicks(6147) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedTimeOffset",
                table: "Wallets");

            migrationBuilder.DropColumn(
                name: "ModifiedTimeOffset",
                table: "Wallets");

            migrationBuilder.DropColumn(
                name: "CreatedTimeOffset",
                table: "WalletRequests");

            migrationBuilder.DropColumn(
                name: "ModifiedTimeOffset",
                table: "WalletRequests");

            migrationBuilder.DropColumn(
                name: "CreatedTimeOffset",
                table: "UserProfile");

            migrationBuilder.DropColumn(
                name: "ModifiedTimeOffset",
                table: "UserProfile");

            migrationBuilder.DropColumn(
                name: "CreatedTimeOffset",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "ModifiedTimeOffset",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "CreatedTimeOffset",
                table: "Tokens");

            migrationBuilder.DropColumn(
                name: "ModifiedTimeOffset",
                table: "Tokens");

            migrationBuilder.DropColumn(
                name: "CreatedTimeOffset",
                table: "TherapistmedicalRegistrations");

            migrationBuilder.DropColumn(
                name: "ModifiedTimeOffset",
                table: "TherapistmedicalRegistrations");

            migrationBuilder.DropColumn(
                name: "CreatedTimeOffset",
                table: "TherapistHospitalInformations");

            migrationBuilder.DropColumn(
                name: "ModifiedTimeOffset",
                table: "TherapistHospitalInformations");

            migrationBuilder.DropColumn(
                name: "CreatedTimeOffset",
                table: "Subscriptions");

            migrationBuilder.DropColumn(
                name: "ModifiedTimeOffset",
                table: "Subscriptions");

            migrationBuilder.DropColumn(
                name: "CreatedTimeOffset",
                table: "SerialNumbers");

            migrationBuilder.DropColumn(
                name: "ModifiedTimeOffset",
                table: "SerialNumbers");

            migrationBuilder.DropColumn(
                name: "CreatedTimeOffset",
                table: "Plan");

            migrationBuilder.DropColumn(
                name: "ModifiedTimeOffset",
                table: "Plan");

            migrationBuilder.DropColumn(
                name: "CreatedTimeOffset",
                table: "PaymentRequests");

            migrationBuilder.DropColumn(
                name: "ModifiedTimeOffset",
                table: "PaymentRequests");

            migrationBuilder.DropColumn(
                name: "CreatedTimeOffset",
                table: "Notification");

            migrationBuilder.DropColumn(
                name: "ModifiedTimeOffset",
                table: "Notification");

            migrationBuilder.DropColumn(
                name: "CreatedTimeOffset",
                table: "InteractiveSessions");

            migrationBuilder.DropColumn(
                name: "ModifiedTimeOffset",
                table: "InteractiveSessions");

            migrationBuilder.DropColumn(
                name: "CreatedTimeOffset",
                table: "Errors");

            migrationBuilder.DropColumn(
                name: "ModifiedTimeOffset",
                table: "Errors");

            migrationBuilder.DropColumn(
                name: "CreatedTimeOffset",
                table: "Chats");

            migrationBuilder.DropColumn(
                name: "ModifiedTimeOffset",
                table: "Chats");

            migrationBuilder.DropColumn(
                name: "CreatedTimeOffset",
                table: "BankAccountDetails");

            migrationBuilder.DropColumn(
                name: "ModifiedTimeOffset",
                table: "BankAccountDetails");

            migrationBuilder.DropColumn(
                name: "CreatedTimeOffset",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "ModifiedTimeOffset",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "CreatedTimeOffset",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "ModifiedTimeOffset",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "CreatedTimeOffset",
                table: "AppointmentRequest");

            migrationBuilder.DropColumn(
                name: "ModifiedTimeOffset",
                table: "AppointmentRequest");

            migrationBuilder.UpdateData(
                table: "Plan",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 11, 16, 21, 25, 25, 118, DateTimeKind.Local).AddTicks(5765), new DateTime(2022, 11, 16, 21, 25, 25, 118, DateTimeKind.Local).AddTicks(5777) });

            migrationBuilder.UpdateData(
                table: "Plan",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 11, 16, 21, 25, 25, 118, DateTimeKind.Local).AddTicks(5807), new DateTime(2022, 11, 16, 21, 25, 25, 118, DateTimeKind.Local).AddTicks(5808) });

            migrationBuilder.UpdateData(
                table: "Plan",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 11, 16, 21, 25, 25, 118, DateTimeKind.Local).AddTicks(5818), new DateTime(2022, 11, 16, 21, 25, 25, 118, DateTimeKind.Local).AddTicks(5819) });
        }
    }
}
