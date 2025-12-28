using Skoruba.IdentityServer8.Shared.Configuration.Configuration.Identity;
using Skoruba.IdentityServer8.STS.Identity.Configuration.Interfaces;

namespace Skoruba.IdentityServer8.STS.Identity.Configuration
{
    public class RootConfiguration : IRootConfiguration
    {      
        public AdminConfiguration AdminConfiguration { get; } = new AdminConfiguration();
        public RegisterConfiguration RegisterConfiguration { get; } = new RegisterConfiguration();
    }
}