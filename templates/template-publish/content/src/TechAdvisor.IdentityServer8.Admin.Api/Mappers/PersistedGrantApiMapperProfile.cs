using AutoMapper;
using TechAdvisor.IdentityServer8.Admin.Api.Dtos.PersistedGrants;
using TechAdvisor.IdentityServer8.Admin.BusinessLogic.Dtos.Grant;

namespace TechAdvisor.IdentityServer8.Admin.Api.Mappers
{
    public class PersistedGrantApiMapperProfile : Profile
    {
        public PersistedGrantApiMapperProfile()
        {
            CreateMap<PersistedGrantDto, PersistedGrantApiDto>(MemberList.Destination);
            CreateMap<PersistedGrantDto, PersistedGrantSubjectApiDto>(MemberList.Destination);
            CreateMap<PersistedGrantsDto, PersistedGrantsApiDto>(MemberList.Destination);
            CreateMap<PersistedGrantsDto, PersistedGrantSubjectsApiDto>(MemberList.Destination);
        }
    }
}