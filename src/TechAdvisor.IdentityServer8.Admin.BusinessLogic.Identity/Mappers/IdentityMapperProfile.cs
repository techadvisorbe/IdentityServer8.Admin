// Based on the IdentityServer8.EntityFramework - authors - Brock Allen & Dominick Baier.
// https://github.com/IdentityServer/IdentityServer8.EntityFramework

// Modified by Jan Škoruba , Abdelilah El mansouri

using System;
using System.Collections.Generic;
using Mapster;
using Microsoft.AspNetCore.Identity;
using TechAdvisor.IdentityServer8.Admin.BusinessLogic.Identity.Dtos.Identity;
using TechAdvisor.IdentityServer8.Admin.BusinessLogic.Shared.ExceptionHandling;
using TechAdvisor.IdentityServer8.Admin.EntityFramework.Extensions.Common;

namespace TechAdvisor.IdentityServer8.Admin.BusinessLogic.Identity.Mappers
{
    public class IdentityMapperProfile<TUserDto, TRoleDto, TUser, TRole, TKey, TUserClaim, TUserRole,
        TUserLogin, TRoleClaim, TUserToken,
        TUsersDto, TRolesDto, TUserRolesDto, TUserClaimsDto,
        TUserProviderDto, TUserProvidersDto, TRoleClaimsDto,
        TUserClaimDto, TRoleClaimDto>
        : IRegister
        where TUserDto : UserDto<TKey>
        where TRoleDto : RoleDto<TKey>
        where TUser : IdentityUser<TKey>
        where TRole : IdentityRole<TKey>
        where TKey : IEquatable<TKey>
        where TUserClaim : IdentityUserClaim<TKey>
        where TUserRole : IdentityUserRole<TKey>
        where TUserLogin : IdentityUserLogin<TKey>
        where TRoleClaim : IdentityRoleClaim<TKey>
        where TUserToken : IdentityUserToken<TKey>
        where TUsersDto : UsersDto<TUserDto, TKey>
        where TRolesDto : RolesDto<TRoleDto, TKey>
        where TUserRolesDto : UserRolesDto<TRoleDto, TKey>
        where TUserClaimsDto : UserClaimsDto<TUserClaimDto, TKey>
        where TUserProviderDto : UserProviderDto<TKey>
        where TUserProvidersDto : UserProvidersDto<TUserProviderDto, TKey>
        where TRoleClaimsDto : RoleClaimsDto<TRoleClaimDto, TKey>
        where TUserClaimDto : UserClaimDto<TKey>
        where TRoleClaimDto : RoleClaimDto<TKey>
    {
        public void Register(TypeAdapterConfig config)
        {
            // entity to model
            config.NewConfig<TUser, TUserDto>();

            config.NewConfig<UserLoginInfo, TUserProviderDto>();

            config.NewConfig<IdentityError, ViewErrorMessage>()
                .Map(dest => dest.ErrorKey, src => src.Code)
                .Map(dest => dest.ErrorMessage, src => src.Description);

            // entity to model
            config.NewConfig<TRole, TRoleDto>();

            // Used to apply changes onto the tracked entity - the security stamp must be preserved
            config.NewConfig<TUser, TUser>()
                .Ignore(dest => dest.SecurityStamp);

            config.NewConfig<TRole, TRole>();

            config.NewConfig<PagedList<TUser>, TUsersDto>()
                .Map(dest => dest.Users, src => src.Data);

            config.NewConfig<TUserClaim, TUserClaimDto>()
                .Map(dest => dest.ClaimId, src => src.Id);

            config.NewConfig<TUserClaim, TUserClaimsDto>()
                .Map(dest => dest.ClaimId, src => src.Id);

            config.NewConfig<PagedList<TRole>, TRolesDto>()
                .Map(dest => dest.Roles, src => src.Data);

            config.NewConfig<PagedList<TRole>, TUserRolesDto>()
                .Map(dest => dest.Roles, src => src.Data);

            config.NewConfig<PagedList<TUserClaim>, TUserClaimsDto>()
                .Map(dest => dest.Claims, src => src.Data);

            config.NewConfig<PagedList<TRoleClaim>, TRoleClaimsDto>()
                .Map(dest => dest.Claims, src => src.Data);

            config.NewConfig<List<UserLoginInfo>, TUserProvidersDto>()
                .Map(dest => dest.Providers, src => src);

            config.NewConfig<TRoleClaim, TRoleClaimDto>()
                .Map(dest => dest.ClaimId, src => src.Id);

            config.NewConfig<TRoleClaim, TRoleClaimsDto>()
                .Map(dest => dest.ClaimId, src => src.Id);

            config.NewConfig<TUserLogin, TUserProviderDto>();

            // model to entity - keep the generated id of a new role/user when the DTO has none
            config.NewConfig<TRoleDto, TRole>()
                .IgnoreIf((src, dest) => src.Id == null, dest => dest.Id);

            config.NewConfig<TRoleClaimsDto, TRoleClaim>();

            config.NewConfig<TUserClaimsDto, TUserClaim>()
                .Map(dest => dest.Id, src => src.ClaimId);

            config.NewConfig<TUserDto, TUser>()
                .IgnoreIf((src, dest) => src.Id == null, dest => dest.Id);
        }
    }
}
