using Skoruba.AuditLogging.Events;
using Skoruba.IdentityServer8.Admin.BusinessLogic.Dtos.Configuration;

namespace Skoruba.IdentityServer8.Admin.BusinessLogic.Events.IdentityResource
{
    public class IdentityResourcePropertiesRequestedEvent : AuditEvent
    {
        public IdentityResourcePropertiesDto IdentityResourceProperties { get; set; }

        public IdentityResourcePropertiesRequestedEvent(IdentityResourcePropertiesDto identityResourceProperties)
        {
            IdentityResourceProperties = identityResourceProperties;
        }
    }
}