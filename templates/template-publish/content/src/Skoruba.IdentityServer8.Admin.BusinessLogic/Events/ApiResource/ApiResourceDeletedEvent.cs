using Skoruba.AuditLogging.Events;
using Skoruba.IdentityServer8.Admin.BusinessLogic.Dtos.Configuration;

namespace Skoruba.IdentityServer8.Admin.BusinessLogic.Events.ApiResource
{
    public class ApiResourceDeletedEvent : AuditEvent
    {
        public ApiResourceDto ApiResource { get; set; }

        public ApiResourceDeletedEvent(ApiResourceDto apiResource)
        {
            ApiResource = apiResource;
        }
    }
}