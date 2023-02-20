using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bounce_DbOps.Migrations
{
    public partial class modified_ChatModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "AppointmentRequestId",
                table: "Chats",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Dosage",
                table: "Chats",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Drug",
                table: "Chats",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PrescriptionText",
                table: "Chats",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2023, 2, 7, 8, 20, 43, 855, DateTimeKind.Local).AddTicks(4929), new DateTime(2023, 2, 7, 8, 20, 43, 855, DateTimeKind.Local).AddTicks(4929) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2023, 2, 7, 8, 20, 43, 855, DateTimeKind.Local).AddTicks(4952), new DateTime(2023, 2, 7, 8, 20, 43, 855, DateTimeKind.Local).AddTicks(4953) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2023, 2, 7, 8, 20, 43, 855, DateTimeKind.Local).AddTicks(4960), new DateTime(2023, 2, 7, 8, 20, 43, 855, DateTimeKind.Local).AddTicks(4961) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2023, 2, 7, 8, 20, 43, 855, DateTimeKind.Local).AddTicks(4968), new DateTime(2023, 2, 7, 8, 20, 43, 855, DateTimeKind.Local).AddTicks(4968) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2023, 2, 7, 8, 20, 43, 855, DateTimeKind.Local).AddTicks(4975), new DateTime(2023, 2, 7, 8, 20, 43, 855, DateTimeKind.Local).AddTicks(4975) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2023, 2, 7, 8, 20, 43, 855, DateTimeKind.Local).AddTicks(4983), new DateTime(2023, 2, 7, 8, 20, 43, 855, DateTimeKind.Local).AddTicks(4983) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2023, 2, 7, 8, 20, 43, 855, DateTimeKind.Local).AddTicks(4990), new DateTime(2023, 2, 7, 8, 20, 43, 855, DateTimeKind.Local).AddTicks(4990) });

            migrationBuilder.UpdateData(
                table: "Plan",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2023, 2, 7, 8, 20, 43, 855, DateTimeKind.Local).AddTicks(4749), new DateTime(2023, 2, 7, 8, 20, 43, 855, DateTimeKind.Local).AddTicks(4761) });

            migrationBuilder.UpdateData(
                table: "Plan",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2023, 2, 7, 8, 20, 43, 855, DateTimeKind.Local).AddTicks(4788), new DateTime(2023, 2, 7, 8, 20, 43, 855, DateTimeKind.Local).AddTicks(4788) });

            migrationBuilder.UpdateData(
                table: "Plan",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2023, 2, 7, 8, 20, 43, 855, DateTimeKind.Local).AddTicks(4798), new DateTime(2023, 2, 7, 8, 20, 43, 855, DateTimeKind.Local).AddTicks(4799) });

            migrationBuilder.UpdateData(
                table: "PoolAccount",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2023, 2, 7, 8, 20, 43, 855, DateTimeKind.Local).AddTicks(5004), new DateTime(2023, 2, 7, 8, 20, 43, 855, DateTimeKind.Local).AddTicks(5004) });

            migrationBuilder.UpdateData(
                table: "SubPlan",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2023, 2, 7, 8, 20, 43, 855, DateTimeKind.Local).AddTicks(4840), new DateTime(2023, 2, 7, 8, 20, 43, 855, DateTimeKind.Local).AddTicks(4840) });

            migrationBuilder.UpdateData(
                table: "SubPlan",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2023, 2, 7, 8, 20, 43, 855, DateTimeKind.Local).AddTicks(4856), new DateTime(2023, 2, 7, 8, 20, 43, 855, DateTimeKind.Local).AddTicks(4856) });

            migrationBuilder.UpdateData(
                table: "SubPlan",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2023, 2, 7, 8, 20, 43, 855, DateTimeKind.Local).AddTicks(4864), new DateTime(2023, 2, 7, 8, 20, 43, 855, DateTimeKind.Local).AddTicks(4864) });

            migrationBuilder.UpdateData(
                table: "SubPlan",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2023, 2, 7, 8, 20, 43, 855, DateTimeKind.Local).AddTicks(4872), new DateTime(2023, 2, 7, 8, 20, 43, 855, DateTimeKind.Local).AddTicks(4872) });

            migrationBuilder.UpdateData(
                table: "SubPlan",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2023, 2, 7, 8, 20, 43, 855, DateTimeKind.Local).AddTicks(4880), new DateTime(2023, 2, 7, 8, 20, 43, 855, DateTimeKind.Local).AddTicks(4880) });

            migrationBuilder.UpdateData(
                table: "SubPlan",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2023, 2, 7, 8, 20, 43, 855, DateTimeKind.Local).AddTicks(4888), new DateTime(2023, 2, 7, 8, 20, 43, 855, DateTimeKind.Local).AddTicks(4889) });

            migrationBuilder.UpdateData(
                table: "SubPlan",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2023, 2, 7, 8, 20, 43, 855, DateTimeKind.Local).AddTicks(4896), new DateTime(2023, 2, 7, 8, 20, 43, 855, DateTimeKind.Local).AddTicks(4896) });

            migrationBuilder.UpdateData(
                table: "SubPlan",
                keyColumn: "Id",
                keyValue: 8L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2023, 2, 7, 8, 20, 43, 855, DateTimeKind.Local).AddTicks(4903), new DateTime(2023, 2, 7, 8, 20, 43, 855, DateTimeKind.Local).AddTicks(4904) });

            migrationBuilder.UpdateData(
                table: "SubPlan",
                keyColumn: "Id",
                keyValue: 9L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2023, 2, 7, 8, 20, 43, 855, DateTimeKind.Local).AddTicks(4911), new DateTime(2023, 2, 7, 8, 20, 43, 855, DateTimeKind.Local).AddTicks(4911) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AppointmentRequestId",
                table: "Chats");

            migrationBuilder.DropColumn(
                name: "Dosage",
                table: "Chats");

            migrationBuilder.DropColumn(
                name: "Drug",
                table: "Chats");

            migrationBuilder.DropColumn(
                name: "PrescriptionText",
                table: "Chats");

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
        }
    }
}
