namespace CourseService.Api.Dtos;


    public record CourseRequestDto(
        string Title,
        string Instructor,
        string Category,
        string Duration,
        string Level,
        string Image,
        double Rating,
        string Description,
        int Students
        );
   

