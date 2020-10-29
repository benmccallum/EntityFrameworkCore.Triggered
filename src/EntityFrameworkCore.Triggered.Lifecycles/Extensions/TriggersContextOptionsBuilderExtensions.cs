using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFrameworkCore.Triggered.Infrastructure;
using EntityFrameworkCore.Triggered.Internal;
using EntityFrameworkCore.Triggered.Lifecycles.Internal;

namespace EntityFrameworkCore.Triggered.Lifecycles.Extensions
{
    public static class TriggersContextOptionsBuilderExtensions
    {
        public static TriggersContextOptionsBuilder UseLifecyleTriggers(this TriggersContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder is null)
            {
                throw new ArgumentNullException(nameof(optionsBuilder));
            }

            #pragma warning disable EF1001 // Internal EF Core API usage.
            optionsBuilder.DbContextOptionsBuilder.ReplaceService<ITriggerSessionFactory, LifecyleTriggerSessionFactory>();
            #pragma warning restore EF1001 // Internal EF Core API usage.

            return optionsBuilder
                .AddTriggerType(typeof(IBeforeSaveStartingTrigger))
                .AddTriggerType(typeof(IBeforeSaveStartedTrigger))
                .AddTriggerType(typeof(IAfterSaveStartingTrigger))
                .AddTriggerType(typeof(IAfterSaveStartedTrigger));
        }
    }
}
