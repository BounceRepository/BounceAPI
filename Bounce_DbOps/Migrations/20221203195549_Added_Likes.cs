using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bounce_DbOps.Migrations
{
    public partial class Added_Likes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Like",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LikedByUserId = table.Column<long>(type: "bigint", nullable: true),
                    FeedId = table.Column<long>(type: "bigint", nullable: true),
                    CommentId = table.Column<long>(type: "bigint", nullable: true),
                    ReplyId = table.Column<long>(type: "bigint", nullable: true),
                    Liked = table.Column<bool>(type: "bit", nullable: false),
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
                    table.PrimaryKey("PK_Like", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Like_AspNetUsers_LikedByUserId",
                        column: x => x.LikedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Like_Comments_CommentId",
                        column: x => x.CommentId,
                        principalTable: "Comments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Like_Feeds_FeedId",
                        column: x => x.FeedId,
                        principalTable: "Feeds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Like_Replies_ReplyId",
                        column: x => x.ReplyId,
                        principalTable: "Replies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 3, 20, 55, 48, 839, DateTimeKind.Local).AddTicks(250), new DateTime(2022, 12, 3, 20, 55, 48, 839, DateTimeKind.Local).AddTicks(250) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 3, 20, 55, 48, 839, DateTimeKind.Local).AddTicks(264), new DateTime(2022, 12, 3, 20, 55, 48, 839, DateTimeKind.Local).AddTicks(264) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 3, 20, 55, 48, 839, DateTimeKind.Local).AddTicks(273), new DateTime(2022, 12, 3, 20, 55, 48, 839, DateTimeKind.Local).AddTicks(273) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 3, 20, 55, 48, 839, DateTimeKind.Local).AddTicks(282), new DateTime(2022, 12, 3, 20, 55, 48, 839, DateTimeKind.Local).AddTicks(282) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 3, 20, 55, 48, 839, DateTimeKind.Local).AddTicks(291), new DateTime(2022, 12, 3, 20, 55, 48, 839, DateTimeKind.Local).AddTicks(291) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 3, 20, 55, 48, 839, DateTimeKind.Local).AddTicks(301), new DateTime(2022, 12, 3, 20, 55, 48, 839, DateTimeKind.Local).AddTicks(302) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 3, 20, 55, 48, 839, DateTimeKind.Local).AddTicks(324), new DateTime(2022, 12, 3, 20, 55, 48, 839, DateTimeKind.Local).AddTicks(324) });

            migrationBuilder.UpdateData(
                table: "Plan",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 3, 20, 55, 48, 839, DateTimeKind.Local).AddTicks(183), new DateTime(2022, 12, 3, 20, 55, 48, 839, DateTimeKind.Local).AddTicks(193) });

            migrationBuilder.UpdateData(
                table: "Plan",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 3, 20, 55, 48, 839, DateTimeKind.Local).AddTicks(223), new DateTime(2022, 12, 3, 20, 55, 48, 839, DateTimeKind.Local).AddTicks(223) });

            migrationBuilder.UpdateData(
                table: "Plan",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 12, 3, 20, 55, 48, 839, DateTimeKind.Local).AddTicks(235), new DateTime(2022, 12, 3, 20, 55, 48, 839, DateTimeKind.Local).AddTicks(235) });

            migrationBuilder.CreateIndex(
                name: "IX_Like_CommentId",
                table: "Like",
                column: "CommentId");

            migrationBuilder.CreateIndex(
                name: "IX_Like_FeedId",
                table: "Like",
                column: "FeedId");

            migrationBuilder.CreateIndex(
                name: "IX_Like_LikedByUserId",
                table: "Like",
                column: "LikedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Like_ReplyId",
                table: "Like",
                column: "ReplyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Like");

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
    }
}
