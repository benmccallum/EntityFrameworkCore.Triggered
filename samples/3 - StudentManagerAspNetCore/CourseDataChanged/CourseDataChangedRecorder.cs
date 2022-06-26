using System.Threading;
using System.Threading.Tasks;
using EntityFrameworkCore.Triggered;

namespace StudentManager.CourseDataChanged
{
    public class CourseDataChangedRecorder
        : IAfterSaveTrigger<Course>
        , IAfterSaveTrigger<ICourseData>
    {
        private readonly CourseDataChangedContext _context;

        public CourseDataChangedRecorder(
            CourseDataChangedContext context)
        {
            _context = context;
        }

        public Task AfterSave(ITriggerContext<Course> context, CancellationToken cancellationToken)
        {
            if (context.ChangeType != ChangeType.Deleted)
            {
                _context.Changes.Add(context);
            }

            return Task.CompletedTask;
        }

        public Task AfterSave(ITriggerContext<ICourseData> context, CancellationToken cancellationToken)
        {
            _context.Changes.Add(context);

            return Task.CompletedTask;
        }
    }
}
