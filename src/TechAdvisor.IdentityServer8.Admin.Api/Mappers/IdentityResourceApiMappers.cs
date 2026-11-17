using Mapster;
using TechAdvisor.IdentityServer8.Admin.BusinessLogic.Shared.Mappers;

namespace TechAdvisor.IdentityServer8.Admin.Api.Mappers
{
    public static class IdentityResourceApiMappers
    {
        internal static TypeAdapterConfig Config { get; } = MapperConfigurationFactory.Create(new IdentityResourceApiMapperProfile());

        public static T ToIdentityResourceApiModel<T>(this object source)
        {
            return source.Adapt<T>(Config);
        }
    }
}
