using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using TechAdvisor.AuditLogging.Events;

namespace TechAdvisor.IdentityServer8.Admin.Api.AuditLogging
{
    public class ApiAuditAction : IAuditAction
    {
        public ApiAuditAction(IHttpContextAccessor accessor)
        {
            Action = new
            {
                TraceIdentifier = accessor.HttpContext.TraceIdentifier,
                RequestUrl = accessor.HttpContext.Request.GetDisplayUrl(),
                HttpMethod = accessor.HttpContext.Request.Method
            };
        }

        public object Action { get; set; }
    }
}