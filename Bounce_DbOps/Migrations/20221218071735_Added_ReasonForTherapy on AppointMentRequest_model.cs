using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bounce_DbOps.Migrations
{
    public partial class Added_ReasonForTherapyonAppointMentRequest_model : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ReasonForTherapy",
                table: "AppointmentRequest",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 18, 8, 17, 35, 196, DateTimeKind.Local).AddTicks(9062), new DateTime(2022, 12, 18, 8, 17, 35, 196, DateTimeKind.Local).AddTicks(9062) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 18, 8, 17, 35, 196, DateTimeKind.Local).AddTicks(9072), new DateTime(2022, 12, 18, 8, 17, 35, 196, DateTimeKind.Local).AddTicks(9072) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 18, 8, 17, 35, 196, DateTimeKind.Local).AddTicks(9079), new DateTime(2022, 12, 18, 8, 17, 35, 196, DateTimeKind.Local).AddTicks(9079) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 18, 8, 17, 35, 196, DateTimeKind.Local).AddTicks(9086), new DateTime(2022, 12, 18, 8, 17, 35, 196, DateTimeKind.Local).AddTicks(9086) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 18, 8, 17, 35, 196, DateTimeKind.Local).AddTicks(9092), new DateTime(2022, 12, 18, 8, 17, 35, 196, DateTimeKind.Local).AddTicks(9093) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 18, 8, 17, 35, 196, DateTimeKind.Local).AddTicks(9100), new DateTime(2022, 12, 18, 8, 17, 35, 196, DateTimeKind.Local).AddTicks(9100) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 18, 8, 17, 35, 196, DateTimeKind.Local).AddTicks(9107), new DateTime(2022, 12, 18, 8, 17, 35, 196, DateTimeKind.Local).AddTicks(9107) });

            migrationBuilder.UpdateData(
                table: "Plan",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 18, 8, 17, 35, 196, DateTimeKind.Local).AddTicks(8891), new DateTime(2022, 12, 18, 8, 17, 35, 196, DateTimeKind.Local).AddTicks(8901) });

            migrationBuilder.UpdateData(
                table: "Plan",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 18, 8, 17, 35, 196, DateTimeKind.Local).AddTicks(8924), new DateTime(2022, 12, 18, 8, 17, 35, 196, DateTimeKind.Local).AddTicks(8925) });

            migrationBuilder.UpdateData(
                table: "Plan",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 18, 8, 17, 35, 196, DateTimeKind.Local).AddTicks(8932), new DateTime(2022, 12, 18, 8, 17, 35, 196, DateTimeKind.Local).AddTicks(8932) });

            migrationBuilder.UpdateData(
                table: "SubPlan",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 18, 8, 17, 35, 196, DateTimeKind.Local).AddTicks(8982), new DateTime(2022, 12, 18, 8, 17, 35, 196, DateTimeKind.Local).AddTicks(8983) });

            migrationBuilder.UpdateData(
                table: "SubPlan",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 18, 8, 17, 35, 196, DateTimeKind.Local).AddTicks(8994), new DateTime(2022, 12, 18, 8, 17, 35, 196, DateTimeKind.Local).AddTicks(8995) });

            migrationBuilder.UpdateData(
                table: "SubPlan",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 18, 8, 17, 35, 196, DateTimeKind.Local).AddTicks(9003), new DateTime(2022, 12, 18, 8, 17, 35, 196, DateTimeKind.Local).AddTicks(9003) });

            migrationBuilder.UpdateData(
                table: "SubPlan",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 18, 8, 17, 35, 196, DateTimeKind.Local).AddTicks(9010), new DateTime(2022, 12, 18, 8, 17, 35, 196, DateTimeKind.Local).AddTicks(9011) });

            migrationBuilder.UpdateData(
                table: "SubPlan",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 18, 8, 17, 35, 196, DateTimeKind.Local).AddTicks(9018), new DateTime(2022, 12, 18, 8, 17, 35, 196, DateTimeKind.Local).AddTicks(9018) });

            migrationBuilder.UpdateData(
                table: "SubPlan",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 18, 8, 17, 35, 196, DateTimeKind.Local).AddTicks(9026), new DateTime(2022, 12, 18, 8, 17, 35, 196, DateTimeKind.Local).AddTicks(9026) });

            migrationBuilder.UpdateData(
                table: "SubPlan",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 18, 8, 17, 35, 196, DateTimeKind.Local).AddTicks(9033), new DateTime(2022, 12, 18, 8, 17, 35, 196, DateTimeKind.Local).AddTicks(9033) });

            migrationBuilder.UpdateData(
                table: "SubPlan",
                keyColumn: "Id",
                keyValue: 8L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 18, 8, 17, 35, 196, DateTimeKind.Local).AddTicks(9040), new DateTime(2022, 12, 18, 8, 17, 35, 196, DateTimeKind.Local).AddTicks(9040) });

            migrationBuilder.UpdateData(
                table: "SubPlan",
                keyColumn: "Id",
                keyValue: 9L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 18, 8, 17, 35, 196, DateTimeKind.Local).AddTicks(9047), new DateTime(2022, 12, 18, 8, 17, 35, 196, DateTimeKind.Local).AddTicks(9048) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReasonForTherapy",
                table: "AppointmentRequest");

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 15, 18, 17, 44, 394, DateTimeKind.Local).AddTicks(9521), new DateTime(2022, 12, 15, 18, 17, 44, 394, DateTimeKind.Local).AddTicks(9521) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 15, 18, 17, 44, 394, DateTimeKind.Local).AddTicks(9530), new DateTime(2022, 12, 15, 18, 17, 44, 394, DateTimeKind.Local).AddTicks(9530) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 15, 18, 17, 44, 394, DateTimeKind.Local).AddTicks(9538), new DateTime(2022, 12, 15, 18, 17, 44, 394, DateTimeKind.Local).AddTicks(9538) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 15, 18, 17, 44, 394, DateTimeKind.Local).AddTicks(9545), new DateTime(2022, 12, 15, 18, 17, 44, 394, DateTimeKind.Local).AddTicks(9545) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 15, 18, 17, 44, 394, DateTimeKind.Local).AddTicks(9552), new DateTime(2022, 12, 15, 18, 17, 44, 394, DateTimeKind.Local).AddTicks(9552) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 15, 18, 17, 44, 394, DateTimeKind.Local).AddTicks(9560), new DateTime(2022, 12, 15, 18, 17, 44, 394, DateTimeKind.Local).AddTicks(9560) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 15, 18, 17, 44, 394, DateTimeKind.Local).AddTicks(9567), new DateTime(2022, 12, 15, 18, 17, 44, 394, DateTimeKind.Local).AddTicks(9568) });

            migrationBuilder.UpdateData(
                table: "Plan",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 15, 18, 17, 44, 394, DateTimeKind.Local).AddTicks(9348), new DateTime(2022, 12, 15, 18, 17, 44, 394, DateTimeKind.Local).AddTicks(9357) });

            migrationBuilder.UpdateData(
                table: "Plan",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 15, 18, 17, 44, 394, DateTimeKind.Local).AddTicks(9379), new DateTime(2022, 12, 15, 18, 17, 44, 394, DateTimeKind.Local).AddTicks(9379) });

            migrationBuilder.UpdateData(
                table: "Plan",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 15, 18, 17, 44, 394, DateTimeKind.Local).AddTicks(9388), new DateTime(2022, 12, 15, 18, 17, 44, 394, DateTimeKind.Local).AddTicks(9388) });

            migrationBuilder.UpdateData(
                table: "SubPlan",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 15, 18, 17, 44, 394, DateTimeKind.Local).AddTicks(9437), new DateTime(2022, 12, 15, 18, 17, 44, 394, DateTimeKind.Local).AddTicks(9438) });

            migrationBuilder.UpdateData(
                table: "SubPlan",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 15, 18, 17, 44, 394, DateTimeKind.Local).AddTicks(9450), new DateTime(2022, 12, 15, 18, 17, 44, 394, DateTimeKind.Local).AddTicks(9450) });

            migrationBuilder.UpdateData(
                table: "SubPlan",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 15, 18, 17, 44, 394, DateTimeKind.Local).AddTicks(9459), new DateTime(2022, 12, 15, 18, 17, 44, 394, DateTimeKind.Local).AddTicks(9459) });

            migrationBuilder.UpdateData(
                table: "SubPlan",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 15, 18, 17, 44, 394, DateTimeKind.Local).AddTicks(9467), new DateTime(2022, 12, 15, 18, 17, 44, 394, DateTimeKind.Local).AddTicks(9467) });

            migrationBuilder.UpdateData(
                table: "SubPlan",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 15, 18, 17, 44, 394, DateTimeKind.Local).AddTicks(9474), new DateTime(2022, 12, 15, 18, 17, 44, 394, DateTimeKind.Local).AddTicks(9475) });

            migrationBuilder.UpdateData(
                table: "SubPlan",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 15, 18, 17, 44, 394, DateTimeKind.Local).AddTicks(9484), new DateTime(2022, 12, 15, 18, 17, 44, 394, DateTimeKind.Local).AddTicks(9484) });

            migrationBuilder.UpdateData(
                table: "SubPlan",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 15, 18, 17, 44, 394, DateTimeKind.Local).AddTicks(9491), new DateTime(2022, 12, 15, 18, 17, 44, 394, DateTimeKind.Local).AddTicks(9492) });

            migrationBuilder.UpdateData(
                table: "SubPlan",
                keyColumn: "Id",
                keyValue: 8L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 15, 18, 17, 44, 394, DateTimeKind.Local).AddTicks(9499), new DateTime(2022, 12, 15, 18, 17, 44, 394, DateTimeKind.Local).AddTicks(9500) });

            migrationBuilder.UpdateData(
                table: "SubPlan",
                keyColumn: "Id",
                keyValue: 9L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 15, 18, 17, 44, 394, DateTimeKind.Local).AddTicks(9507), new DateTime(2022, 12, 15, 18, 17, 44, 394, DateTimeKind.Local).AddTicks(9507) });
        }
    }
}
