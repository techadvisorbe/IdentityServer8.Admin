using Skoruba.AuditLogging.Events;
using Skoruba.IdentityServer8.Admin.BusinessLogic.Dtos.Configuration;

namespace Skoruba.IdentityServer8.Admin.BusinessLogic.Events.Client
{
    public class ClientClonedEvent : AuditEvent
    {
        public ClientCloneDto Client { get; set; }

        public ClientClonedEvent(ClientCloneDto client)
        {
            Client = client;
        }
    }
}