using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFrameworkCore.Triggered.Infrastructure;

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

            return optionsBuilder
                .UseLifecyleBeforeSaveStartingTriggers()
                .UseLifecyleBeforeSaveStartedTriggers()
                .UseLifecyleAfterSaveStartingTriggers()
                .UseLifecyleAfterSaveStartedTriggers();
        }

        public static TriggersContextOptionsBuilder UseLifecyleBeforeSaveStartingTriggers(this TriggersContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder is null)
            {
                throw new ArgumentNullException(nameof(optionsBuilder));
            }

            optionsBuilder.AddTriggerType(typeof(IBeforeSaveStartingTrigger));

            return optionsBuilder;
        }

        public static TriggersContextOptionsBuilder UseLifecyleBeforeSaveStartedTriggers(this TriggersContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder is null)
            {
                throw new ArgumentNullException(nameof(optionsBuilder));
            }

            optionsBuilder.AddTriggerType(typeof(IBeforeSaveStartedTrigger));

            return optionsBuilder;
        }

        public static TriggersContextOptionsBuilder UseLifecyleAfterSaveStartingTriggers(this TriggersContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder is null)
            {
                throw new ArgumentNullException(nameof(optionsBuilder));
            }

            optionsBuilder.AddTriggerType(typeof(IAfterSaveStartingTrigger));

            return optionsBuilder;
        }

        public static TriggersContextOptionsBuilder UseLifecyleAfterSaveStartedTriggers(this TriggersContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder is null)
            {
                throw new ArgumentNullException(nameof(optionsBuilder));
            }
            
            optionsBuilder.AddTriggerType(typeof(IAfterSaveStartedTrigger));

            return optionsBuilder;
        }
    }
}
