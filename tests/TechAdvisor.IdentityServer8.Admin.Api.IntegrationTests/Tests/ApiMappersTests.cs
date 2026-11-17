using System.Collections.Generic;
using FluentAssertions;
using TechAdvisor.IdentityServer8.Admin.Api.Dtos.Clients;
using TechAdvisor.IdentityServer8.Admin.Api.Mappers;
using TechAdvisor.IdentityServer8.Admin.BusinessLogic.Dtos.Configuration;
using Xunit;

namespace TechAdvisor.IdentityServer8.Admin.Api.IntegrationTests.Tests
{
    public class ApiMappersTests
    {
        [Fact]
        public void ClientSecretIdIsMappedInBothDirections()
        {
            var apiDto = new ClientSecretsDto { ClientSecretId = 3, Value = "secret" }.ToClientApiModel<ClientSecretApiDto>();
            apiDto.Id.Should().Be(3);
            apiDto.Value.Should().Be("secret");

            var dto = new ClientSecretApiDto { Id = 4, Value = "other" }.ToClientApiModel<ClientSecretsDto>();
            dto.ClientSecretId.Should().Be(4);
            dto.Value.Should().Be("other");
        }

        [Fact]
        public void ClientIsMappedWithNestedCollections()
        {
            var clientDto = new ClientDto
            {
                ClientId = "client",
                AllowedScopes = new List<string> { "openid" },
                Claims = new List<ClientClaimDto> { new ClientClaimDto { Type = "t", Value = "v" } }
            };

            var apiDto = clientDto.ToClientApiModel<ClientApiDto>();

            apiDto.ClientId.Should().Be("client");
            apiDto.AllowedScopes.Should().BeEquivalentTo("openid");
            apiDto.Claims.Should().ContainSingle().Which.Type.Should().Be("t");

            var roundTrip = apiDto.ToClientApiModel<ClientDto>();
            roundTrip.Claims.Should().ContainSingle().Which.Value.Should().Be("v");
        }
    }
}
