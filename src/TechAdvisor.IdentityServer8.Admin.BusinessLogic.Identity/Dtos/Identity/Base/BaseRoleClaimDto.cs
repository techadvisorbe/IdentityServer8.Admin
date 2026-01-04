using TechAdvisor.IdentityServer8.Admin.BusinessLogic.Identity.Dtos.Identity.Interfaces;

namespace TechAdvisor.IdentityServer8.Admin.BusinessLogic.Identity.Dtos.Identity.Base
{
    public class BaseRoleClaimDto<TRoleId> : IBaseRoleClaimDto
    {
        public int ClaimId { get; set; }

        public TRoleId RoleId { get; set; }

        object IBaseRoleClaimDto.RoleId => RoleId;
    }
}