using Microsoft.AspNetCore.Mvc;

namespace CourseService.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CourseController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetCourses()
        {
            return Ok(new string[] { "Course 1", "Course 2" });
        }
    }
}