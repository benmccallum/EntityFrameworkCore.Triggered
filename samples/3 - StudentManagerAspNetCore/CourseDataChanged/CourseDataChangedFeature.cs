using Microsoft.Extensions.DependencyInjection;
using StudentManager.CourseDataChanged;

namespace StudentManager
{
    public static class CourseDataChangedFeature
    {
        public static IServiceCollection AddCourseDataChangedPublishing(
            this IServiceCollection services)
        {
            return services
                .AddScoped<CourseDataChangedContext>();
        }
    }
}
