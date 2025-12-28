using Skoruba.IdentityServer8.Shared.Configuration.Configuration.Identity;

namespace SkorubaIdentityServer8Admin.STS.Identity.Configuration.Interfaces
{
    public interface IRootConfiguration
    {
        AdminConfiguration AdminConfiguration { get; }

        RegisterConfiguration RegisterConfiguration { get; }
    }
}







