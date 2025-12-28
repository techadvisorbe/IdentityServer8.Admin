using Skoruba.AuditLogging.Events;

namespace Skoruba.IdentityServer8.Admin.BusinessLogic.Events.PersistedGrant
{
    public class PersistedGrantsDeletedEvent : AuditEvent
    {
        public string UserId { get; set; }

        public PersistedGrantsDeletedEvent(string userId)
        {
            UserId = userId;
        }
    }
}