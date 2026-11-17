using System.Collections.Generic;
using IdentityServer8.EntityFramework.Entities;
using Mapster;
using TechAdvisor.IdentityServer8.Admin.BusinessLogic.Dtos.Configuration;
using TechAdvisor.IdentityServer8.Admin.BusinessLogic.Shared.Mappers;
using TechAdvisor.IdentityServer8.Admin.EntityFramework.Extensions.Common;

namespace TechAdvisor.IdentityServer8.Admin.BusinessLogic.Mappers
{
    public static class IdentityResourceMappers
    {
        internal static TypeAdapterConfig Config { get; } = MapperConfigurationFactory.Create(new IdentityResourceMapperProfile());

        public static IdentityResourceDto ToModel(this IdentityResource resource)
        {
            return resource == null ? null : resource.Adapt<IdentityResource, IdentityResourceDto>(Config);
        }

        public static IdentityResourcesDto ToModel(this PagedList<IdentityResource> resource)
        {
            return resource == null ? null : resource.Adapt<PagedList<IdentityResource>, IdentityResourcesDto>(Config);
        }

        public static List<IdentityResourceDto> ToModel(this List<IdentityResource> resource)
        {
            return resource == null ? null : resource.Adapt<List<IdentityResource>, List<IdentityResourceDto>>(Config);
        }

        public static IdentityResource ToEntity(this IdentityResourceDto resource)
        {
            return resource == null ? null : resource.Adapt<IdentityResourceDto, IdentityResource>(Config);
        }

        public static IdentityResourcePropertiesDto ToModel(this PagedList<IdentityResourceProperty> identityResourceProperties)
        {
            return identityResourceProperties.Adapt<PagedList<IdentityResourceProperty>, IdentityResourcePropertiesDto>(Config);
        }

        public static IdentityResourcePropertiesDto ToModel(this IdentityResourceProperty identityResourceProperty)
        {
            return identityResourceProperty.Adapt<IdentityResourceProperty, IdentityResourcePropertiesDto>(Config);
        }

        public static List<IdentityResource> ToEntity(this List<IdentityResourceDto> resource)
        {
            return resource == null ? null : resource.Adapt<List<IdentityResourceDto>, List<IdentityResource>>(Config);
        }

        public static IdentityResourceProperty ToEntity(this IdentityResourcePropertiesDto identityResourceProperties)
        {
            return identityResourceProperties.Adapt<IdentityResourcePropertiesDto, IdentityResourceProperty>(Config);
        }
    }
}
