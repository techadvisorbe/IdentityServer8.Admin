using Skoruba.AuditLogging.Events;
using Skoruba.IdentityServer8.Admin.BusinessLogic.Dtos.Grant;

namespace Skoruba.IdentityServer8.Admin.BusinessLogic.Events.PersistedGrant
{
    public class PersistedGrantsByUsersRequestedEvent : AuditEvent
    {
        public PersistedGrantsDto PersistedGrants { get; set; }

        public PersistedGrantsByUsersRequestedEvent(PersistedGrantsDto persistedGrants)
        {
            PersistedGrants = persistedGrants;
        }
    }
}