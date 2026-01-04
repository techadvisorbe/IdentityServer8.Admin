using System.Collections.Generic;
using TechAdvisor.IdentityServer8.Admin.EntityFramework.Configuration.Configuration.Identity;

namespace TechAdvisor.IdentityServer8.Admin.EntityFramework.Configuration.Configuration
{
	public class IdentityData
    {
       public List<Role> Roles { get; set; }
       public List<User> Users { get; set; }
    }
}
