using System.Collections.Generic;
using FluentAssertions;
using IdentityServer8.EntityFramework.Entities;
using MapsterMapper;
using Microsoft.AspNetCore.Identity;
using TechAdvisor.IdentityServer8.Admin.BusinessLogic.Identity.Dtos.Identity;
using TechAdvisor.IdentityServer8.Admin.BusinessLogic.Identity.Mappers;
using TechAdvisor.IdentityServer8.Admin.BusinessLogic.Mappers;
using TechAdvisor.IdentityServer8.Admin.BusinessLogic.Shared.ExceptionHandling;
using TechAdvisor.IdentityServer8.Admin.BusinessLogic.Shared.Mappers;
using TechAdvisor.IdentityServer8.Admin.EntityFramework.Extensions.Common;
using TechAdvisor.IdentityServer8.Admin.EntityFramework.Shared.Entities.Identity;
using Xunit;

namespace TechAdvisor.IdentityServer8.Admin.UnitTests.Mappers
{
    /// <summary>
    /// Covers mapping conventions that the views and services depend on (null handling, flattening, identity keys)
    /// </summary>
    public class MappingBehaviorTests
    {
        [Fact]
        public void NullNavigationsAndCollectionsAreMappedSafely()
        {
            var apiResource = new ApiResource { Id = 1, Name = "api", UserClaims = null, Scopes = null };

            var apiResourceDto = apiResource.ToModel();

            apiResourceDto.UserClaims.Should().NotBeNull().And.BeEmpty();
            apiResourceDto.Scopes.Should().NotBeNull().And.BeEmpty();
            apiResourceDto.AllowedAccessTokenSigningAlgorithms.Should().NotBeNull().And.BeEmpty();

            var clientSecret = new ClientSecret { Id = 5, Client = null };
            var clientSecretsDto = clientSecret.ToModel();

            clientSecretsDto.ClientSecretId.Should().Be(5);
            clientSecretsDto.ClientId.Should().Be(0);
        }

        [Fact]
        public void EmptyPagedListIsMappedWithPagingInfo()
        {
            var pagedList = new PagedList<Client> { TotalCount = 3, PageSize = 10 };

            var clientsDto = pagedList.ToModel();

            clientsDto.Clients.Should().NotBeNull().And.BeEmpty();
            clientsDto.TotalCount.Should().Be(3);
            clientsDto.PageSize.Should().Be(10);
        }

        [Fact]
        public void ParentNameIsFlattenedIntoDto()
        {
            var secret = new ApiResourceSecret { Id = 2, ApiResource = new ApiResource { Id = 7, Name = "orders" } };

            var secretsDto = secret.ToModel();

            secretsDto.ApiSecretId.Should().Be(2);
            secretsDto.ApiResourceId.Should().Be(7);
            secretsDto.ApiResourceName.Should().Be("orders");
        }

        [Fact]
        public void NullStringsStayNull()
        {
            var client = new Client { ClientId = "client", Description = null };

            client.ToModel().Description.Should().BeNull();
        }

        [Fact]
        public void IdentityMappingKeepsGeneratedIdWhenDtoHasNone()
        {
            var mapper = GetIdentityMapper();

            var user = mapper.Map<UserIdentity>(new UserDto<string> { Id = null, UserName = "bob" });
            var role = mapper.Map<UserIdentityRole>(new RoleDto<string> { Id = null, Name = "admin" });

            user.Id.Should().NotBeNullOrEmpty();
            user.UserName.Should().Be("bob");
            role.Id.Should().NotBeNullOrEmpty();
            role.Name.Should().Be("admin");

            mapper.Map<UserIdentity>(new UserDto<string> { Id = "42" }).Id.Should().Be("42");
        }

        [Fact]
        public void IdentityMappingOntoExistingUserPreservesSecurityStamp()
        {
            var mapper = GetIdentityMapper();
            var existing = new UserIdentity { Id = "1", UserName = "old", SecurityStamp = "stamp" };

            mapper.Map(new UserIdentity { Id = "1", UserName = "new", SecurityStamp = null }, existing);

            existing.UserName.Should().Be("new");
            existing.SecurityStamp.Should().Be("stamp");
        }

        [Fact]
        public void IdentityMappingMapsErrorsAndProviders()
        {
            var mapper = GetIdentityMapper();

            var errors = mapper.Map<List<ViewErrorMessage>>(new[] { new IdentityError { Code = "code", Description = "desc" } });
            errors.Should().ContainSingle().Which.Should().BeEquivalentTo(new ViewErrorMessage { ErrorKey = "code", ErrorMessage = "desc" });

            var providers = mapper.Map<UserProvidersDto<UserProviderDto<string>, string>>(new List<UserLoginInfo> { new UserLoginInfo("Google", "key", "Google") });
            providers.Providers.Should().ContainSingle().Which.LoginProvider.Should().Be("Google");
        }

        private static IMapper GetIdentityMapper()
        {
            return new Mapper(MapperConfigurationFactory.Create(new IdentityMapperProfile<UserDto<string>, RoleDto<string>, UserIdentity, UserIdentityRole, string,
                UserIdentityUserClaim, UserIdentityUserRole, UserIdentityUserLogin, UserIdentityRoleClaim, UserIdentityUserToken,
                UsersDto<UserDto<string>, string>, RolesDto<RoleDto<string>, string>, UserRolesDto<RoleDto<string>, string>,
                UserClaimsDto<UserClaimDto<string>, string>, UserProviderDto<string>, UserProvidersDto<UserProviderDto<string>, string>,
                RoleClaimsDto<RoleClaimDto<string>, string>, UserClaimDto<string>, RoleClaimDto<string>>()));
        }
    }
}
