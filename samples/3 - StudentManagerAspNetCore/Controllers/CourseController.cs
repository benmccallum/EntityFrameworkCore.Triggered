using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

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

        [HttpPost("")]
        public async Task<IActionResult> PostAsync()
        {
            _context.Courses.Add(new Course
            {
                DisplayName = "Some course"
            });
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
