using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EntityFrameworkCore.Triggered.Lifecycles.Tests.Stubs
{
    public class TriggerStub : IBeforeSaveStartingTrigger, IBeforeSaveStartedTrigger, IAfterSaveStartingTrigger, IAfterSaveStartedTrigger
    {

        public int BeforeSaveStartingInvocations;
        public int BeforeSaveStartedInvocations;
        public int AfterSaveStartingInvocations;
        public int AfterSaveStartedInvocations;


        public Task BeforeSaveStarting(CancellationToken cancellationToken)
        {
            BeforeSaveStartingInvocations += 1;
            return Task.CompletedTask;
        }

        public Task BeforeSaveStarted(CancellationToken cancellationToken)
        {
            BeforeSaveStartedInvocations += 1;
            return Task.CompletedTask;
        }

        public Task AfterSaveStarting(CancellationToken cancellationToken)
        {
            AfterSaveStartingInvocations += 1;
            return Task.CompletedTask;
        }

        public Task AfterSaveStarted(CancellationToken cancellationToken)
        {
            AfterSaveStartedInvocations += 1;
            return Task.CompletedTask;
        }
    }
}
