using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bounce_DbOps.Migrations
{
    public partial class AddedTherapistModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "PatientUserProfileId",
                table: "AspNetUsers",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "TherapistUserProfileId",
                table: "AspNetUsers",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TherapistProfiles",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Specialization = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YearsOfExperience = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConsultationDays = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConsultationStartTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConsultationEndTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProfilePicture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<long>(type: "bigint", nullable: true),
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
                    table.PrimaryKey("PK_TherapistProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TherapistProfiles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 11, 20, 9, 1, 32, 153, DateTimeKind.Local).AddTicks(1596), new DateTime(2022, 11, 20, 9, 1, 32, 153, DateTimeKind.Local).AddTicks(1596) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 11, 20, 9, 1, 32, 153, DateTimeKind.Local).AddTicks(1611), new DateTime(2022, 11, 20, 9, 1, 32, 153, DateTimeKind.Local).AddTicks(1611) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 11, 20, 9, 1, 32, 153, DateTimeKind.Local).AddTicks(1623), new DateTime(2022, 11, 20, 9, 1, 32, 153, DateTimeKind.Local).AddTicks(1624) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 11, 20, 9, 1, 32, 153, DateTimeKind.Local).AddTicks(1634), new DateTime(2022, 11, 20, 9, 1, 32, 153, DateTimeKind.Local).AddTicks(1635) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 11, 20, 9, 1, 32, 153, DateTimeKind.Local).AddTicks(1659), new DateTime(2022, 11, 20, 9, 1, 32, 153, DateTimeKind.Local).AddTicks(1660) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 11, 20, 9, 1, 32, 153, DateTimeKind.Local).AddTicks(1676), new DateTime(2022, 11, 20, 9, 1, 32, 153, DateTimeKind.Local).AddTicks(1676) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 11, 20, 9, 1, 32, 153, DateTimeKind.Local).AddTicks(1687), new DateTime(2022, 11, 20, 9, 1, 32, 153, DateTimeKind.Local).AddTicks(1688) });

            migrationBuilder.UpdateData(
                table: "Plan",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 11, 20, 9, 1, 32, 153, DateTimeKind.Local).AddTicks(1512), new DateTime(2022, 11, 20, 9, 1, 32, 153, DateTimeKind.Local).AddTicks(1526) });

            migrationBuilder.UpdateData(
                table: "Plan",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 11, 20, 9, 1, 32, 153, DateTimeKind.Local).AddTicks(1558), new DateTime(2022, 11, 20, 9, 1, 32, 153, DateTimeKind.Local).AddTicks(1559) });

            migrationBuilder.UpdateData(
                table: "Plan",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 11, 20, 9, 1, 32, 153, DateTimeKind.Local).AddTicks(1571), new DateTime(2022, 11, 20, 9, 1, 32, 153, DateTimeKind.Local).AddTicks(1572) });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_PatientUserProfileId",
                table: "AspNetUsers",
                column: "PatientUserProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_TherapistUserProfileId",
                table: "AspNetUsers",
                column: "TherapistUserProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_TherapistProfiles_UserId",
                table: "TherapistProfiles",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_TherapistProfiles_TherapistUserProfileId",
                table: "AspNetUsers",
                column: "TherapistUserProfileId",
                principalTable: "TherapistProfiles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_UserProfile_PatientUserProfileId",
                table: "AspNetUsers",
                column: "PatientUserProfileId",
                principalTable: "UserProfile",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_TherapistProfiles_TherapistUserProfileId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_UserProfile_PatientUserProfileId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "TherapistProfiles");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_PatientUserProfileId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_TherapistUserProfileId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PatientUserProfileId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "TherapistUserProfileId",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 11, 19, 17, 48, 28, 536, DateTimeKind.Local).AddTicks(9660), new DateTime(2022, 11, 19, 17, 48, 28, 536, DateTimeKind.Local).AddTicks(9661) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 11, 19, 17, 48, 28, 536, DateTimeKind.Local).AddTicks(9671), new DateTime(2022, 11, 19, 17, 48, 28, 536, DateTimeKind.Local).AddTicks(9672) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 11, 19, 17, 48, 28, 536, DateTimeKind.Local).AddTicks(9679), new DateTime(2022, 11, 19, 17, 48, 28, 536, DateTimeKind.Local).AddTicks(9679) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 11, 19, 17, 48, 28, 536, DateTimeKind.Local).AddTicks(9686), new DateTime(2022, 11, 19, 17, 48, 28, 536, DateTimeKind.Local).AddTicks(9686) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 11, 19, 17, 48, 28, 536, DateTimeKind.Local).AddTicks(9692), new DateTime(2022, 11, 19, 17, 48, 28, 536, DateTimeKind.Local).AddTicks(9692) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 11, 19, 17, 48, 28, 536, DateTimeKind.Local).AddTicks(9700), new DateTime(2022, 11, 19, 17, 48, 28, 536, DateTimeKind.Local).AddTicks(9701) });

            migrationBuilder.UpdateData(
                table: "FeedGroups",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2022, 11, 19, 17, 48, 28, 536, DateTimeKind.Local).AddTicks(9717), new DateTime(2022, 11, 19, 17, 48, 28, 536, DateTimeKind.Local).AddTicks(9719) });

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
        }
    }
}
