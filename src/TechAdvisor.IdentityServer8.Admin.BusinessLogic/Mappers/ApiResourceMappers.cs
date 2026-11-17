using IdentityServer8.EntityFramework.Entities;
using Mapster;
using TechAdvisor.IdentityServer8.Admin.BusinessLogic.Dtos.Configuration;
using TechAdvisor.IdentityServer8.Admin.BusinessLogic.Shared.Mappers;
using TechAdvisor.IdentityServer8.Admin.EntityFramework.Extensions.Common;

namespace TechAdvisor.IdentityServer8.Admin.BusinessLogic.Mappers
{
    public static class ApiResourceMappers
    {
        internal static TypeAdapterConfig Config { get; } = MapperConfigurationFactory.Create(new ApiResourceMapperProfile());

        public static ApiResourceDto ToModel(this ApiResource resource)
        {
            return resource == null ? null : resource.Adapt<ApiResource, ApiResourceDto>(Config);
        }

        public static ApiResourcesDto ToModel(this PagedList<ApiResource> resources)
        {
            return resources == null ? null : resources.Adapt<PagedList<ApiResource>, ApiResourcesDto>(Config);
        }

        public static ApiResourcePropertiesDto ToModel(this PagedList<ApiResourceProperty> apiResourceProperties)
        {
            return apiResourceProperties.Adapt<PagedList<ApiResourceProperty>, ApiResourcePropertiesDto>(Config);
        }

        public static ApiResourcePropertiesDto ToModel(this ApiResourceProperty apiResourceProperty)
        {
            return apiResourceProperty.Adapt<ApiResourceProperty, ApiResourcePropertiesDto>(Config);
        }

        public static ApiSecretsDto ToModel(this PagedList<ApiResourceSecret> secrets)
        {
            return secrets == null ? null : secrets.Adapt<PagedList<ApiResourceSecret>, ApiSecretsDto>(Config);
        }

        public static ApiSecretsDto ToModel(this ApiResourceSecret resource)
        {
            return resource == null ? null : resource.Adapt<ApiResourceSecret, ApiSecretsDto>(Config);
        }

        public static ApiResource ToEntity(this ApiResourceDto resource)
        {
            return resource == null ? null : resource.Adapt<ApiResourceDto, ApiResource>(Config);
        }

        public static ApiResourceSecret ToEntity(this ApiSecretsDto resource)
        {
            return resource == null ? null : resource.Adapt<ApiSecretsDto, ApiResourceSecret>(Config);
        }

        public static ApiResourceProperty ToEntity(this ApiResourcePropertiesDto apiResourceProperties)
        {
            return apiResourceProperties.Adapt<ApiResourcePropertiesDto, ApiResourceProperty>(Config);
        }
    }
}
