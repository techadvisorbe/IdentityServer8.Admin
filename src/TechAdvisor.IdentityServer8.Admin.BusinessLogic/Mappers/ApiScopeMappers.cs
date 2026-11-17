using IdentityServer8.EntityFramework.Entities;
using Mapster;
using TechAdvisor.IdentityServer8.Admin.BusinessLogic.Dtos.Configuration;
using TechAdvisor.IdentityServer8.Admin.BusinessLogic.Shared.Mappers;
using TechAdvisor.IdentityServer8.Admin.EntityFramework.Extensions.Common;

namespace TechAdvisor.IdentityServer8.Admin.BusinessLogic.Mappers
{
    public static class ApiScopeMappers
    {
        internal static TypeAdapterConfig Config { get; } = MapperConfigurationFactory.Create(new ApiScopeMapperProfile());

        public static ApiScopesDto ToModel(this PagedList<ApiScope> scopes)
        {
            return scopes == null ? null : scopes.Adapt<PagedList<ApiScope>, ApiScopesDto>(Config);
        }

        public static ApiScopeDto ToModel(this ApiScope resource)
        {
            return resource == null ? null : resource.Adapt<ApiScope, ApiScopeDto>(Config);
        }

        public static ApiScope ToEntity(this ApiScopeDto resource)
        {
            return resource == null ? null : resource.Adapt<ApiScopeDto, ApiScope>(Config);
        }

        public static ApiScopeProperty ToEntity(this ApiScopePropertiesDto resource)
        {
            return resource == null ? null : resource.Adapt<ApiScopePropertiesDto, ApiScopeProperty>(Config);
        }

        public static ApiScopePropertiesDto ToModel(this PagedList<ApiScopeProperty> scope)
        {
            return scope == null ? null : scope.Adapt<PagedList<ApiScopeProperty>, ApiScopePropertiesDto>(Config);
        }

        public static ApiScopePropertiesDto ToModel(this ApiScopeProperty scope)
        {
            return scope == null ? null : scope.Adapt<ApiScopeProperty, ApiScopePropertiesDto>(Config);
        }
    }
}
