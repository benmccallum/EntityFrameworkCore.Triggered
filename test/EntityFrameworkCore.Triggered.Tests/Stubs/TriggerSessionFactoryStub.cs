using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFrameworkCore.Triggered.Internal;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCore.Triggered.Tests.Stubs
{
    public class TriggerSessionFactoryStub : ITriggerSessionFactory
    {
        public ITriggerSession CreateSession(ITriggerService triggerService, DbContext context, IServiceProvider serviceProvider)
        {
            return new TriggerSessionStub();
        }
    }
}
