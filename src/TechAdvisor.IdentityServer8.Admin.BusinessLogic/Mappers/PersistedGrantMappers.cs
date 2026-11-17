using IdentityServer8.EntityFramework.Entities;
using Mapster;
using TechAdvisor.IdentityServer8.Admin.BusinessLogic.Dtos.Grant;
using TechAdvisor.IdentityServer8.Admin.BusinessLogic.Shared.Mappers;
using TechAdvisor.IdentityServer8.Admin.EntityFramework.Entities;
using TechAdvisor.IdentityServer8.Admin.EntityFramework.Extensions.Common;

namespace TechAdvisor.IdentityServer8.Admin.BusinessLogic.Mappers
{
    public static class PersistedGrantMappers
    {
        internal static TypeAdapterConfig Config { get; } = MapperConfigurationFactory.Create(new PersistedGrantMapperProfile());

        public static PersistedGrantsDto ToModel(this PagedList<PersistedGrantDataView> grant)
        {
            return grant == null ? null : grant.Adapt<PagedList<PersistedGrantDataView>, PersistedGrantsDto>(Config);
        }

        public static PersistedGrantsDto ToModel(this PagedList<PersistedGrant> grant)
        {
            return grant == null ? null : grant.Adapt<PagedList<PersistedGrant>, PersistedGrantsDto>(Config);
        }

        public static PersistedGrantDto ToModel(this PersistedGrant grant)
        {
            return grant == null ? null : grant.Adapt<PersistedGrant, PersistedGrantDto>(Config);
        }
    }
}
