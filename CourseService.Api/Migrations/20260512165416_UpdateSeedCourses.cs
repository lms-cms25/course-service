using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CourseService.Api.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSeedCourses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Category", "CreatedAt", "Description", "Duration", "Image", "Instructor", "Level", "Rating", "Students", "Title" },
                values: new object[,]
                {
                    { 1, "Graphic Design", new DateTime(2026, 5, 12, 16, 54, 15, 639, DateTimeKind.Utc).AddTicks(8657), "Learn machine learning basics", "6 weeks", "/images/course1.jpg", "Jennifer Anderson", "Beginner", 5.0, 120, "Machine Learning Basics" },
                    { 2, "UI/UX Design", new DateTime(2026, 5, 12, 16, 54, 15, 640, DateTimeKind.Utc).AddTicks(314), "Business analytics course", "8 weeks", "/images/course2.jpg", "Robert Chen", "Intermediate", 5.0, 95, "Business Analytics & Strategy" },
                    { 3, "Brand Identity", new DateTime(2026, 5, 12, 16, 54, 15, 640, DateTimeKind.Utc).AddTicks(316), "Marketing fundamentals", "5 weeks", "/images/course3.jpg", "Emily Davis", "Beginner", 5.0, 70, "Content Marketing" },
                    { 4, "Web Design", new DateTime(2026, 5, 12, 16, 54, 15, 640, DateTimeKind.Utc).AddTicks(318), "Product design basics", "7 weeks", "/images/course4.jpg", "Michael Torres", "Beginner", 5.0, 110, "Product Design for Beginner" },
                    { 5, "Development", new DateTime(2026, 5, 12, 16, 54, 15, 640, DateTimeKind.Utc).AddTicks(320), "Backend development course", "10 weeks", "/images/course5.jpg", "Sarah Williams", "Intermediate", 4.0, 150, "Backend Developer" },
                    { 6, "Design", new DateTime(2026, 5, 12, 16, 54, 15, 640, DateTimeKind.Utc).AddTicks(322), "Adobe XD design course", "4 weeks", "/images/course6.jpg", "David Martinez", "Beginner", 5.0, 60, "Adobe XD for Designer" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 6);
        }
    }
}
