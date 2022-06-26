using System.Collections.Generic;
using EntityFrameworkCore.Triggered;

namespace StudentManager.CourseDataChanged
{
    /// <summary>
    /// A shared context for recording changes inside across triggers.
    /// </summary>
    public class CourseDataChangedContext
    {
        public readonly List<ITriggerContext<object>> Changes = new();
    }
}
