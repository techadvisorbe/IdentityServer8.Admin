using Skoruba.AuditLogging.Events;
using Skoruba.IdentityServer8.Admin.BusinessLogic.Dtos.Configuration;

namespace Skoruba.IdentityServer8.Admin.BusinessLogic.Events.Client
{
    public class ClientDeletedEvent : AuditEvent
    {
        public ClientDto Client { get; set; }

        public ClientDeletedEvent(ClientDto client)
        {
            Client = client;
        }
    }
}