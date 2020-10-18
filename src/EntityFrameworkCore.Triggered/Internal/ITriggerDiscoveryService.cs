using System;
using System.Collections.Generic;

namespace EntityFrameworkCore.Triggered.Internal
{
    public interface ITriggerDiscoveryService
    {
        ITriggerServiceProviderAccessor ServiceProviderAccessor { get; set; }

        IEnumerable<TriggerDescriptor> DiscoverTriggers(Type openTriggerType, Type entityType, Func<Type, ITriggerTypeDescriptor> triggerTypeDescriptorFactory);
    }
}
