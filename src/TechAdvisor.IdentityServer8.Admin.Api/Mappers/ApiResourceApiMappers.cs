using Mapster;
using TechAdvisor.IdentityServer8.Admin.BusinessLogic.Shared.Mappers;

namespace TechAdvisor.IdentityServer8.Admin.Api.Mappers
{
    public static class ApiResourceApiMappers
    {
        internal static TypeAdapterConfig Config { get; } = MapperConfigurationFactory.Create(new ApiResourceApiMapperProfile());

        public static T ToApiResourceApiModel<T>(this object source)
        {
            return source.Adapt<T>(Config);
        }
    }
}
