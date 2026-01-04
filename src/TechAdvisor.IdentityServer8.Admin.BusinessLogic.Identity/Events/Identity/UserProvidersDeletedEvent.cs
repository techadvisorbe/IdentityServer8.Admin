using TechAdvisor.AuditLogging.Events;

namespace TechAdvisor.IdentityServer8.Admin.BusinessLogic.Identity.Events.Identity
{
    public class UserProvidersDeletedEvent<TUserProviderDto> : AuditEvent
    {
        public TUserProviderDto Provider { get; set; }

        public UserProvidersDeletedEvent(TUserProviderDto provider)
        {
            Provider = provider;
        }
    }
}