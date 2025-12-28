using System.ComponentModel.DataAnnotations;
using Skoruba.IdentityServer8.Admin.BusinessLogic.Identity.Dtos.Identity.Base;
using Skoruba.IdentityServer8.Admin.BusinessLogic.Identity.Dtos.Identity.Interfaces;

namespace Skoruba.IdentityServer8.Admin.BusinessLogic.Identity.Dtos.Identity
{
    public class RoleDto<TKey> : BaseRoleDto<TKey>, IRoleDto
    {      
        [Required]
        public string Name { get; set; }
    }
}