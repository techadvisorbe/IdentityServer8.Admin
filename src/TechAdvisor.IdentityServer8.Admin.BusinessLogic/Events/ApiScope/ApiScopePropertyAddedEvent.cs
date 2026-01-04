using TechAdvisor.AuditLogging.Events;
using TechAdvisor.IdentityServer8.Admin.BusinessLogic.Dtos.Configuration;

namespace TechAdvisor.IdentityServer8.Admin.BusinessLogic.Events.ApiScope
{
    public class ApiScopePropertyAddedEvent : AuditEvent
    {
        public ApiScopePropertyAddedEvent(ApiScopePropertiesDto apiScopeProperty)
        {
            ApiScopeProperty = apiScopeProperty;
        }

        public ApiScopePropertiesDto ApiScopeProperty { get; set; }
    }
}