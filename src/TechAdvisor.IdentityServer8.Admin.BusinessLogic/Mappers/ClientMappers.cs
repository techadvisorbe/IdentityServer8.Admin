using System.Collections.Generic;
using IdentityServer8.EntityFramework.Entities;
using Mapster;
using TechAdvisor.IdentityServer8.Admin.BusinessLogic.Dtos.Configuration;
using TechAdvisor.IdentityServer8.Admin.BusinessLogic.Shared.Dtos.Common;
using TechAdvisor.IdentityServer8.Admin.BusinessLogic.Shared.Mappers;
using TechAdvisor.IdentityServer8.Admin.EntityFramework.Extensions.Common;

namespace TechAdvisor.IdentityServer8.Admin.BusinessLogic.Mappers
{
    public static class ClientMappers
    {
        internal static TypeAdapterConfig Config { get; } = MapperConfigurationFactory.Create(new ClientMapperProfile());

        public static ClientDto ToModel(this Client client)
        {
            return client.Adapt<Client, ClientDto>(Config);
        }

        public static ClientSecretsDto ToModel(this PagedList<ClientSecret> clientSecret)
        {
            return clientSecret.Adapt<PagedList<ClientSecret>, ClientSecretsDto>(Config);
        }

        public static ClientClaimsDto ToModel(this PagedList<ClientClaim> clientClaims)
        {
            return clientClaims.Adapt<PagedList<ClientClaim>, ClientClaimsDto>(Config);
        }

        public static ClientsDto ToModel(this PagedList<Client> clients)
        {
            return clients.Adapt<PagedList<Client>, ClientsDto>(Config);
        }

        public static ClientPropertiesDto ToModel(this PagedList<ClientProperty> clientProperties)
        {
            return clientProperties.Adapt<PagedList<ClientProperty>, ClientPropertiesDto>(Config);
        }

        public static Client ToEntity(this ClientDto client)
        {
            return client.Adapt<ClientDto, Client>(Config);
        }

        public static ClientSecretsDto ToModel(this ClientSecret clientSecret)
        {
            return clientSecret.Adapt<ClientSecret, ClientSecretsDto>(Config);
        }

        public static ClientSecret ToEntity(this ClientSecretsDto clientSecret)
        {
            return clientSecret.Adapt<ClientSecretsDto, ClientSecret>(Config);
        }

        public static ClientClaimsDto ToModel(this ClientClaim clientClaim)
        {
            return clientClaim.Adapt<ClientClaim, ClientClaimsDto>(Config);
        }

        public static ClientPropertiesDto ToModel(this ClientProperty clientProperty)
        {
            return clientProperty.Adapt<ClientProperty, ClientPropertiesDto>(Config);
        }

        public static ClientClaim ToEntity(this ClientClaimsDto clientClaim)
        {
            return clientClaim.Adapt<ClientClaimsDto, ClientClaim>(Config);
        }

        public static ClientProperty ToEntity(this ClientPropertiesDto clientProperties)
        {
            return clientProperties.Adapt<ClientPropertiesDto, ClientProperty>(Config);
        }

        public static SelectItemDto ToModel(this SelectItem selectItem)
        {
            return selectItem.Adapt<SelectItem, SelectItemDto>(Config);
        }

        public static List<SelectItemDto> ToModel(this List<SelectItem> selectItem)
        {
            return selectItem.Adapt<List<SelectItem>, List<SelectItemDto>>(Config);
        }
    }
}
