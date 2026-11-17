// Based on the IdentityServer8.EntityFramework - authors - Brock Allen & Dominick Baier.
// https://github.com/IdentityServer/IdentityServer8.EntityFramework

// Modified by Jan Škoruba , Abdelilah El mansouri

using IdentityServer8.EntityFramework.Entities;
using Mapster;
using TechAdvisor.IdentityServer8.Admin.BusinessLogic.Dtos.Configuration;
using TechAdvisor.IdentityServer8.Admin.BusinessLogic.Mappers.Converters;
using TechAdvisor.IdentityServer8.Admin.BusinessLogic.Shared.Dtos.Common;
using TechAdvisor.IdentityServer8.Admin.EntityFramework.Extensions.Common;

namespace TechAdvisor.IdentityServer8.Admin.BusinessLogic.Mappers
{
    public class ClientMapperProfile : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            // entity to model
            config.NewConfig<Client, ClientDto>()
                .Map(dest => dest.AllowedIdentityTokenSigningAlgorithms,
                    src => AllowedSigningAlgorithmsConverter.Converter.Convert(src.AllowedIdentityTokenSigningAlgorithms));

            config.NewConfig<ClientDto, Client>()
                .Map(dest => dest.AllowedIdentityTokenSigningAlgorithms,
                    src => AllowedSigningAlgorithmsConverter.Converter.Convert(src.AllowedIdentityTokenSigningAlgorithms));

            config.NewConfig<SelectItem, SelectItemDto>()
                .TwoWays();

            // Child collections of the client are flattened to a list of strings
            config.NewConfig<ClientGrantType, string>()
                .MapWith(src => src.GrantType);
            config.NewConfig<string, ClientGrantType>()
                .MapWith(src => new ClientGrantType { GrantType = src });

            config.NewConfig<ClientRedirectUri, string>()
                .MapWith(src => src.RedirectUri);
            config.NewConfig<string, ClientRedirectUri>()
                .MapWith(src => new ClientRedirectUri { RedirectUri = src });

            config.NewConfig<ClientPostLogoutRedirectUri, string>()
                .MapWith(src => src.PostLogoutRedirectUri);
            config.NewConfig<string, ClientPostLogoutRedirectUri>()
                .MapWith(src => new ClientPostLogoutRedirectUri { PostLogoutRedirectUri = src });

            config.NewConfig<ClientScope, string>()
                .MapWith(src => src.Scope);
            config.NewConfig<string, ClientScope>()
                .MapWith(src => new ClientScope { Scope = src });

            config.NewConfig<ClientIdPRestriction, string>()
                .MapWith(src => src.Provider);
            config.NewConfig<string, ClientIdPRestriction>()
                .MapWith(src => new ClientIdPRestriction { Provider = src });

            config.NewConfig<ClientCorsOrigin, string>()
                .MapWith(src => src.Origin);
            config.NewConfig<string, ClientCorsOrigin>()
                .MapWith(src => new ClientCorsOrigin { Origin = src });

            config.NewConfig<ClientSecret, ClientSecretDto>()
                .TwoWays();

            config.NewConfig<ClientClaim, ClientClaimDto>()
                .TwoWays();

            config.NewConfig<ClientProperty, ClientPropertyDto>()
                .TwoWays();

            config.NewConfig<ClientSecret, ClientSecretsDto>()
                .Map(dest => dest.ClientSecretId, src => src.Id)
                .Map(dest => dest.ClientId, src => src.Client != null ? src.Client.Id : 0);

            config.NewConfig<ClientClaim, ClientClaimsDto>()
                .Map(dest => dest.ClientClaimId, src => src.Id)
                .Map(dest => dest.ClientId, src => src.Client != null ? src.Client.Id : 0);

            config.NewConfig<ClientProperty, ClientPropertiesDto>()
                .Map(dest => dest.ClientPropertyId, src => src.Id)
                .Map(dest => dest.ClientId, src => src.Client != null ? src.Client.Id : 0);

            //PagedLists
            config.NewConfig<PagedList<ClientSecret>, ClientSecretsDto>()
                .Map(dest => dest.ClientSecrets, src => src.Data);

            config.NewConfig<PagedList<ClientClaim>, ClientClaimsDto>()
                .Map(dest => dest.ClientClaims, src => src.Data);

            config.NewConfig<PagedList<ClientProperty>, ClientPropertiesDto>()
                .Map(dest => dest.ClientProperties, src => src.Data);

            config.NewConfig<PagedList<Client>, ClientsDto>()
                .Map(dest => dest.Clients, src => src.Data);

            // model to entity
            config.NewConfig<ClientSecretsDto, ClientSecret>()
                .Map(dest => dest.Client, src => new Client { Id = src.ClientId })
                .Map(dest => dest.Id, src => src.ClientSecretId);

            config.NewConfig<ClientClaimsDto, ClientClaim>()
                .Map(dest => dest.Client, src => new Client { Id = src.ClientId })
                .Map(dest => dest.Id, src => src.ClientClaimId);

            config.NewConfig<ClientPropertiesDto, ClientProperty>()
                .Map(dest => dest.Client, src => new Client { Id = src.ClientId })
                .Map(dest => dest.Id, src => src.ClientPropertyId);
        }
    }
}
