using Skoruba.AuditLogging.Events;
using Skoruba.IdentityServer8.Admin.BusinessLogic.Dtos.Grant;

namespace Skoruba.IdentityServer8.Admin.BusinessLogic.Events.PersistedGrant
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