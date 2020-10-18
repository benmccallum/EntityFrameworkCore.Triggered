using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EntityFrameworkCore.Triggered;

namespace EntityFramework.Triggered.Lifecycles.Tests.Extensions
{
    public static class TriggerSessionExtensions
    {
        public static Task RaiseBeforeSaveStartingTriggers(this ITriggerSession triggerSession, CancellationToken cancellationToken)
        {
            //triggerSession.RaiseAfterSaveFailedTriggers
            throw new NotImplementedException();
        }
    }
}
