using Skoruba.AuditLogging.Events;
using Skoruba.IdentityServer8.Admin.BusinessLogic.Dtos.Configuration;

namespace Skoruba.IdentityServer8.Admin.BusinessLogic.Events.ApiResource
{
    public class ApiResourcePropertyRequestedEvent : AuditEvent
    {
        public ApiResourcePropertyRequestedEvent(int apiResourcePropertyId, ApiResourcePropertiesDto apiResourceProperties)
        {
            ApiResourcePropertyId = apiResourcePropertyId;
            ApiResourceProperties = apiResourceProperties;
        }

        public int ApiResourcePropertyId { get; }
        public ApiResourcePropertiesDto ApiResourceProperties { get; set; }
    }
}