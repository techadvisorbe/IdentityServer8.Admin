using Mapster;
using TechAdvisor.IdentityServer8.Admin.Api.Dtos.Roles;
using TechAdvisor.IdentityServer8.Admin.Api.Dtos.Users;
using TechAdvisor.IdentityServer8.Admin.BusinessLogic.Identity.Dtos.Identity;

namespace TechAdvisor.IdentityServer8.Admin.Api.Mappers
{
    public class IdentityMapperProfile<TRoleDto, TUserRolesDto, TKey, TUserClaimsDto, TUserClaimDto, TUserProviderDto, TUserProvidersDto, TUserChangePasswordDto, TRoleClaimDto, TRoleClaimsDto> : IRegister
        where TUserClaimsDto : UserClaimsDto<TUserClaimDto, TKey>
        where TUserClaimDto : UserClaimDto<TKey>
        where TRoleDto : RoleDto<TKey>
        where TUserRolesDto : UserRolesDto<TRoleDto, TKey>
        where TUserProviderDto : UserProviderDto<TKey>
        where TUserProvidersDto : UserProvidersDto<TUserProviderDto,TKey>
        where TUserChangePasswordDto : UserChangePasswordDto<TKey>
        where TRoleClaimsDto : RoleClaimsDto<TRoleClaimDto, TKey>
        where TRoleClaimDto : RoleClaimDto<TKey>
    {
        public void Register(TypeAdapterConfig config)
        {
            // entity to model
            config.NewConfig<TUserClaimsDto, UserClaimsApiDto<TKey>>();
            config.NewConfig<TUserClaimsDto, UserClaimApiDto<TKey>>();

            config.NewConfig<UserClaimApiDto<TKey>, TUserClaimsDto>();
            config.NewConfig<TUserClaimDto, UserClaimApiDto<TKey>>();

            config.NewConfig<TUserRolesDto, UserRolesApiDto<TRoleDto>>();
            config.NewConfig<UserRoleApiDto<TKey>, TUserRolesDto>();

            config.NewConfig<TUserProviderDto, UserProviderApiDto<TKey>>();
            config.NewConfig<TUserProvidersDto, UserProvidersApiDto<TKey>>();
            config.NewConfig<UserProviderDeleteApiDto<TKey>, TUserProviderDto>();

            config.NewConfig<UserChangePasswordApiDto<TKey>, TUserChangePasswordDto>();

            config.NewConfig<RoleClaimsApiDto<TKey>, TRoleClaimsDto>();
            config.NewConfig<RoleClaimApiDto<TKey>, TRoleClaimDto>();
            config.NewConfig<RoleClaimApiDto<TKey>, TRoleClaimsDto>();

            config.NewConfig<TRoleClaimsDto, RoleClaimsApiDto<TKey>>();
            config.NewConfig<TRoleClaimDto, RoleClaimApiDto<TKey>>();
            config.NewConfig<TRoleClaimsDto, RoleClaimApiDto<TKey>>();
        }
    }
}
