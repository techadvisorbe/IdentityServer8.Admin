using Mapster;
using TechAdvisor.IdentityServer8.Admin.Api.Dtos.ApiResources;
using TechAdvisor.IdentityServer8.Admin.BusinessLogic.Dtos.Configuration;

namespace TechAdvisor.IdentityServer8.Admin.Api.Mappers
{
    public class ApiResourceApiMapperProfile : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            // Api Resources
            config.NewConfig<ApiResourcesDto, ApiResourcesApiDto>()
                .TwoWays();

            config.NewConfig<ApiResourceDto, ApiResourceApiDto>()
                .TwoWays();

            // Api Secrets
            config.NewConfig<ApiSecretsDto, ApiSecretApiDto>()
                .Map(dest => dest.Id, src => src.ApiSecretId);
            config.NewConfig<ApiSecretApiDto, ApiSecretsDto>()
                .Map(dest => dest.ApiSecretId, src => src.Id);

            config.NewConfig<ApiSecretDto, ApiSecretApiDto>();
            config.NewConfig<ApiSecretsDto, ApiSecretsApiDto>();

            // Api Properties
            config.NewConfig<ApiResourcePropertiesDto, ApiResourcePropertyApiDto>()
                .Map(dest => dest.Id, src => src.ApiResourcePropertyId);
            config.NewConfig<ApiResourcePropertyApiDto, ApiResourcePropertiesDto>()
                .Map(dest => dest.ApiResourcePropertyId, src => src.Id);

            config.NewConfig<ApiResourcePropertyDto, ApiResourcePropertyApiDto>();
            config.NewConfig<ApiResourcePropertiesDto, ApiResourcePropertiesApiDto>();
        }
    }
}
