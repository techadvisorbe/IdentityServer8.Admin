using Skoruba.AuditLogging.Events;
using Skoruba.IdentityServer8.Admin.BusinessLogic.Dtos.Grant;

namespace Skoruba.IdentityServer8.Admin.BusinessLogic.Events.PersistedGrant
{
    public class PersistedGrantRequestedEvent : AuditEvent
    {
        public PersistedGrantDto PersistedGrant { get; set; }

        public PersistedGrantRequestedEvent(PersistedGrantDto persistedGrant)
        {
            PersistedGrant = persistedGrant;
        }
    }
}