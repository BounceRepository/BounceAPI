using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bounce_DbOps.Migrations
{
    public partial class Added_AlgoraChannelmodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PoolTransactions");

            migrationBuilder.CreateTable(
                name: "Channels",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChannelToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChannelName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AppointmentRequestId = table.Column<long>(type: "bigint", nullable: false),
                    CompletionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
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
                    table.PrimaryKey("PK_Channels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Channels_AppointmentRequest_AppointmentRequestId",
                        column: x => x.AppointmentRequestId,
                        principalTable: "AppointmentRequest",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2023, 1, 15, 7, 12, 46, 583, DateTimeKind.Local).AddTicks(7898), new DateTime(2023, 1, 15, 7, 12, 46, 583, DateTimeKind.Local).AddTicks(7899) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2023, 1, 15, 7, 12, 46, 583, DateTimeKind.Local).AddTicks(7908), new DateTime(2023, 1, 15, 7, 12, 46, 583, DateTimeKind.Local).AddTicks(7908) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2023, 1, 15, 7, 12, 46, 583, DateTimeKind.Local).AddTicks(7915), new DateTime(2023, 1, 15, 7, 12, 46, 583, DateTimeKind.Local).AddTicks(7916) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2023, 1, 15, 7, 12, 46, 583, DateTimeKind.Local).AddTicks(7922), new DateTime(2023, 1, 15, 7, 12, 46, 583, DateTimeKind.Local).AddTicks(7923) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2023, 1, 15, 7, 12, 46, 583, DateTimeKind.Local).AddTicks(7933), new DateTime(2023, 1, 15, 7, 12, 46, 583, DateTimeKind.Local).AddTicks(7934) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2023, 1, 15, 7, 12, 46, 583, DateTimeKind.Local).AddTicks(7941), new DateTime(2023, 1, 15, 7, 12, 46, 583, DateTimeKind.Local).AddTicks(7941) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2023, 1, 15, 7, 12, 46, 583, DateTimeKind.Local).AddTicks(7948), new DateTime(2023, 1, 15, 7, 12, 46, 583, DateTimeKind.Local).AddTicks(7948) });

            migrationBuilder.UpdateData(
                table: "Plan",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2023, 1, 15, 7, 12, 46, 583, DateTimeKind.Local).AddTicks(7747), new DateTime(2023, 1, 15, 7, 12, 46, 583, DateTimeKind.Local).AddTicks(7758) });

            migrationBuilder.UpdateData(
                table: "Plan",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2023, 1, 15, 7, 12, 46, 583, DateTimeKind.Local).AddTicks(7780), new DateTime(2023, 1, 15, 7, 12, 46, 583, DateTimeKind.Local).AddTicks(7780) });

            migrationBuilder.UpdateData(
                table: "Plan",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2023, 1, 15, 7, 12, 46, 583, DateTimeKind.Local).AddTicks(7788), new DateTime(2023, 1, 15, 7, 12, 46, 583, DateTimeKind.Local).AddTicks(7788) });

            migrationBuilder.UpdateData(
                table: "PoolAccount",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2023, 1, 15, 7, 12, 46, 583, DateTimeKind.Local).AddTicks(7961), new DateTime(2023, 1, 15, 7, 12, 46, 583, DateTimeKind.Local).AddTicks(7961) });

            migrationBuilder.UpdateData(
                table: "SubPlan",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2023, 1, 15, 7, 12, 46, 583, DateTimeKind.Local).AddTicks(7822), new DateTime(2023, 1, 15, 7, 12, 46, 583, DateTimeKind.Local).AddTicks(7823) });

            migrationBuilder.UpdateData(
                table: "SubPlan",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2023, 1, 15, 7, 12, 46, 583, DateTimeKind.Local).AddTicks(7833), new DateTime(2023, 1, 15, 7, 12, 46, 583, DateTimeKind.Local).AddTicks(7834) });

            migrationBuilder.UpdateData(
                table: "SubPlan",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2023, 1, 15, 7, 12, 46, 583, DateTimeKind.Local).AddTicks(7841), new DateTime(2023, 1, 15, 7, 12, 46, 583, DateTimeKind.Local).AddTicks(7841) });

            migrationBuilder.UpdateData(
                table: "SubPlan",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2023, 1, 15, 7, 12, 46, 583, DateTimeKind.Local).AddTicks(7848), new DateTime(2023, 1, 15, 7, 12, 46, 583, DateTimeKind.Local).AddTicks(7848) });

            migrationBuilder.UpdateData(
                table: "SubPlan",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2023, 1, 15, 7, 12, 46, 583, DateTimeKind.Local).AddTicks(7855), new DateTime(2023, 1, 15, 7, 12, 46, 583, DateTimeKind.Local).AddTicks(7855) });

            migrationBuilder.UpdateData(
                table: "SubPlan",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2023, 1, 15, 7, 12, 46, 583, DateTimeKind.Local).AddTicks(7862), new DateTime(2023, 1, 15, 7, 12, 46, 583, DateTimeKind.Local).AddTicks(7862) });

            migrationBuilder.UpdateData(
                table: "SubPlan",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2023, 1, 15, 7, 12, 46, 583, DateTimeKind.Local).AddTicks(7869), new DateTime(2023, 1, 15, 7, 12, 46, 583, DateTimeKind.Local).AddTicks(7869) });

            migrationBuilder.UpdateData(
                table: "SubPlan",
                keyColumn: "Id",
                keyValue: 8L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2023, 1, 15, 7, 12, 46, 583, DateTimeKind.Local).AddTicks(7876), new DateTime(2023, 1, 15, 7, 12, 46, 583, DateTimeKind.Local).AddTicks(7876) });

            migrationBuilder.UpdateData(
                table: "SubPlan",
                keyColumn: "Id",
                keyValue: 9L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2023, 1, 15, 7, 12, 46, 583, DateTimeKind.Local).AddTicks(7882), new DateTime(2023, 1, 15, 7, 12, 46, 583, DateTimeKind.Local).AddTicks(7883) });

            migrationBuilder.CreateIndex(
                name: "IX_Channels_AppointmentRequestId",
                table: "Channels",
                column: "AppointmentRequestId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Channels");

            migrationBuilder.CreateTable(
                name: "PoolTransactions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransactionCompletedByUserId = table.Column<long>(type: "bigint", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    CreatedTimeOffset = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Decsription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedTimeOffset = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    PoolType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TransactionInitiatedByUserId = table.Column<long>(type: "bigint", nullable: true),
                    TransactionRef = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransactionType = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PoolTransactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PoolTransactions_AspNetUsers_TransactionCompletedByUserId",
                        column: x => x.TransactionCompletedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 30, 23, 25, 54, 445, DateTimeKind.Local).AddTicks(9081), new DateTime(2022, 12, 30, 23, 25, 54, 445, DateTimeKind.Local).AddTicks(9082) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 30, 23, 25, 54, 445, DateTimeKind.Local).AddTicks(9100), new DateTime(2022, 12, 30, 23, 25, 54, 445, DateTimeKind.Local).AddTicks(9101) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 30, 23, 25, 54, 445, DateTimeKind.Local).AddTicks(9115), new DateTime(2022, 12, 30, 23, 25, 54, 445, DateTimeKind.Local).AddTicks(9115) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 30, 23, 25, 54, 445, DateTimeKind.Local).AddTicks(9129), new DateTime(2022, 12, 30, 23, 25, 54, 445, DateTimeKind.Local).AddTicks(9130) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 30, 23, 25, 54, 445, DateTimeKind.Local).AddTicks(9144), new DateTime(2022, 12, 30, 23, 25, 54, 445, DateTimeKind.Local).AddTicks(9144) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 30, 23, 25, 54, 445, DateTimeKind.Local).AddTicks(9160), new DateTime(2022, 12, 30, 23, 25, 54, 445, DateTimeKind.Local).AddTicks(9160) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 30, 23, 25, 54, 445, DateTimeKind.Local).AddTicks(9174), new DateTime(2022, 12, 30, 23, 25, 54, 445, DateTimeKind.Local).AddTicks(9175) });

            migrationBuilder.UpdateData(
                table: "Plan",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 30, 23, 25, 54, 445, DateTimeKind.Local).AddTicks(8762), new DateTime(2022, 12, 30, 23, 25, 54, 445, DateTimeKind.Local).AddTicks(8775) });

            migrationBuilder.UpdateData(
                table: "Plan",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 30, 23, 25, 54, 445, DateTimeKind.Local).AddTicks(8817), new DateTime(2022, 12, 30, 23, 25, 54, 445, DateTimeKind.Local).AddTicks(8817) });

            migrationBuilder.UpdateData(
                table: "Plan",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 30, 23, 25, 54, 445, DateTimeKind.Local).AddTicks(8834), new DateTime(2022, 12, 30, 23, 25, 54, 445, DateTimeKind.Local).AddTicks(8835) });

            migrationBuilder.UpdateData(
                table: "PoolAccount",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 30, 23, 25, 54, 445, DateTimeKind.Local).AddTicks(9195), new DateTime(2022, 12, 30, 23, 25, 54, 445, DateTimeKind.Local).AddTicks(9196) });

            migrationBuilder.UpdateData(
                table: "SubPlan",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 30, 23, 25, 54, 445, DateTimeKind.Local).AddTicks(8897), new DateTime(2022, 12, 30, 23, 25, 54, 445, DateTimeKind.Local).AddTicks(8898) });

            migrationBuilder.UpdateData(
                table: "SubPlan",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 30, 23, 25, 54, 445, DateTimeKind.Local).AddTicks(8924), new DateTime(2022, 12, 30, 23, 25, 54, 445, DateTimeKind.Local).AddTicks(8925) });

            migrationBuilder.UpdateData(
                table: "SubPlan",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 30, 23, 25, 54, 445, DateTimeKind.Local).AddTicks(8940), new DateTime(2022, 12, 30, 23, 25, 54, 445, DateTimeKind.Local).AddTicks(8941) });

            migrationBuilder.UpdateData(
                table: "SubPlan",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 30, 23, 25, 54, 445, DateTimeKind.Local).AddTicks(8956), new DateTime(2022, 12, 30, 23, 25, 54, 445, DateTimeKind.Local).AddTicks(8957) });

            migrationBuilder.UpdateData(
                table: "SubPlan",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 30, 23, 25, 54, 445, DateTimeKind.Local).AddTicks(8986), new DateTime(2022, 12, 30, 23, 25, 54, 445, DateTimeKind.Local).AddTicks(8986) });

            migrationBuilder.UpdateData(
                table: "SubPlan",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 30, 23, 25, 54, 445, DateTimeKind.Local).AddTicks(9004), new DateTime(2022, 12, 30, 23, 25, 54, 445, DateTimeKind.Local).AddTicks(9005) });

            migrationBuilder.UpdateData(
                table: "SubPlan",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 30, 23, 25, 54, 445, DateTimeKind.Local).AddTicks(9020), new DateTime(2022, 12, 30, 23, 25, 54, 445, DateTimeKind.Local).AddTicks(9020) });

            migrationBuilder.UpdateData(
                table: "SubPlan",
                keyColumn: "Id",
                keyValue: 8L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 30, 23, 25, 54, 445, DateTimeKind.Local).AddTicks(9035), new DateTime(2022, 12, 30, 23, 25, 54, 445, DateTimeKind.Local).AddTicks(9036) });

            migrationBuilder.UpdateData(
                table: "SubPlan",
                keyColumn: "Id",
                keyValue: 9L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 30, 23, 25, 54, 445, DateTimeKind.Local).AddTicks(9051), new DateTime(2022, 12, 30, 23, 25, 54, 445, DateTimeKind.Local).AddTicks(9051) });

            migrationBuilder.CreateIndex(
                name: "IX_PoolTransactions_TransactionCompletedByUserId",
                table: "PoolTransactions",
                column: "TransactionCompletedByUserId");
        }
    }
}
