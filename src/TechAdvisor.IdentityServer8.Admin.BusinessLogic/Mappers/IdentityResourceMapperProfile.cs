// Based on the IdentityServer8.EntityFramework - authors - Brock Allen & Dominick Baier.
// https://github.com/IdentityServer/IdentityServer8.EntityFramework

// Modified by Jan Škoruba , Abdelilah El mansouri

using System.Collections.Generic;
using System.Linq;
using IdentityServer8.EntityFramework.Entities;
using Mapster;
using TechAdvisor.IdentityServer8.Admin.BusinessLogic.Dtos.Configuration;
using TechAdvisor.IdentityServer8.Admin.EntityFramework.Extensions.Common;

namespace TechAdvisor.IdentityServer8.Admin.BusinessLogic.Mappers
{
    public class IdentityResourceMapperProfile : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            // entity to model
            config.NewConfig<IdentityResource, IdentityResourceDto>()
                .Map(dest => dest.UserClaims, src => src.UserClaims != null ? src.UserClaims.Select(x => x.Type).ToList() : new List<string>());

            config.NewConfig<IdentityResourceProperty, IdentityResourcePropertyDto>()
                .TwoWays();

            config.NewConfig<IdentityResourceProperty, IdentityResourcePropertiesDto>()
                .Map(dest => dest.IdentityResourcePropertyId, src => src.Id)
                .Map(dest => dest.IdentityResourceId, src => src.IdentityResource != null ? src.IdentityResource.Id : 0);

            config.NewConfig<PagedList<IdentityResource>, IdentityResourcesDto>()
                .Map(dest => dest.IdentityResources, src => src.Data);

            config.NewConfig<PagedList<IdentityResourceProperty>, IdentityResourcePropertiesDto>()
                .Map(dest => dest.IdentityResourceProperties, src => src.Data);

            // model to entity
            config.NewConfig<IdentityResourceDto, IdentityResource>()
                .Map(dest => dest.UserClaims, src => src.UserClaims != null ? src.UserClaims.Select(x => new IdentityResourceClaim { Type = x }).ToList() : new List<IdentityResourceClaim>());

            config.NewConfig<IdentityResourcePropertiesDto, IdentityResourceProperty>()
                .Map(dest => dest.IdentityResource, src => new IdentityResource { Id = src.IdentityResourceId })
                .Map(dest => dest.Id, src => src.IdentityResourcePropertyId);
        }
    }
}
