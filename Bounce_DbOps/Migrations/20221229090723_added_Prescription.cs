using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bounce_DbOps.Migrations
{
    public partial class added_Prescription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Mood",
                table: "UserProfile");

            migrationBuilder.AddColumn<int>(
                name: "Rate",
                table: "Wallets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Commisions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    Decription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TherapistId = table.Column<long>(type: "bigint", nullable: false),
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
                    table.PrimaryKey("PK_Commisions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Commisions_AspNetUsers_TherapistId",
                        column: x => x.TherapistId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Prescriptions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppointmentRequestId = table.Column<long>(type: "bigint", nullable: false),
                    Drug = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dosage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrescriptionText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    File = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_Prescriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Prescriptions_AppointmentRequest_AppointmentRequestId",
                        column: x => x.AppointmentRequestId,
                        principalTable: "AppointmentRequest",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Commisions_TherapistId",
                table: "Commisions",
                column: "TherapistId");

            migrationBuilder.CreateIndex(
                name: "IX_Prescriptions_AppointmentRequestId",
                table: "Prescriptions",
                column: "AppointmentRequestId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Commisions");

            migrationBuilder.DropTable(
                name: "Prescriptions");

            migrationBuilder.DropColumn(
                name: "Rate",
                table: "Wallets");

            migrationBuilder.AddColumn<string>(
                name: "Mood",
                table: "UserProfile",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 26, 5, 34, 46, 442, DateTimeKind.Local).AddTicks(6874), new DateTime(2022, 12, 26, 5, 34, 46, 442, DateTimeKind.Local).AddTicks(6875) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 26, 5, 34, 46, 442, DateTimeKind.Local).AddTicks(6884), new DateTime(2022, 12, 26, 5, 34, 46, 442, DateTimeKind.Local).AddTicks(6884) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 26, 5, 34, 46, 442, DateTimeKind.Local).AddTicks(6892), new DateTime(2022, 12, 26, 5, 34, 46, 442, DateTimeKind.Local).AddTicks(6892) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 26, 5, 34, 46, 442, DateTimeKind.Local).AddTicks(6899), new DateTime(2022, 12, 26, 5, 34, 46, 442, DateTimeKind.Local).AddTicks(6899) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 26, 5, 34, 46, 442, DateTimeKind.Local).AddTicks(6906), new DateTime(2022, 12, 26, 5, 34, 46, 442, DateTimeKind.Local).AddTicks(6906) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 26, 5, 34, 46, 442, DateTimeKind.Local).AddTicks(6914), new DateTime(2022, 12, 26, 5, 34, 46, 442, DateTimeKind.Local).AddTicks(6914) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 26, 5, 34, 46, 442, DateTimeKind.Local).AddTicks(6921), new DateTime(2022, 12, 26, 5, 34, 46, 442, DateTimeKind.Local).AddTicks(6922) });

            migrationBuilder.UpdateData(
                table: "Plan",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 26, 5, 34, 46, 442, DateTimeKind.Local).AddTicks(6704), new DateTime(2022, 12, 26, 5, 34, 46, 442, DateTimeKind.Local).AddTicks(6718) });

            migrationBuilder.UpdateData(
                table: "Plan",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 26, 5, 34, 46, 442, DateTimeKind.Local).AddTicks(6739), new DateTime(2022, 12, 26, 5, 34, 46, 442, DateTimeKind.Local).AddTicks(6740) });

            migrationBuilder.UpdateData(
                table: "Plan",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 26, 5, 34, 46, 442, DateTimeKind.Local).AddTicks(6757), new DateTime(2022, 12, 26, 5, 34, 46, 442, DateTimeKind.Local).AddTicks(6758) });

            migrationBuilder.UpdateData(
                table: "SubPlan",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 26, 5, 34, 46, 442, DateTimeKind.Local).AddTicks(6795), new DateTime(2022, 12, 26, 5, 34, 46, 442, DateTimeKind.Local).AddTicks(6796) });

            migrationBuilder.UpdateData(
                table: "SubPlan",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 26, 5, 34, 46, 442, DateTimeKind.Local).AddTicks(6808), new DateTime(2022, 12, 26, 5, 34, 46, 442, DateTimeKind.Local).AddTicks(6809) });

            migrationBuilder.UpdateData(
                table: "SubPlan",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 26, 5, 34, 46, 442, DateTimeKind.Local).AddTicks(6816), new DateTime(2022, 12, 26, 5, 34, 46, 442, DateTimeKind.Local).AddTicks(6817) });

            migrationBuilder.UpdateData(
                table: "SubPlan",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 26, 5, 34, 46, 442, DateTimeKind.Local).AddTicks(6823), new DateTime(2022, 12, 26, 5, 34, 46, 442, DateTimeKind.Local).AddTicks(6824) });

            migrationBuilder.UpdateData(
                table: "SubPlan",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 26, 5, 34, 46, 442, DateTimeKind.Local).AddTicks(6830), new DateTime(2022, 12, 26, 5, 34, 46, 442, DateTimeKind.Local).AddTicks(6831) });

            migrationBuilder.UpdateData(
                table: "SubPlan",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 26, 5, 34, 46, 442, DateTimeKind.Local).AddTicks(6838), new DateTime(2022, 12, 26, 5, 34, 46, 442, DateTimeKind.Local).AddTicks(6839) });

            migrationBuilder.UpdateData(
                table: "SubPlan",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 26, 5, 34, 46, 442, DateTimeKind.Local).AddTicks(6846), new DateTime(2022, 12, 26, 5, 34, 46, 442, DateTimeKind.Local).AddTicks(6846) });

            migrationBuilder.UpdateData(
                table: "SubPlan",
                keyColumn: "Id",
                keyValue: 8L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 26, 5, 34, 46, 442, DateTimeKind.Local).AddTicks(6853), new DateTime(2022, 12, 26, 5, 34, 46, 442, DateTimeKind.Local).AddTicks(6853) });

            migrationBuilder.UpdateData(
                table: "SubPlan",
                keyColumn: "Id",
                keyValue: 9L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 26, 5, 34, 46, 442, DateTimeKind.Local).AddTicks(6860), new DateTime(2022, 12, 26, 5, 34, 46, 442, DateTimeKind.Local).AddTicks(6860) });
        }
    }
}
