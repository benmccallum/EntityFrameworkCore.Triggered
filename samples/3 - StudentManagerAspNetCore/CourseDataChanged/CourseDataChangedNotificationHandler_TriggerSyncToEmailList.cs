using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace StudentManager.CourseDataChanged
{
    /// <summary>
    /// Triggers an AutoGuru email list (e.g. AutoPilot) sync for a supplier
    /// by raising cloud notification that will be processed elsewhere.
    /// </summary>
    public class CourseDataChangedNotificationHandler_TriggerSyncToEmailList
        : INotificationHandler<CourseDataChangedNotification>
    {
        private readonly IDbContextFactory<ApplicationDbContext> _dbContextFactory;

        public CourseDataChangedNotificationHandler_TriggerSyncToEmailList(
            IDbContextFactory<ApplicationDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task Handle(
            CourseDataChangedNotification notification,
            CancellationToken cancellationToken)
        {
            using var db = _dbContextFactory.CreateDbContext();
            var courseDetails = await db.Courses
                .Select(c => new
                {
                    c.DisplayName
                })
                .FirstAsync(CancellationToken.None);
        }
    }
}
