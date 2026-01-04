using TechAdvisor.IdentityServer8.Shared.Configuration.Configuration.Identity;

namespace TechAdvisor.IdentityServer8.STS.Identity.Configuration.Interfaces
{
    public interface IRootConfiguration
    {
        AdminConfiguration AdminConfiguration { get; }

        RegisterConfiguration RegisterConfiguration { get; }
    }
}