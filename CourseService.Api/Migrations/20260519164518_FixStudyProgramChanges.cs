using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CourseService.Api.Migrations
{
    /// <inheritdoc />
    public partial class FixStudyProgramChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StudyProgramId",
                table: "Courses",
                type: "int",
                nullable: false,
                defaultValue: 1);

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

            // Skapar ett standardprogram för befintliga kurser
            migrationBuilder.InsertData(
                table: "StudyPrograms",
                columns: new[] { "Id", "Name", "Description" },
                values: new object[] { 1, ".NET Webbutvecklare", "Standardprogram för befintliga kurser" });

            // Kopplar befintliga kurser till standardprogrammet
            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1,
                column: "StudyProgramId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2,
                column: "StudyProgramId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 3,
                column: "StudyProgramId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 4,
                column: "StudyProgramId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 5,
                column: "StudyProgramId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 6,
                column: "StudyProgramId",
                value: 1);

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
        }
    }
}