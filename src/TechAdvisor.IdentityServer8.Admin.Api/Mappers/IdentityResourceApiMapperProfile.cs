using Mapster;
using TechAdvisor.IdentityServer8.Admin.Api.Dtos.IdentityResources;
using TechAdvisor.IdentityServer8.Admin.BusinessLogic.Dtos.Configuration;

namespace TechAdvisor.IdentityServer8.Admin.Api.Mappers
{
    public class IdentityResourceApiMapperProfile : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            // Identity Resources
            config.NewConfig<IdentityResourcesDto, IdentityResourcesApiDto>()
                .TwoWays();

            config.NewConfig<IdentityResourceDto, IdentityResourceApiDto>()
                .TwoWays();

            // Identity Resources Properties
            config.NewConfig<IdentityResourcePropertiesDto, IdentityResourcePropertyApiDto>()
                .Map(dest => dest.Id, src => src.IdentityResourcePropertyId);
            config.NewConfig<IdentityResourcePropertyApiDto, IdentityResourcePropertiesDto>()
                .Map(dest => dest.IdentityResourcePropertyId, src => src.Id);

            config.NewConfig<IdentityResourcePropertyDto, IdentityResourcePropertyApiDto>();
            config.NewConfig<IdentityResourcePropertiesDto, IdentityResourcePropertiesApiDto>();
        }
    }
}
