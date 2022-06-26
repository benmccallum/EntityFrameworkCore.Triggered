using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace StudentManager.Controllers
{
    [ApiController]
    [Route("api/course")]
    public class CourseController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CourseController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost("add")]
        public async Task<IActionResult> PostAddAsync()
        {
            _context.Courses.Add(new Course
            {
                DisplayName = "Some course"
            });
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPost("update")]
        public async Task<IActionResult> PostUpdateAsync()
        {
            var course = await _context.Courses.FirstAsync();
            course.DisplayName += ".";
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
