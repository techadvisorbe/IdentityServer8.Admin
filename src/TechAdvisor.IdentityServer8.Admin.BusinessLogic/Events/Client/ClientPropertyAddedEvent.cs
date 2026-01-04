using TechAdvisor.AuditLogging.Events;
using TechAdvisor.IdentityServer8.Admin.BusinessLogic.Dtos.Configuration;

namespace TechAdvisor.IdentityServer8.Admin.BusinessLogic.Events.Client
{
    public class ClientPropertyAddedEvent : AuditEvent
    {
        public ClientPropertiesDto ClientProperties { get; set; }

        public ClientPropertyAddedEvent(ClientPropertiesDto clientProperties)
        {
            ClientProperties = clientProperties;
        }
    }
}