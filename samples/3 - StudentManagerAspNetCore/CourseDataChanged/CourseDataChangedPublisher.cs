using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EntityFrameworkCore.Triggered;
using EntityFrameworkCore.Triggered.Lifecycles;
using MediatR;

namespace StudentManager.CourseDataChanged
{
    public class CourseDataChangedPublisher
        : IAfterSaveCompletedTrigger
    {
        private readonly CourseDataChangedContext _context;
        private readonly IPublisher _publisher;

        public CourseDataChangedPublisher(
            CourseDataChangedContext context,
            IPublisher publisher)
        {
            _context = context;
            _publisher = publisher;
        }

        public async Task AfterSaveCompleted(CancellationToken cancellationToken)
        {
            if (_context.Changes.Count < 1)
            {
                return;
            }

            // Flatten the changes, grouping by the course they relate to
            var flattenedChanges = _context.Changes
                .GroupBy(c =>
                {
                    if (c is ITriggerContext<Course> supplierChange)
                    {
                        return supplierChange.Entity.Id;
                    }
                    else if (c is ITriggerContext<ICourseData> CourseDataChange)
                    {
                        return CourseDataChange.Entity.CourseId;
                    }
                    throw new NotImplementedException();
                })
                .Select(g =>
                {
                    // If there's a direct Cource entity change in the batch, grab it, as we may
                    // want to pass through "old" values like the previous email address which in
                    // some systems is an identifier that needs to flow through for special treatment
                    var CourseDataChange = g.OfType<ITriggerContext<Course>>().SingleOrDefault();

                    return new CourseDataChangedNotification(
                        g.Key,
                        CourseDataChange?.UnmodifiedEntity?.DisplayName);
                });

            // Publish notification for each
            foreach (var supplierChange in flattenedChanges)
            {
                await _publisher.Publish(supplierChange, CancellationToken.None);
            }

            // Clear list of changes dealt with
            _context.Changes.Clear();
        }
    }
}
