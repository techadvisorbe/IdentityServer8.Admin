using TechAdvisor.AuditLogging.Events;

namespace TechAdvisor.IdentityServer8.Admin.BusinessLogic.Identity.Events.Identity
{
    public class UserProvidersRequestedEvent<TUserProvidersDto> : AuditEvent
    {
        public TUserProvidersDto Providers { get; set; }

        public UserProvidersRequestedEvent(TUserProvidersDto providers)
        {
            Providers = providers;
        }
    }
}