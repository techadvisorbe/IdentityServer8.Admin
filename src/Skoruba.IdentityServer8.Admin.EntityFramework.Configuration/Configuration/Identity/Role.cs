using System.Collections.Generic;

namespace Skoruba.IdentityServer8.Admin.EntityFramework.Configuration.Configuration.Identity
{
    public class Role
    {
        public string Name { get; set; }
        public List<Claim> Claims { get; set; } = new List<Claim>();
    }
}
