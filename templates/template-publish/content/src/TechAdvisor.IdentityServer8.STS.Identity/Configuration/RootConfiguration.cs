using TechAdvisor.IdentityServer8.Shared.Configuration.Configuration.Identity;
using TechAdvisor.IdentityServer8.STS.Identity.Configuration.Interfaces;

namespace TechAdvisor.IdentityServer8.STS.Identity.Configuration
{
    public class RootConfiguration : IRootConfiguration
    {      
        public AdminConfiguration AdminConfiguration { get; } = new AdminConfiguration();
        public RegisterConfiguration RegisterConfiguration { get; } = new RegisterConfiguration();
    }
}