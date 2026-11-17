using Mapster;
using TechAdvisor.IdentityServer8.Admin.Api.Dtos.Clients;
using TechAdvisor.IdentityServer8.Admin.BusinessLogic.Dtos.Configuration;

namespace TechAdvisor.IdentityServer8.Admin.Api.Mappers
{
    public class ClientApiMapperProfile : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            // Client
            config.NewConfig<ClientDto, ClientApiDto>()
                .TwoWays();

            config.NewConfig<ClientsDto, ClientsApiDto>()
                .TwoWays();

            config.NewConfig<ClientCloneApiDto, ClientCloneDto>()
                .TwoWays();

            // Client Secrets
            config.NewConfig<ClientSecretsDto, ClientSecretApiDto>()
                .Map(dest => dest.Id, src => src.ClientSecretId);
            config.NewConfig<ClientSecretApiDto, ClientSecretsDto>()
                .Map(dest => dest.ClientSecretId, src => src.Id);

            config.NewConfig<ClientSecretDto, ClientSecretApiDto>()
                .TwoWays();

            config.NewConfig<ClientSecretsDto, ClientSecretsApiDto>();

            // Client Properties
            config.NewConfig<ClientPropertiesDto, ClientPropertyApiDto>()
                .Map(dest => dest.Id, src => src.ClientPropertyId);
            config.NewConfig<ClientPropertyApiDto, ClientPropertiesDto>()
                .Map(dest => dest.ClientPropertyId, src => src.Id);

            config.NewConfig<ClientPropertyDto, ClientPropertyApiDto>()
                .TwoWays();

            config.NewConfig<ClientPropertiesDto, ClientPropertiesApiDto>();

            // Client Claims
            config.NewConfig<ClientClaimsDto, ClientClaimApiDto>()
                .Map(dest => dest.Id, src => src.ClientClaimId);
            config.NewConfig<ClientClaimApiDto, ClientClaimsDto>()
                .Map(dest => dest.ClientClaimId, src => src.Id);

            config.NewConfig<ClientClaimDto, ClientClaimApiDto>()
                .TwoWays();

            config.NewConfig<ClientClaimsDto, ClientClaimsApiDto>();
        }
    }
}
