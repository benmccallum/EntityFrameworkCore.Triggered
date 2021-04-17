﻿using System.Threading;
using System.Threading.Tasks;
using EntityFrameworkCore.Triggered.Extensions;

namespace EntityFrameworkCore.Triggered.IntegrationTests.LifetimeTests.Triggers.Users
{
    class TransientTrigger : IBeforeSaveTrigger<object>
    {
        public TransientTrigger(TriggerLifetimeTestScenario triggerLifetimeTestScenario)
        {
            triggerLifetimeTestScenario.TransientTriggerInstances++;
        }

        public Task BeforeSave(ITriggerContext<object> context, CancellationToken cancellationToken) => Task.CompletedTask;
    }
}
