using Mapster;
using TechAdvisor.IdentityServer8.Admin.BusinessLogic.Shared.Mappers;

namespace TechAdvisor.IdentityServer8.Admin.Api.Mappers
{
    public static class ClientApiMappers
    {
        internal static TypeAdapterConfig Config { get; } = MapperConfigurationFactory.Create(new ClientApiMapperProfile());

        public static T ToClientApiModel<T>(this object source)
        {
            return source.Adapt<T>(Config);
        }
    }
}
