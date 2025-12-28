using System.Collections.Generic;
using Skoruba.IdentityServer8.Admin.EntityFramework.Configuration.Configuration.Identity;

namespace Skoruba.IdentityServer8.Admin.EntityFramework.Configuration.Configuration
{
	public class IdentityData
    {
       public List<Role> Roles { get; set; }
       public List<User> Users { get; set; }
    }
}
