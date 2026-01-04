using System.ComponentModel.DataAnnotations;
using TechAdvisor.IdentityServer8.Admin.BusinessLogic.Identity.Dtos.Identity.Base;
using TechAdvisor.IdentityServer8.Admin.BusinessLogic.Identity.Dtos.Identity.Interfaces;

namespace TechAdvisor.IdentityServer8.Admin.BusinessLogic.Identity.Dtos.Identity
{
    public class RoleDto<TKey> : BaseRoleDto<TKey>, IRoleDto
    {      
        [Required]
        public string Name { get; set; }
    }
}