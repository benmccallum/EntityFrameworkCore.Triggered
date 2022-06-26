using MediatR;

namespace StudentManager.CourseDataChanged
{
    public class CourseDataChangedNotification : INotification
    {
        public int CourseId { get; }

        public string PreviousName { get; }

        public CourseDataChangedNotification(
            int courseId,
            string previousName)
        {
            CourseId = courseId;
            PreviousName = previousName;
        }
    }
}
