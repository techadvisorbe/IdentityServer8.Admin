// Based on the IdentityServer8.EntityFramework - authors - Brock Allen & Dominick Baier.
// https://github.com/IdentityServer/IdentityServer8.EntityFramework

// Modified by Jan Škoruba , Abdelilah El mansouri

using System.Collections.Generic;
using System.Linq;
using IdentityServer8.EntityFramework.Entities;
using Mapster;
using TechAdvisor.IdentityServer8.Admin.BusinessLogic.Dtos.Configuration;
using TechAdvisor.IdentityServer8.Admin.BusinessLogic.Mappers.Converters;
using TechAdvisor.IdentityServer8.Admin.EntityFramework.Extensions.Common;

namespace TechAdvisor.IdentityServer8.Admin.BusinessLogic.Mappers
{
    public class ApiResourceMapperProfile : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            // entity to model
            config.NewConfig<ApiResource, ApiResourceDto>()
                .Map(dest => dest.UserClaims, src => src.UserClaims != null ? src.UserClaims.Select(x => x.Type).ToList() : new List<string>())
                .Map(dest => dest.Scopes, src => src.Scopes != null ? src.Scopes.Select(x => x.Scope).ToList() : new List<string>())
                .Map(dest => dest.AllowedAccessTokenSigningAlgorithms,
                    src => AllowedSigningAlgorithmsConverter.Converter.Convert(src.AllowedAccessTokenSigningAlgorithms));

            config.NewConfig<ApiResourceSecret, ApiSecretsDto>()
                .Map(dest => dest.ApiSecretId, src => src.Id)
                .Map(dest => dest.ApiResourceId, src => src.ApiResource != null ? src.ApiResource.Id : 0);

            config.NewConfig<ApiResourceSecret, ApiSecretDto>();

            config.NewConfig<ApiResourceProperty, ApiResourcePropertyDto>()
                .TwoWays();

            config.NewConfig<ApiResourceProperty, ApiResourcePropertiesDto>()
                .Map(dest => dest.ApiResourcePropertyId, src => src.Id)
                .Map(dest => dest.ApiResourceId, src => src.ApiResource != null ? src.ApiResource.Id : 0);

            //PagedLists
            config.NewConfig<PagedList<ApiResource>, ApiResourcesDto>()
                .Map(dest => dest.ApiResources, src => src.Data);

            config.NewConfig<PagedList<ApiResourceSecret>, ApiSecretsDto>()
                .Map(dest => dest.ApiSecrets, src => src.Data);

            config.NewConfig<PagedList<ApiResourceProperty>, ApiResourcePropertiesDto>()
                .Map(dest => dest.ApiResourceProperties, src => src.Data);

            // model to entity
            config.NewConfig<ApiResourceDto, ApiResource>()
                .Map(dest => dest.UserClaims, src => src.UserClaims != null ? src.UserClaims.Select(x => new ApiResourceClaim { Type = x }).ToList() : new List<ApiResourceClaim>())
                .Map(dest => dest.Scopes, src => src.Scopes != null ? src.Scopes.Select(x => new ApiResourceScope { Scope = x }).ToList() : new List<ApiResourceScope>())
                .Map(dest => dest.AllowedAccessTokenSigningAlgorithms,
                    src => AllowedSigningAlgorithmsConverter.Converter.Convert(src.AllowedAccessTokenSigningAlgorithms));

            config.NewConfig<ApiSecretsDto, ApiResourceSecret>()
                .Map(dest => dest.ApiResource, src => new ApiResource { Id = src.ApiResourceId })
                .Map(dest => dest.Id, src => src.ApiSecretId);

            config.NewConfig<ApiResourcePropertiesDto, ApiResourceProperty>()
                .Map(dest => dest.ApiResource, src => new ApiResource { Id = src.ApiResourceId })
                .Map(dest => dest.Id, src => src.ApiResourcePropertyId);
        }
    }
}
