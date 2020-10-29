using System;
using System.Threading;
using System.Threading.Tasks;
using EntityFrameworkCore.Triggered.Internal;
using EntityFrameworkCore.Triggered.Internal.RecursionStrategy;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace EntityFrameworkCore.Triggered
{
    public class TriggerService : ITriggerService, IResettableService
    {
        readonly ITriggerSessionFactory _triggerSessionFactory;
        
        ITriggerSession? _currentTriggerSession;

        public TriggerService(ITriggerSessionFactory triggerSessionFactory)
        {
            _triggerSessionFactory = triggerSessionFactory ?? throw new ArgumentNullException(nameof(triggerSessionFactory));
        }

        public ITriggerSession? Current
        {
            get => _currentTriggerSession;
            set => _currentTriggerSession = value;
        }

        public ITriggerSession CreateSession(DbContext context, IServiceProvider? serviceProvider)
        {
            if (context is null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            var triggerSession = _triggerSessionFactory.CreateSession(this, context, serviceProvider);
            _currentTriggerSession = triggerSession;

            return triggerSession;
        }

        public void ResetState()
        {
            if (_currentTriggerSession != null)
            {
                _currentTriggerSession.Dispose();
                _currentTriggerSession = null;
            }
        }

        public Task ResetStateAsync(CancellationToken cancellationToken = default)
        {
            ResetState();

            return Task.CompletedTask;
        }
    }

}
