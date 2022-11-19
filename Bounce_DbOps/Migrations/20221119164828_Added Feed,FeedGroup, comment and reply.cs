using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bounce_DbOps.Migrations
{
    public partial class AddedFeedFeedGroupcommentandreply : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FeedGroups",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    table.PrimaryKey("PK_FeedGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Feeds",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Post = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FeedGroupId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedByUserId = table.Column<long>(type: "bigint", nullable: false),
                    LikeCount = table.Column<int>(type: "int", nullable: false),
                    Attachment = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_Feeds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Feeds_AspNetUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Feeds_FeedGroups_FeedGroupId",
                        column: x => x.FeedGroupId,
                        principalTable: "FeedGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedByUserId = table.Column<long>(type: "bigint", nullable: false),
                    FeedId = table.Column<long>(type: "bigint", nullable: false),
                    LikeCount = table.Column<int>(type: "int", nullable: false),
                    Attachment = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_AspNetUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Comments_Feeds_FeedId",
                        column: x => x.FeedId,
                        principalTable: "Feeds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Replies",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Reply = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedByUserId = table.Column<long>(type: "bigint", nullable: false),
                    CommentId = table.Column<long>(type: "bigint", nullable: false),
                    LikeCount = table.Column<int>(type: "int", nullable: false),
                    Attachment = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_Replies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Replies_AspNetUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Replies_Comments_CommentId",
                        column: x => x.CommentId,
                        principalTable: "Comments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.InsertData(
                table: "FeedGroups",
                columns: new[] { "Id", "CreatedTimeOffset", "DateCreated", "DateModified", "IsActive", "IsDeleted", "LastModifiedBy", "ModifiedTimeOffset", "Name" },
                values: new object[,]
                {
                    { 1L, null, new DateTime(2022, 11, 19, 17, 48, 28, 536, DateTimeKind.Local).AddTicks(9660), new DateTime(2022, 11, 19, 17, 48, 28, 536, DateTimeKind.Local).AddTicks(9661), false, false, null, null, "Relationship" },
                    { 2L, null, new DateTime(2022, 11, 19, 17, 48, 28, 536, DateTimeKind.Local).AddTicks(9671), new DateTime(2022, 11, 19, 17, 48, 28, 536, DateTimeKind.Local).AddTicks(9672), false, false, null, null, "Self Care" },
                    { 3L, null, new DateTime(2022, 11, 19, 17, 48, 28, 536, DateTimeKind.Local).AddTicks(9679), new DateTime(2022, 11, 19, 17, 48, 28, 536, DateTimeKind.Local).AddTicks(9679), false, false, null, null, "Work Ethics" },
                    { 4L, null, new DateTime(2022, 11, 19, 17, 48, 28, 536, DateTimeKind.Local).AddTicks(9686), new DateTime(2022, 11, 19, 17, 48, 28, 536, DateTimeKind.Local).AddTicks(9686), false, false, null, null, "Family" },
                    { 5L, null, new DateTime(2022, 11, 19, 17, 48, 28, 536, DateTimeKind.Local).AddTicks(9692), new DateTime(2022, 11, 19, 17, 48, 28, 536, DateTimeKind.Local).AddTicks(9692), false, false, null, null, "Self Care" },
                    { 6L, null, new DateTime(2022, 11, 19, 17, 48, 28, 536, DateTimeKind.Local).AddTicks(9700), new DateTime(2022, 11, 19, 17, 48, 28, 536, DateTimeKind.Local).AddTicks(9701), false, false, null, null, "Sexuality" },
                    { 7L, null, new DateTime(2022, 11, 19, 17, 48, 28, 536, DateTimeKind.Local).AddTicks(9717), new DateTime(2022, 11, 19, 17, 48, 28, 536, DateTimeKind.Local).AddTicks(9719), false, false, null, null, "Parenting" }
                });

            migrationBuilder.UpdateData(
                table: "Plan",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 11, 19, 17, 48, 28, 536, DateTimeKind.Local).AddTicks(9602), new DateTime(2022, 11, 19, 17, 48, 28, 536, DateTimeKind.Local).AddTicks(9612) });

            migrationBuilder.UpdateData(
                table: "Plan",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 11, 19, 17, 48, 28, 536, DateTimeKind.Local).AddTicks(9636), new DateTime(2022, 11, 19, 17, 48, 28, 536, DateTimeKind.Local).AddTicks(9636) });

            migrationBuilder.UpdateData(
                table: "Plan",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 11, 19, 17, 48, 28, 536, DateTimeKind.Local).AddTicks(9645), new DateTime(2022, 11, 19, 17, 48, 28, 536, DateTimeKind.Local).AddTicks(9645) });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_CreatedByUserId",
                table: "Comments",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_FeedId",
                table: "Comments",
                column: "FeedId");

            migrationBuilder.CreateIndex(
                name: "IX_Feeds_CreatedByUserId",
                table: "Feeds",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Feeds_FeedGroupId",
                table: "Feeds",
                column: "FeedGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Replies_CommentId",
                table: "Replies",
                column: "CommentId");

            migrationBuilder.CreateIndex(
                name: "IX_Replies_CreatedByUserId",
                table: "Replies",
                column: "CreatedByUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Replies");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Feeds");

            migrationBuilder.DropTable(
                name: "FeedGroups");

            migrationBuilder.UpdateData(
                table: "Plan",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 11, 18, 15, 31, 22, 605, DateTimeKind.Utc).AddTicks(5182), new DateTime(2022, 11, 18, 15, 31, 22, 605, DateTimeKind.Utc).AddTicks(5187) });

            migrationBuilder.UpdateData(
                table: "Plan",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 11, 18, 15, 31, 22, 605, DateTimeKind.Utc).AddTicks(6122), new DateTime(2022, 11, 18, 15, 31, 22, 605, DateTimeKind.Utc).AddTicks(6123) });

            migrationBuilder.UpdateData(
                table: "Plan",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 11, 18, 15, 31, 22, 605, DateTimeKind.Utc).AddTicks(6146), new DateTime(2022, 11, 18, 15, 31, 22, 605, DateTimeKind.Utc).AddTicks(6147) });
        }
    }
}
