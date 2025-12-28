using System.Collections.Generic;
using Skoruba.IdentityServer8.Admin.EntityFramework.Configuration.Configuration.Identity;

namespace Skoruba.IdentityServer8.Admin.EntityFramework.Configuration.Configuration.IdentityServer
{
    public class Client : global::IdentityServer8.Models.Client
    {
        public List<Claim> ClientClaims { get; set; } = new List<Claim>();
    }
}
