using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace EntityFrameworkCore.Triggered.Lifecycles
{
    public static class TriggerSessionExtensions
    {
        public static async Task RaiseBeforeSaveStartingTriggers(this ITriggerSession triggerSession, CancellationToken cancellationToken = default)
        {
            if (triggerSession is TriggerSession supportedTriggerSession)
            {
                supportedTriggerSession.DiscoverChanges();
                var serviceProvider = supportedTriggerSession.DiscoveryService.ServiceProviderAccessor.GetTriggerServiceProvider();

                var services = serviceProvider.GetServices<IBeforeSaveStartingTrigger>();

                foreach (var service in services)
                {
                    await service.BeforeSaveStarting(cancellationToken);
                }
            }
            else
            {
                throw new NotSupportedException("triggerSession needs to be of type TriggerSession in order for lifecycle events to work");
            }
        }

        public static async Task RaiseBeforeSaveStartedTriggers(this ITriggerSession triggerSession, CancellationToken cancellationToken = default)
        {
            if (triggerSession is TriggerSession supportedTriggerSession)
            {
                supportedTriggerSession.DiscoverChanges();
                var serviceProvider = supportedTriggerSession.DiscoveryService.ServiceProviderAccessor.GetTriggerServiceProvider();

                var services = serviceProvider.GetServices<IBeforeSaveStartedTrigger>();

                foreach (var service in services)
                {
                    await service.BeforeSaveStarted(cancellationToken);
                }
            }
            else
            {
                throw new NotSupportedException("triggerSession needs to be of type TriggerSession in order for lifecycle events to work");
            }
        }

        public static async Task RaiseAfterSaveStartingTriggers(this ITriggerSession triggerSession, CancellationToken cancellationToken = default)
        {
            if (triggerSession is TriggerSession supportedTriggerSession)
            {
                supportedTriggerSession.DiscoverChanges();
                var serviceProvider = supportedTriggerSession.DiscoveryService.ServiceProviderAccessor.GetTriggerServiceProvider();

                var services = serviceProvider.GetServices<IAfterSaveStartingTrigger>();

                foreach (var service in services)
                {
                    await service.AfterSaveStarting(cancellationToken);
                }
            }
            else
            {
                throw new NotSupportedException("triggerSession needs to be of type TriggerSession in order for lifecycle events to work");
            }
        }

        public static async Task RaiseAfterSaveStartedTriggers(this ITriggerSession triggerSession, CancellationToken cancellationToken = default)
        {
            if (triggerSession is TriggerSession supportedTriggerSession)
            {
                supportedTriggerSession.DiscoverChanges();
                var serviceProvider = supportedTriggerSession.DiscoveryService.ServiceProviderAccessor.GetTriggerServiceProvider();

                var services = serviceProvider.GetServices<IAfterSaveStartedTrigger>();

                foreach (var service in services)
                {
                    await service.AfterSaveStarted(cancellationToken);
                }
            }
            else
            {
                throw new NotSupportedException("triggerSession needs to be of type TriggerSession in order for lifecycle events to work");
            }
        }
    }
}
