using Skoruba.IdentityServer8.Shared.Configuration.Configuration.Identity;

namespace Skoruba.IdentityServer8.STS.Identity.Configuration.Interfaces
{
    public interface IRootConfiguration
    {
        AdminConfiguration AdminConfiguration { get; }

        RegisterConfiguration RegisterConfiguration { get; }
    }
}