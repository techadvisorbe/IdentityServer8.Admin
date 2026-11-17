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
    public class ApiScopeMapperProfile : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            // entity to model
            config.NewConfig<ApiScope, ApiScopeDto>()
                .Map(dest => dest.UserClaims, src => src.UserClaims != null ? src.UserClaims.Select(x => x.Type).ToList() : new List<string>());

            config.NewConfig<ApiScopeProperty, ApiScopePropertyDto>()
                .TwoWays();

            config.NewConfig<ApiScopeProperty, ApiScopePropertiesDto>()
                .Map(dest => dest.ApiScopePropertyId, src => src.Id)
                .Map(dest => dest.ApiScopeId, src => src.Scope != null ? src.Scope.Id : 0);

            // PagedLists
            config.NewConfig<PagedList<ApiScope>, ApiScopesDto>()
                .Map(dest => dest.Scopes, src => src.Data);

            config.NewConfig<PagedList<ApiScopeProperty>, ApiScopePropertiesDto>()
                .Map(dest => dest.ApiScopeProperties, src => src.Data);

            // model to entity
            config.NewConfig<ApiScopeDto, ApiScope>()
                .Map(dest => dest.UserClaims, src => src.UserClaims != null ? src.UserClaims.Select(x => new ApiScopeClaim { Type = x }).ToList() : new List<ApiScopeClaim>());

            config.NewConfig<ApiScopePropertiesDto, ApiScopeProperty>()
                .Map(dest => dest.Scope, src => new ApiScope { Id = src.ApiScopeId })
                .Map(dest => dest.ScopeId, src => src.ApiScopeId)
                .Map(dest => dest.Id, src => src.ApiScopePropertyId);
        }
    }
}
