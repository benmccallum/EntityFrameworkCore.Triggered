using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace EntityFrameworkCore.Triggered.Lifecycles
{
    public static class TriggerSessionExtensions
    {
        static async Task RaiseTriggers<TTriggerType>(ITriggerSession triggerSession, Func<TTriggerType, Func<CancellationToken, Task>> invocation, CancellationToken cancellationToken)
        {
            if (triggerSession is TriggerSession supportedTriggerSession)
            {
                supportedTriggerSession.DiscoverChanges();
                var serviceProvider = supportedTriggerSession.DiscoveryService.ServiceProviderAccessor.GetTriggerServiceProvider();

                var services = serviceProvider.GetServices<TTriggerType>();

                foreach (var service in services)
                {
                    await invocation(service)(cancellationToken);
                }
            }
            else
            {
                throw new NotSupportedException("triggerSession needs to be of type TriggerSession in order for lifecycle events to work");
            }
        }

        public static Task RaiseBeforeSaveStartingTriggers(this ITriggerSession triggerSession, CancellationToken cancellationToken = default) 
            => RaiseTriggers<IBeforeSaveStartingTrigger>(triggerSession, trigger => trigger.BeforeSaveStarting, cancellationToken);

        public static Task RaiseBeforeSaveStartedTriggers(this ITriggerSession triggerSession, CancellationToken cancellationToken = default)
            => RaiseTriggers<IBeforeSaveStartedTrigger>(triggerSession, trigger => trigger.BeforeSaveStarted, cancellationToken);

        public static Task RaiseAfterSaveStartingTriggers(this ITriggerSession triggerSession, CancellationToken cancellationToken = default)
            => RaiseTriggers<IAfterSaveStartingTrigger>(triggerSession, trigger => trigger.AfterSaveStarting, cancellationToken);

        public static Task RaiseAfterSaveStartedTriggers(this ITriggerSession triggerSession, CancellationToken cancellationToken = default)
            => RaiseTriggers<IAfterSaveStartedTrigger>(triggerSession, trigger => trigger.AfterSaveStarted, cancellationToken);


    }
}
