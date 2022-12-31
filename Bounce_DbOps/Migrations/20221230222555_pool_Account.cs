using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bounce_DbOps.Migrations
{
    public partial class pool_Account : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TransactionRef",
                table: "Commisions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "PoolAccount",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Balance = table.Column<double>(type: "float", nullable: false),
                    Aux = table.Column<double>(type: "float", nullable: false),
                    Aux2 = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_PoolAccount", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PoolTransactions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransactionRef = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    TransactionInitiatedByUserId = table.Column<long>(type: "bigint", nullable: true),
                    PoolType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TransactionType = table.Column<int>(type: "int", nullable: true),
                    Decsription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransactionCompletedByUserId = table.Column<long>(type: "bigint", nullable: false),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false),
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

            migrationBuilder.InsertData(
                table: "PoolAccount",
                columns: new[] { "Id", "Aux", "Aux2", "Balance", "CreatedTimeOffset", "DateCreated", "DateModified", "IsActive", "IsDeleted", "LastModifiedBy", "ModifiedTimeOffset" },
                values: new object[] { 1L, 0.0, 0, 0.0, null, new DateTime(2022, 12, 30, 23, 25, 54, 445, DateTimeKind.Local).AddTicks(9195), new DateTime(2022, 12, 30, 23, 25, 54, 445, DateTimeKind.Local).AddTicks(9196), false, false, null, null });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PoolAccount");

            migrationBuilder.DropTable(
                name: "PoolTransactions");

            migrationBuilder.DropColumn(
                name: "TransactionRef",
                table: "Commisions");

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 29, 10, 7, 22, 643, DateTimeKind.Local).AddTicks(1669), new DateTime(2022, 12, 29, 10, 7, 22, 643, DateTimeKind.Local).AddTicks(1670) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 29, 10, 7, 22, 643, DateTimeKind.Local).AddTicks(1682), new DateTime(2022, 12, 29, 10, 7, 22, 643, DateTimeKind.Local).AddTicks(1683) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 29, 10, 7, 22, 643, DateTimeKind.Local).AddTicks(1692), new DateTime(2022, 12, 29, 10, 7, 22, 643, DateTimeKind.Local).AddTicks(1692) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 29, 10, 7, 22, 643, DateTimeKind.Local).AddTicks(1701), new DateTime(2022, 12, 29, 10, 7, 22, 643, DateTimeKind.Local).AddTicks(1702) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 29, 10, 7, 22, 643, DateTimeKind.Local).AddTicks(1710), new DateTime(2022, 12, 29, 10, 7, 22, 643, DateTimeKind.Local).AddTicks(1711) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 29, 10, 7, 22, 643, DateTimeKind.Local).AddTicks(1722), new DateTime(2022, 12, 29, 10, 7, 22, 643, DateTimeKind.Local).AddTicks(1722) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 29, 10, 7, 22, 643, DateTimeKind.Local).AddTicks(1731), new DateTime(2022, 12, 29, 10, 7, 22, 643, DateTimeKind.Local).AddTicks(1731) });

            migrationBuilder.UpdateData(
                table: "Plan",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 29, 10, 7, 22, 643, DateTimeKind.Local).AddTicks(1440), new DateTime(2022, 12, 29, 10, 7, 22, 643, DateTimeKind.Local).AddTicks(1453) });

            migrationBuilder.UpdateData(
                table: "Plan",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 29, 10, 7, 22, 643, DateTimeKind.Local).AddTicks(1483), new DateTime(2022, 12, 29, 10, 7, 22, 643, DateTimeKind.Local).AddTicks(1483) });

            migrationBuilder.UpdateData(
                table: "Plan",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 29, 10, 7, 22, 643, DateTimeKind.Local).AddTicks(1494), new DateTime(2022, 12, 29, 10, 7, 22, 643, DateTimeKind.Local).AddTicks(1494) });

            migrationBuilder.UpdateData(
                table: "SubPlan",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 29, 10, 7, 22, 643, DateTimeKind.Local).AddTicks(1556), new DateTime(2022, 12, 29, 10, 7, 22, 643, DateTimeKind.Local).AddTicks(1556) });

            migrationBuilder.UpdateData(
                table: "SubPlan",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 29, 10, 7, 22, 643, DateTimeKind.Local).AddTicks(1573), new DateTime(2022, 12, 29, 10, 7, 22, 643, DateTimeKind.Local).AddTicks(1573) });

            migrationBuilder.UpdateData(
                table: "SubPlan",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 29, 10, 7, 22, 643, DateTimeKind.Local).AddTicks(1583), new DateTime(2022, 12, 29, 10, 7, 22, 643, DateTimeKind.Local).AddTicks(1583) });

            migrationBuilder.UpdateData(
                table: "SubPlan",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 29, 10, 7, 22, 643, DateTimeKind.Local).AddTicks(1592), new DateTime(2022, 12, 29, 10, 7, 22, 643, DateTimeKind.Local).AddTicks(1592) });

            migrationBuilder.UpdateData(
                table: "SubPlan",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 29, 10, 7, 22, 643, DateTimeKind.Local).AddTicks(1602), new DateTime(2022, 12, 29, 10, 7, 22, 643, DateTimeKind.Local).AddTicks(1602) });

            migrationBuilder.UpdateData(
                table: "SubPlan",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 29, 10, 7, 22, 643, DateTimeKind.Local).AddTicks(1613), new DateTime(2022, 12, 29, 10, 7, 22, 643, DateTimeKind.Local).AddTicks(1613) });

            migrationBuilder.UpdateData(
                table: "SubPlan",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 29, 10, 7, 22, 643, DateTimeKind.Local).AddTicks(1623), new DateTime(2022, 12, 29, 10, 7, 22, 643, DateTimeKind.Local).AddTicks(1623) });

            migrationBuilder.UpdateData(
                table: "SubPlan",
                keyColumn: "Id",
                keyValue: 8L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 29, 10, 7, 22, 643, DateTimeKind.Local).AddTicks(1632), new DateTime(2022, 12, 29, 10, 7, 22, 643, DateTimeKind.Local).AddTicks(1633) });

            migrationBuilder.UpdateData(
                table: "SubPlan",
                keyColumn: "Id",
                keyValue: 9L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 29, 10, 7, 22, 643, DateTimeKind.Local).AddTicks(1642), new DateTime(2022, 12, 29, 10, 7, 22, 643, DateTimeKind.Local).AddTicks(1643) });
        }
    }
}
