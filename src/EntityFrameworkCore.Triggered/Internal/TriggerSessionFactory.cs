using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFrameworkCore.Triggered.Internal.RecursionStrategy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace EntityFrameworkCore.Triggered.Internal
{
    public class TriggerSessionFactory : ITriggerSessionFactory
    {
        readonly ITriggerDiscoveryService _triggerDiscoveryService;
        readonly IRecursionStrategy _recursionStrategy;
        readonly ILoggerFactory _loggerFactory;
        readonly IOptionsSnapshot<TriggerOptions> _triggerOptionsSnapshot;

        public TriggerSessionFactory(ITriggerDiscoveryService triggerDiscoveryService, IRecursionStrategy recursionStrategy, ILoggerFactory loggerFactory, IOptionsSnapshot<TriggerOptions> triggerOptionsSnapshot)
        {
            _triggerDiscoveryService = triggerDiscoveryService ?? throw new ArgumentNullException(nameof(triggerDiscoveryService));
            _recursionStrategy = recursionStrategy ?? throw new ArgumentNullException(nameof(recursionStrategy));
            _loggerFactory = loggerFactory ?? throw new ArgumentNullException(nameof(loggerFactory));
            _triggerOptionsSnapshot = triggerOptionsSnapshot ?? throw new ArgumentNullException(nameof(triggerOptionsSnapshot));
        }

        public ITriggerSession CreateSession(ITriggerService triggerService, DbContext context, IServiceProvider? serviceProvider)
        {
            if (triggerService is null)
            {
                throw new ArgumentNullException(nameof(triggerService));
            }

            if (context is null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            var triggerContextTracker = new TriggerContextTracker(context.ChangeTracker, _recursionStrategy);

            if (serviceProvider != null)
            {
                _triggerDiscoveryService.ServiceProviderAccessor = new TriggerServiceProviderAccessor(serviceProvider);
            }

            var triggerSession = new TriggerSession(triggerService,
                _triggerOptionsSnapshot.Value,
                _triggerDiscoveryService,
                triggerContextTracker,
                _loggerFactory.CreateLogger<TriggerSession>());

            return triggerSession;
        }
    }
}
