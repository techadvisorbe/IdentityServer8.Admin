using System.Threading.Tasks;
using IdentityServer8.Events;
using IdentityServer8.Services;
using Microsoft.Extensions.Logging;

namespace Skoruba.IdentityServer4.STS.Identity.Services
{
    public class AuditEventSink : DefaultEventSink
    {
        public AuditEventSink(ILogger<DefaultEventService> logger) : base(logger)
        {
        }

        public override Task PersistAsync(Event evt)
        {
            return base.PersistAsync(evt);
        }
    }
}