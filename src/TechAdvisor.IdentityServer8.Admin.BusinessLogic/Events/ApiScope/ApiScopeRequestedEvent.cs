using TechAdvisor.AuditLogging.Events;
using TechAdvisor.IdentityServer8.Admin.BusinessLogic.Dtos.Configuration;

namespace TechAdvisor.IdentityServer8.Admin.BusinessLogic.Events.ApiScope
{
    public class ApiScopeRequestedEvent : AuditEvent
    {
        public ApiScopeDto ApiScopes { get; set; }

        public ApiScopeRequestedEvent(ApiScopeDto apiScopes)
        {
            ApiScopes = apiScopes;
        }
    }
}