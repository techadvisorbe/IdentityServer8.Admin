using Mapster;
using TechAdvisor.IdentityServer8.Admin.Api.Dtos.ApiScopes;
using TechAdvisor.IdentityServer8.Admin.BusinessLogic.Dtos.Configuration;

namespace TechAdvisor.IdentityServer8.Admin.Api.Mappers
{
    public class ApiScopeApiMapperProfile : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            // Api Scopes
            config.NewConfig<ApiScopesDto, ApiScopesApiDto>()
                .TwoWays();

            config.NewConfig<ApiScopeDto, ApiScopeApiDto>()
                .TwoWays();

            // Api Scope Properties
            config.NewConfig<ApiScopePropertiesDto, ApiScopePropertiesApiDto>()
                .TwoWays();

            config.NewConfig<ApiScopePropertyDto, ApiScopePropertyApiDto>()
                .TwoWays();

            config.NewConfig<ApiScopePropertiesDto, ApiScopePropertyApiDto>()
                .Map(dest => dest.Id, src => src.ApiScopePropertyId);
            config.NewConfig<ApiScopePropertyApiDto, ApiScopePropertiesDto>()
                .Map(dest => dest.ApiScopePropertyId, src => src.Id);
        }
    }
}
