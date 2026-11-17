using Mapster;
using TechAdvisor.AuditLogging.EntityFramework.Entities;
using TechAdvisor.IdentityServer8.Admin.BusinessLogic.Dtos.Log;
using TechAdvisor.IdentityServer8.Admin.EntityFramework.Entities;
using TechAdvisor.IdentityServer8.Admin.EntityFramework.Extensions.Common;

namespace TechAdvisor.IdentityServer8.Admin.BusinessLogic.Mappers
{
    public class LogMapperProfile : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Log, LogDto>()
                .TwoWays();

            config.NewConfig<PagedList<Log>, LogsDto>()
                .Map(dest => dest.Logs, src => src.Data);

            config.NewConfig<AuditLog, AuditLogDto>()
                .TwoWays();

            config.NewConfig<PagedList<AuditLog>, AuditLogsDto>()
                .Map(dest => dest.Logs, src => src.Data);
        }
    }
}
