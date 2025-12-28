using Skoruba.AuditLogging.Events;
using Skoruba.IdentityServer8.Admin.BusinessLogic.Identity.Dtos.Grant;

namespace Skoruba.IdentityServer8.Admin.BusinessLogic.Identity.Events.PersistedGrant
{
    public class PersistedGrantsIdentityByUsersRequestedEvent : AuditEvent
    {
        public PersistedGrantsDto PersistedGrants { get; set; }

        public PersistedGrantsIdentityByUsersRequestedEvent(PersistedGrantsDto persistedGrants)
        {
            PersistedGrants = persistedGrants;
        }
    }
}