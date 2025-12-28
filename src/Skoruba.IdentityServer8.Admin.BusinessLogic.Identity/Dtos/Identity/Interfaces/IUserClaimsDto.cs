using System.Collections.Generic;

namespace Skoruba.IdentityServer8.Admin.BusinessLogic.Identity.Dtos.Identity.Interfaces
{
    public interface IUserClaimsDto : IUserClaimDto
    {
        string UserName { get; set; }
        List<IUserClaimDto> Claims { get; }
        int TotalCount { get; set; }
        int PageSize { get; set; }
    }
}
