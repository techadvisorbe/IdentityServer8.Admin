using System.Collections.Generic;

namespace SkorubaIdentityServer8Admin.Admin.Api.Dtos.Clients
{
    public class ClientSecretsApiDto
    {
        public ClientSecretsApiDto()
        {
            ClientSecrets = new List<ClientSecretApiDto>();
        }

        public int TotalCount { get; set; }

        public int PageSize { get; set; }

        public List<ClientSecretApiDto> ClientSecrets { get; set; }
    }
}







