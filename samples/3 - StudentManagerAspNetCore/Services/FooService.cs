using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace StudentManager.Services
{
    public class FooService
    {
        readonly ApplicationDbContext _applicationContext;

        public FooService(ApplicationDbContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public async Task DoSomethingAsync()
        {
            await Task.Delay(500);

            var count = await _applicationContext.Courses.CountAsync();

        }
    }
}
