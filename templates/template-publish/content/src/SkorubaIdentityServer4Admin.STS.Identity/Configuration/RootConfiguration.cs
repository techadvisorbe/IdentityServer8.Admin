using Skoruba.IdentityServer8.Shared.Configuration.Configuration.Identity;
using SkorubaIdentityServer8Admin.STS.Identity.Configuration.Interfaces;

namespace SkorubaIdentityServer8Admin.STS.Identity.Configuration
{
    public class RootConfiguration : IRootConfiguration
    {      
        public AdminConfiguration AdminConfiguration { get; } = new AdminConfiguration();
        public RegisterConfiguration RegisterConfiguration { get; } = new RegisterConfiguration();
    }
}







