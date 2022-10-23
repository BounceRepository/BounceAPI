using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bounce_DbOps.Migrations
{
    public partial class WalletTopUp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WalletRequests",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    Refxn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsCompleted = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descrription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RequestType = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WalletRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WalletRequests_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Plan",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 10, 23, 21, 26, 28, 562, DateTimeKind.Local).AddTicks(4880), new DateTime(2022, 10, 23, 21, 26, 28, 562, DateTimeKind.Local).AddTicks(4891) });

            migrationBuilder.UpdateData(
                table: "Plan",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 10, 23, 21, 26, 28, 562, DateTimeKind.Local).AddTicks(4927), new DateTime(2022, 10, 23, 21, 26, 28, 562, DateTimeKind.Local).AddTicks(4928) });

            migrationBuilder.UpdateData(
                table: "Plan",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 10, 23, 21, 26, 28, 562, DateTimeKind.Local).AddTicks(4942), new DateTime(2022, 10, 23, 21, 26, 28, 562, DateTimeKind.Local).AddTicks(4942) });

            migrationBuilder.CreateIndex(
                name: "IX_WalletRequests_UserId",
                table: "WalletRequests",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WalletRequests");

            migrationBuilder.UpdateData(
                table: "Plan",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 10, 23, 20, 11, 23, 231, DateTimeKind.Local).AddTicks(1381), new DateTime(2022, 10, 23, 20, 11, 23, 231, DateTimeKind.Local).AddTicks(1390) });

            migrationBuilder.UpdateData(
                table: "Plan",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 10, 23, 20, 11, 23, 231, DateTimeKind.Local).AddTicks(1416), new DateTime(2022, 10, 23, 20, 11, 23, 231, DateTimeKind.Local).AddTicks(1417) });

            migrationBuilder.UpdateData(
                table: "Plan",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 10, 23, 20, 11, 23, 231, DateTimeKind.Local).AddTicks(1424), new DateTime(2022, 10, 23, 20, 11, 23, 231, DateTimeKind.Local).AddTicks(1425) });
        }
    }
}
