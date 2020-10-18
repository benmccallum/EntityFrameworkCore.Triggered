using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkCore.Triggered.Internal
{
    public class TriggerServiceProviderAccessor : ITriggerServiceProviderAccessor
    {
        readonly IServiceProvider _serviceProvider;

        public TriggerServiceProviderAccessor(IServiceProvider serviceProvider)
        {
            if (serviceProvider is null)
            {
                throw new ArgumentNullException(nameof(serviceProvider));
            }

            _serviceProvider = serviceProvider;
        }

        public IServiceProvider GetTriggerServiceProvider() => _serviceProvider;
    }
}
