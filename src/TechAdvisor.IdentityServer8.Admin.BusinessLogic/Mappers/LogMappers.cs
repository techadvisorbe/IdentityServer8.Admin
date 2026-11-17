using System.Collections.Generic;
using Mapster;
using TechAdvisor.AuditLogging.EntityFramework.Entities;
using TechAdvisor.IdentityServer8.Admin.BusinessLogic.Dtos.Log;
using TechAdvisor.IdentityServer8.Admin.BusinessLogic.Shared.Mappers;
using TechAdvisor.IdentityServer8.Admin.EntityFramework.Entities;
using TechAdvisor.IdentityServer8.Admin.EntityFramework.Extensions.Common;

namespace TechAdvisor.IdentityServer8.Admin.BusinessLogic.Mappers
{
    public static class LogMappers
    {
        internal static TypeAdapterConfig Config { get; } = MapperConfigurationFactory.Create(new LogMapperProfile());

        public static LogDto ToModel(this Log log)
        {
            return log.Adapt<Log, LogDto>(Config);
        }

        public static LogsDto ToModel(this PagedList<Log> logs)
        {
            return logs.Adapt<PagedList<Log>, LogsDto>(Config);
        }

        public static AuditLogsDto ToModel<TAuditLog>(this PagedList<TAuditLog> auditLogs)
            where TAuditLog : AuditLog
        {
            if (auditLogs == null) return null;

            return new AuditLogsDto
            {
                Logs = auditLogs.Data.Adapt<List<TAuditLog>, List<AuditLogDto>>(Config) ?? new List<AuditLogDto>(),
                TotalCount = auditLogs.TotalCount,
                PageSize = auditLogs.PageSize
            };
        }

        public static AuditLogDto ToModel(this AuditLog auditLog)
        {
            return auditLog.Adapt<AuditLog, AuditLogDto>(Config);
        }

        public static Log ToEntity(this LogDto log)
        {
            return log.Adapt<LogDto, Log>(Config);
        }
    }
}
