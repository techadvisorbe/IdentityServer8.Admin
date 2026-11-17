using IdentityServer8.EntityFramework.Entities;
using Mapster;
using TechAdvisor.IdentityServer8.Admin.BusinessLogic.Identity.Dtos.Grant;
using TechAdvisor.IdentityServer8.Admin.EntityFramework.Entities;
using TechAdvisor.IdentityServer8.Admin.EntityFramework.Extensions.Common;

namespace TechAdvisor.IdentityServer8.Admin.BusinessLogic.Identity.Mappers
{
    public class PersistedGrantMapperProfile : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            // entity to model
            config.NewConfig<PersistedGrant, PersistedGrantDto>()
                .TwoWays();

            config.NewConfig<PersistedGrantDataView, PersistedGrantDto>();

            config.NewConfig<PagedList<PersistedGrantDataView>, PersistedGrantsDto>()
                .Map(dest => dest.PersistedGrants, src => src.Data);

            config.NewConfig<PagedList<PersistedGrant>, PersistedGrantsDto>()
                .Map(dest => dest.PersistedGrants, src => src.Data);
        }
    }
}
