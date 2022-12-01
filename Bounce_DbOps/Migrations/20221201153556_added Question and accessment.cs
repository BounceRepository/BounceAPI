using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bounce_DbOps.Migrations
{
    public partial class addedQuestionandaccessment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TherapistAccesmentQuestions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Question = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OptionA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OptionB = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OptionC = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OptionD = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CorrectAnswer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedById = table.Column<long>(type: "bigint", nullable: false),
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
                    table.PrimaryKey("PK_TherapistAccesmentQuestions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TherapistAccesmentQuestions_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TherapistAccessments",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TherapistId = table.Column<long>(type: "bigint", nullable: false),
                    TotalPassed = table.Column<int>(type: "int", nullable: false),
                    TotalFailed = table.Column<int>(type: "int", nullable: false),
                    TotalScore = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_TherapistAccessments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TherapistAccessments_AspNetUsers_TherapistId",
                        column: x => x.TherapistId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 1, 16, 35, 56, 480, DateTimeKind.Local).AddTicks(6388), new DateTime(2022, 12, 1, 16, 35, 56, 480, DateTimeKind.Local).AddTicks(6388) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 1, 16, 35, 56, 480, DateTimeKind.Local).AddTicks(6399), new DateTime(2022, 12, 1, 16, 35, 56, 480, DateTimeKind.Local).AddTicks(6400) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 1, 16, 35, 56, 480, DateTimeKind.Local).AddTicks(6408), new DateTime(2022, 12, 1, 16, 35, 56, 480, DateTimeKind.Local).AddTicks(6408) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 1, 16, 35, 56, 480, DateTimeKind.Local).AddTicks(6415), new DateTime(2022, 12, 1, 16, 35, 56, 480, DateTimeKind.Local).AddTicks(6415) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 1, 16, 35, 56, 480, DateTimeKind.Local).AddTicks(6422), new DateTime(2022, 12, 1, 16, 35, 56, 480, DateTimeKind.Local).AddTicks(6423) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 1, 16, 35, 56, 480, DateTimeKind.Local).AddTicks(6435), new DateTime(2022, 12, 1, 16, 35, 56, 480, DateTimeKind.Local).AddTicks(6435) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 1, 16, 35, 56, 480, DateTimeKind.Local).AddTicks(6443), new DateTime(2022, 12, 1, 16, 35, 56, 480, DateTimeKind.Local).AddTicks(6443) });

            migrationBuilder.UpdateData(
                table: "Plan",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 1, 16, 35, 56, 480, DateTimeKind.Local).AddTicks(6318), new DateTime(2022, 12, 1, 16, 35, 56, 480, DateTimeKind.Local).AddTicks(6329) });

            migrationBuilder.UpdateData(
                table: "Plan",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 1, 16, 35, 56, 480, DateTimeKind.Local).AddTicks(6354), new DateTime(2022, 12, 1, 16, 35, 56, 480, DateTimeKind.Local).AddTicks(6354) });

            migrationBuilder.UpdateData(
                table: "Plan",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 1, 16, 35, 56, 480, DateTimeKind.Local).AddTicks(6363), new DateTime(2022, 12, 1, 16, 35, 56, 480, DateTimeKind.Local).AddTicks(6363) });

            migrationBuilder.CreateIndex(
                name: "IX_TherapistAccesmentQuestions_CreatedById",
                table: "TherapistAccesmentQuestions",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_TherapistAccessments_TherapistId",
                table: "TherapistAccessments",
                column: "TherapistId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TherapistAccesmentQuestions");

            migrationBuilder.DropTable(
                name: "TherapistAccessments");

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 11, 30, 17, 23, 31, 873, DateTimeKind.Local).AddTicks(8912), new DateTime(2022, 11, 30, 17, 23, 31, 873, DateTimeKind.Local).AddTicks(8913) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 11, 30, 17, 23, 31, 873, DateTimeKind.Local).AddTicks(8923), new DateTime(2022, 11, 30, 17, 23, 31, 873, DateTimeKind.Local).AddTicks(8924) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 11, 30, 17, 23, 31, 873, DateTimeKind.Local).AddTicks(8931), new DateTime(2022, 11, 30, 17, 23, 31, 873, DateTimeKind.Local).AddTicks(8931) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 11, 30, 17, 23, 31, 873, DateTimeKind.Local).AddTicks(8938), new DateTime(2022, 11, 30, 17, 23, 31, 873, DateTimeKind.Local).AddTicks(8939) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 11, 30, 17, 23, 31, 873, DateTimeKind.Local).AddTicks(8946), new DateTime(2022, 11, 30, 17, 23, 31, 873, DateTimeKind.Local).AddTicks(8946) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 11, 30, 17, 23, 31, 873, DateTimeKind.Local).AddTicks(8956), new DateTime(2022, 11, 30, 17, 23, 31, 873, DateTimeKind.Local).AddTicks(8956) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 11, 30, 17, 23, 31, 873, DateTimeKind.Local).AddTicks(8963), new DateTime(2022, 11, 30, 17, 23, 31, 873, DateTimeKind.Local).AddTicks(8964) });

            migrationBuilder.UpdateData(
                table: "Plan",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 11, 30, 17, 23, 31, 873, DateTimeKind.Local).AddTicks(8854), new DateTime(2022, 11, 30, 17, 23, 31, 873, DateTimeKind.Local).AddTicks(8864) });

            migrationBuilder.UpdateData(
                table: "Plan",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 11, 30, 17, 23, 31, 873, DateTimeKind.Local).AddTicks(8888), new DateTime(2022, 11, 30, 17, 23, 31, 873, DateTimeKind.Local).AddTicks(8888) });

            migrationBuilder.UpdateData(
                table: "Plan",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 11, 30, 17, 23, 31, 873, DateTimeKind.Local).AddTicks(8897), new DateTime(2022, 11, 30, 17, 23, 31, 873, DateTimeKind.Local).AddTicks(8897) });
        }
    }
}
