using Mapster;
using TechAdvisor.IdentityServer8.Admin.BusinessLogic.Shared.Mappers;

namespace TechAdvisor.IdentityServer8.Admin.Api.Mappers
{
    public static class PersistedGrantApiMappers
    {
        internal static TypeAdapterConfig Config { get; } = MapperConfigurationFactory.Create(new PersistedGrantApiMapperProfile());

        public static T ToPersistedGrantApiModel<T>(this object source)
        {
            return source.Adapt<T>(Config);
        }
    }
}
