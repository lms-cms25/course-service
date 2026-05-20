using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CourseService.Api.Migrations
{
    /// <inheritdoc />
    public partial class UpdateModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StudyProgramId",
                table: "Courses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "StudyPrograms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudyPrograms", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "StudyProgramId" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "StudyProgramId" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "StudyProgramId" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "StudyProgramId" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "StudyProgramId" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "StudyProgramId" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 });

            migrationBuilder.CreateIndex(
                name: "IX_Courses_StudyProgramId",
                table: "Courses",
                column: "StudyProgramId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_StudyPrograms_StudyProgramId",
                table: "Courses",
                column: "StudyProgramId",
                principalTable: "StudyPrograms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_StudyPrograms_StudyProgramId",
                table: "Courses");

            migrationBuilder.DropTable(
                name: "StudyPrograms");

            migrationBuilder.DropIndex(
                name: "IX_Courses_StudyProgramId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "StudyProgramId",
                table: "Courses");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 12, 16, 54, 15, 639, DateTimeKind.Utc).AddTicks(8657));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 12, 16, 54, 15, 640, DateTimeKind.Utc).AddTicks(314));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 12, 16, 54, 15, 640, DateTimeKind.Utc).AddTicks(316));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 12, 16, 54, 15, 640, DateTimeKind.Utc).AddTicks(318));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 12, 16, 54, 15, 640, DateTimeKind.Utc).AddTicks(320));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 12, 16, 54, 15, 640, DateTimeKind.Utc).AddTicks(322));
        }
    }
}
