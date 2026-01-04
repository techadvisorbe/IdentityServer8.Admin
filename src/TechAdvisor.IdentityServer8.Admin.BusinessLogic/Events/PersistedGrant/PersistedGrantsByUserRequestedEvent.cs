using TechAdvisor.AuditLogging.Events;
using TechAdvisor.IdentityServer8.Admin.BusinessLogic.Dtos.Grant;

namespace TechAdvisor.IdentityServer8.Admin.BusinessLogic.Events.PersistedGrant
{
    public class PersistedGrantsByUserRequestedEvent : AuditEvent
    {
        public PersistedGrantsDto PersistedGrants { get; set; }

        public PersistedGrantsByUserRequestedEvent(PersistedGrantsDto persistedGrants)
        {
            PersistedGrants = persistedGrants;
        }
    }
}