using TechAdvisor.AuditLogging.Events;
using TechAdvisor.IdentityServer8.Admin.BusinessLogic.Dtos.Configuration;

namespace TechAdvisor.IdentityServer8.Admin.BusinessLogic.Events.ApiScope
{
    public class ApiScopeUpdatedEvent : AuditEvent
    {
        public ApiScopeDto OriginalApiScope { get; set; }
        public ApiScopeDto ApiScope { get; set; }

        public ApiScopeUpdatedEvent(ApiScopeDto originalApiScope, ApiScopeDto apiScope)
        {
            OriginalApiScope = originalApiScope;
            ApiScope = apiScope;
        }
    }
}