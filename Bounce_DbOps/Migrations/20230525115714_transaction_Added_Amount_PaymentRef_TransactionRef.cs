using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bounce_DbOps.Migrations
{
    public partial class transaction_Added_Amount_PaymentRef_TransactionRef : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Amount",
                table: "Transactions",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "TransactionRef",
                table: "Transactions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2023, 5, 25, 12, 57, 13, 389, DateTimeKind.Local).AddTicks(5267), new DateTime(2023, 5, 25, 12, 57, 13, 389, DateTimeKind.Local).AddTicks(5268) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2023, 5, 25, 12, 57, 13, 389, DateTimeKind.Local).AddTicks(5294), new DateTime(2023, 5, 25, 12, 57, 13, 389, DateTimeKind.Local).AddTicks(5295) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2023, 5, 25, 12, 57, 13, 389, DateTimeKind.Local).AddTicks(5313), new DateTime(2023, 5, 25, 12, 57, 13, 389, DateTimeKind.Local).AddTicks(5314) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2023, 5, 25, 12, 57, 13, 389, DateTimeKind.Local).AddTicks(5337), new DateTime(2023, 5, 25, 12, 57, 13, 389, DateTimeKind.Local).AddTicks(5338) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2023, 5, 25, 12, 57, 13, 389, DateTimeKind.Local).AddTicks(5362), new DateTime(2023, 5, 25, 12, 57, 13, 389, DateTimeKind.Local).AddTicks(5362) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2023, 5, 25, 12, 57, 13, 389, DateTimeKind.Local).AddTicks(5382), new DateTime(2023, 5, 25, 12, 57, 13, 389, DateTimeKind.Local).AddTicks(5383) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2023, 5, 25, 12, 57, 13, 389, DateTimeKind.Local).AddTicks(5399), new DateTime(2023, 5, 25, 12, 57, 13, 389, DateTimeKind.Local).AddTicks(5400) });

            migrationBuilder.UpdateData(
                table: "Plan",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2023, 5, 25, 12, 57, 13, 389, DateTimeKind.Local).AddTicks(4792), new DateTime(2023, 5, 25, 12, 57, 13, 389, DateTimeKind.Local).AddTicks(4807) });

            migrationBuilder.UpdateData(
                table: "Plan",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2023, 5, 25, 12, 57, 13, 389, DateTimeKind.Local).AddTicks(4872), new DateTime(2023, 5, 25, 12, 57, 13, 389, DateTimeKind.Local).AddTicks(4873) });

            migrationBuilder.UpdateData(
                table: "Plan",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2023, 5, 25, 12, 57, 13, 389, DateTimeKind.Local).AddTicks(4918), new DateTime(2023, 5, 25, 12, 57, 13, 389, DateTimeKind.Local).AddTicks(4919) });

            migrationBuilder.UpdateData(
                table: "PoolAccount",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2023, 5, 25, 12, 57, 13, 389, DateTimeKind.Local).AddTicks(5422), new DateTime(2023, 5, 25, 12, 57, 13, 389, DateTimeKind.Local).AddTicks(5423) });

            migrationBuilder.UpdateData(
                table: "SubPlan",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2023, 5, 25, 12, 57, 13, 389, DateTimeKind.Local).AddTicks(4993), new DateTime(2023, 5, 25, 12, 57, 13, 389, DateTimeKind.Local).AddTicks(4994) });

            migrationBuilder.UpdateData(
                table: "SubPlan",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2023, 5, 25, 12, 57, 13, 389, DateTimeKind.Local).AddTicks(5021), new DateTime(2023, 5, 25, 12, 57, 13, 389, DateTimeKind.Local).AddTicks(5022) });

            migrationBuilder.UpdateData(
                table: "SubPlan",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2023, 5, 25, 12, 57, 13, 389, DateTimeKind.Local).AddTicks(5077), new DateTime(2023, 5, 25, 12, 57, 13, 389, DateTimeKind.Local).AddTicks(5089) });

            migrationBuilder.UpdateData(
                table: "SubPlan",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2023, 5, 25, 12, 57, 13, 389, DateTimeKind.Local).AddTicks(5143), new DateTime(2023, 5, 25, 12, 57, 13, 389, DateTimeKind.Local).AddTicks(5145) });

            migrationBuilder.UpdateData(
                table: "SubPlan",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2023, 5, 25, 12, 57, 13, 389, DateTimeKind.Local).AddTicks(5162), new DateTime(2023, 5, 25, 12, 57, 13, 389, DateTimeKind.Local).AddTicks(5163) });

            migrationBuilder.UpdateData(
                table: "SubPlan",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2023, 5, 25, 12, 57, 13, 389, DateTimeKind.Local).AddTicks(5183), new DateTime(2023, 5, 25, 12, 57, 13, 389, DateTimeKind.Local).AddTicks(5184) });

            migrationBuilder.UpdateData(
                table: "SubPlan",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2023, 5, 25, 12, 57, 13, 389, DateTimeKind.Local).AddTicks(5199), new DateTime(2023, 5, 25, 12, 57, 13, 389, DateTimeKind.Local).AddTicks(5201) });

            migrationBuilder.UpdateData(
                table: "SubPlan",
                keyColumn: "Id",
                keyValue: 8L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2023, 5, 25, 12, 57, 13, 389, DateTimeKind.Local).AddTicks(5216), new DateTime(2023, 5, 25, 12, 57, 13, 389, DateTimeKind.Local).AddTicks(5217) });

            migrationBuilder.UpdateData(
                table: "SubPlan",
                keyColumn: "Id",
                keyValue: 9L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2023, 5, 25, 12, 57, 13, 389, DateTimeKind.Local).AddTicks(5233), new DateTime(2023, 5, 25, 12, 57, 13, 389, DateTimeKind.Local).AddTicks(5234) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "TransactionRef",
                table: "Transactions");

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
    }
}
