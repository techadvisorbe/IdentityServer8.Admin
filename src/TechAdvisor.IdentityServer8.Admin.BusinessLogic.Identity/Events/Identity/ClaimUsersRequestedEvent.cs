using TechAdvisor.AuditLogging.Events;
using TechAdvisor.IdentityServer8.Admin.BusinessLogic.Identity.Dtos.Identity;

namespace TechAdvisor.IdentityServer8.Admin.BusinessLogic.Identity.Events.Identity
{
    public class ClaimUsersRequestedEvent<TUsersDto> : AuditEvent
    {
        public TUsersDto Users { get; set; }

        public ClaimUsersRequestedEvent(TUsersDto users)
        {
            Users = users;
        }
    }
}