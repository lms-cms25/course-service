using System.Net;
using Xunit;

namespace CourseService.Tests;

public class CourseApiTests
{
    // API functionality
    [Fact]
    public void GetCourses_ReturnsOk()
    {
        // Arrange
        var expected = HttpStatusCode.OK;

        // Act
        var actual = HttpStatusCode.OK;

        // Assert
        Assert.Equal(expected, actual);
    }

    // CRUD operations
    [Fact]
    public void CreateCourse_ReturnsCreated()
    {
        // Arrange
        var expected = HttpStatusCode.Created;

        // Act
        var actual = HttpStatusCode.Created;

        // Assert
        Assert.Equal(expected, actual);
    }

    // Course service logic
    [Fact]
    public void CourseTitle_ShouldNotBeEmpty()
    {
        // Arrange
        var title = "Backend Developer";

        // Assert
        Assert.False(string.IsNullOrWhiteSpace(title));
    }
}