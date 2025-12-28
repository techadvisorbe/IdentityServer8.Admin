using Skoruba.AuditLogging.Events;
using Skoruba.IdentityServer8.Admin.BusinessLogic.Dtos.Configuration;

namespace Skoruba.IdentityServer8.Admin.BusinessLogic.Events.ApiResource
{
    public class ApiResourcePropertiesRequestedEvent : AuditEvent
    {
        public ApiResourcePropertiesRequestedEvent(int apiResourceId, ApiResourcePropertiesDto apiResourceProperties)
        {
            ApiResourceId = apiResourceId;
            ApiResourceProperties = apiResourceProperties;
        }

        public int ApiResourceId { get; set; }
        public ApiResourcePropertiesDto ApiResourceProperties { get; }
    }
}