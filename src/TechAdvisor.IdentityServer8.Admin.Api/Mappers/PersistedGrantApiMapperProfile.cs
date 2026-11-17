using Mapster;
using TechAdvisor.IdentityServer8.Admin.Api.Dtos.PersistedGrants;
using TechAdvisor.IdentityServer8.Admin.BusinessLogic.Dtos.Grant;

namespace TechAdvisor.IdentityServer8.Admin.Api.Mappers
{
    public class PersistedGrantApiMapperProfile : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<PersistedGrantDto, PersistedGrantApiDto>();
            config.NewConfig<PersistedGrantDto, PersistedGrantSubjectApiDto>();
            config.NewConfig<PersistedGrantsDto, PersistedGrantsApiDto>();
            config.NewConfig<PersistedGrantsDto, PersistedGrantSubjectsApiDto>();
        }
    }
}
