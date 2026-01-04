using TechAdvisor.IdentityServer8.Admin.BusinessLogic.Identity.Dtos.Identity.Interfaces;

namespace TechAdvisor.IdentityServer8.Admin.BusinessLogic.Identity.Dtos.Identity.Base
{
    public class BaseUserClaimDto<TUserId> : IBaseUserClaimDto
    {
        public int ClaimId { get; set; }

        public TUserId UserId { get; set; }

        object IBaseUserClaimDto.UserId => UserId;
    }
}