using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using TechAdvisor.IdentityServer8.Admin.Api.Configuration.Test;
using TechAdvisor.IdentityServer8.Admin.Api.IntegrationTests.Common;
using TechAdvisor.IdentityServer8.Admin.Api.IntegrationTests.Tests.Base;
using Xunit;

namespace TechAdvisor.IdentityServer8.Admin.Api.IntegrationTests.Tests
{
    public class ClientsControllerTests : BaseClassFixture
    {
        public ClientsControllerTests(TestFixture fixture) : base(fixture)
        {
        }

        [Fact]
        public async Task GetClientsAsAdmin()
        {
            SetupAdminClaimsViaHeaders();

            var response = await Client.GetAsync("api/clients");

            // Assert
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task GetClientsWithoutPermissions()
        {
            Client.DefaultRequestHeaders.Clear();

            var response = await Client.GetAsync("api/clients");

            // Assert
            // Since .NET 10, cookie authentication returns 401 instead of redirecting to the login page for API endpoints
            response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
        }
    }
}
