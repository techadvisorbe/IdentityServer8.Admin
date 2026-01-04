using TechAdvisor.AuditLogging.Events;

namespace TechAdvisor.IdentityServer8.Admin.BusinessLogic.Identity.Events.Identity
{
    public class UserRoleSavedEvent<TUserRolesDto> : AuditEvent
    {
        public TUserRolesDto Role { get; set; }

        public UserRoleSavedEvent(TUserRolesDto role)
        {
            Role = role;
        }
    }
}