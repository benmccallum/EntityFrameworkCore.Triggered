using System;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCore.Triggered.Internal
{
    public interface ITriggerSessionFactory
    {
        ITriggerSession CreateSession(ITriggerService triggerService, DbContext context, IServiceProvider? serviceProvider);
    }
}