using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bounce_DbOps.Migrations
{
    public partial class modifiedQuestiontable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AnsweredQuestionIds",
                table: "TherapistAccessments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "TotalQuestion",
                table: "TherapistAccessments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 2, 12, 43, 27, 102, DateTimeKind.Local).AddTicks(3850), new DateTime(2022, 12, 2, 12, 43, 27, 102, DateTimeKind.Local).AddTicks(3850) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 2, 12, 43, 27, 102, DateTimeKind.Local).AddTicks(3860), new DateTime(2022, 12, 2, 12, 43, 27, 102, DateTimeKind.Local).AddTicks(3861) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 2, 12, 43, 27, 102, DateTimeKind.Local).AddTicks(3868), new DateTime(2022, 12, 2, 12, 43, 27, 102, DateTimeKind.Local).AddTicks(3868) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 2, 12, 43, 27, 102, DateTimeKind.Local).AddTicks(3875), new DateTime(2022, 12, 2, 12, 43, 27, 102, DateTimeKind.Local).AddTicks(3875) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 2, 12, 43, 27, 102, DateTimeKind.Local).AddTicks(3882), new DateTime(2022, 12, 2, 12, 43, 27, 102, DateTimeKind.Local).AddTicks(3882) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 2, 12, 43, 27, 102, DateTimeKind.Local).AddTicks(3890), new DateTime(2022, 12, 2, 12, 43, 27, 102, DateTimeKind.Local).AddTicks(3890) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 2, 12, 43, 27, 102, DateTimeKind.Local).AddTicks(3897), new DateTime(2022, 12, 2, 12, 43, 27, 102, DateTimeKind.Local).AddTicks(3898) });

            migrationBuilder.UpdateData(
                table: "Plan",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 2, 12, 43, 27, 102, DateTimeKind.Local).AddTicks(3789), new DateTime(2022, 12, 2, 12, 43, 27, 102, DateTimeKind.Local).AddTicks(3799) });

            migrationBuilder.UpdateData(
                table: "Plan",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 2, 12, 43, 27, 102, DateTimeKind.Local).AddTicks(3823), new DateTime(2022, 12, 2, 12, 43, 27, 102, DateTimeKind.Local).AddTicks(3824) });

            migrationBuilder.UpdateData(
                table: "Plan",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 2, 12, 43, 27, 102, DateTimeKind.Local).AddTicks(3832), new DateTime(2022, 12, 2, 12, 43, 27, 102, DateTimeKind.Local).AddTicks(3832) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnsweredQuestionIds",
                table: "TherapistAccessments");

            migrationBuilder.DropColumn(
                name: "TotalQuestion",
                table: "TherapistAccessments");

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
        }
    }
}
