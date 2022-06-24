using System.Threading;
using System.Threading.Tasks;
using EntityFrameworkCore.Triggered;
using StudentManager.Services;

namespace StudentManager.Triggers.Courses
{
    public class CourseSavedNotifier : IAfterSaveTrigger<Course>
    {
        readonly FooService _fooService;

        public CourseSavedNotifier(FooService fooService)
        {
            _fooService = fooService;
        }

        public async Task AfterSave(ITriggerContext<Course> context, CancellationToken cancellationToken)
        {
            await _fooService.DoSomethingAsync();
        }
    }
}
