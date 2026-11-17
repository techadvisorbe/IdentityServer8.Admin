using Mapster;
using TechAdvisor.IdentityServer8.Admin.BusinessLogic.Shared.Mappers;

namespace TechAdvisor.IdentityServer8.Admin.Api.Mappers
{
    public static class ApiScopeApiMappers
    {
        internal static TypeAdapterConfig Config { get; } = MapperConfigurationFactory.Create(new ApiScopeApiMapperProfile());

        public static T ToApiScopeApiModel<T>(this object source)
        {
            return source.Adapt<T>(Config);
        }
    }
}
