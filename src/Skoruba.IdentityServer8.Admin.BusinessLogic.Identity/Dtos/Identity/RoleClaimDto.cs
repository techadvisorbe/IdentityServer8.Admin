using System.ComponentModel.DataAnnotations;
using Skoruba.IdentityServer8.Admin.BusinessLogic.Identity.Dtos.Identity.Base;
using Skoruba.IdentityServer8.Admin.BusinessLogic.Identity.Dtos.Identity.Interfaces;

namespace Skoruba.IdentityServer8.Admin.BusinessLogic.Identity.Dtos.Identity
{
    public class RoleClaimDto<TKey> : BaseRoleClaimDto<TKey>, IRoleClaimDto
    {
        [Required]
        public string ClaimType { get; set; }


        [Required]
        public string ClaimValue { get; set; }
    }
}
