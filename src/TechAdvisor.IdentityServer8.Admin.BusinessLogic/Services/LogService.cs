using System;
using System.Threading.Tasks;
using TechAdvisor.AuditLogging.Services;
using TechAdvisor.IdentityServer8.Admin.BusinessLogic.Dtos.Log;
using TechAdvisor.IdentityServer8.Admin.BusinessLogic.Events.Log;
using TechAdvisor.IdentityServer8.Admin.BusinessLogic.Mappers;
using TechAdvisor.IdentityServer8.Admin.BusinessLogic.Services.Interfaces;
using TechAdvisor.IdentityServer8.Admin.EntityFramework.Repositories.Interfaces;

namespace TechAdvisor.IdentityServer8.Admin.BusinessLogic.Services
{
    public class LogService : ILogService
    {
        protected readonly ILogRepository Repository;
        protected readonly IAuditEventLogger AuditEventLogger;

        public LogService(ILogRepository repository, IAuditEventLogger auditEventLogger)
        {
            Repository = repository;
            AuditEventLogger = auditEventLogger;
        }

        public virtual async Task<LogsDto> GetLogsAsync(string search, int page = 1, int pageSize = 10)
        {
            var pagedList = await Repository.GetLogsAsync(search, page, pageSize);
            var logs = pagedList.ToModel();

            await AuditEventLogger.LogEventAsync(new LogsRequestedEvent());

            return logs;
        }

        public virtual async Task DeleteLogsOlderThanAsync(DateTime deleteOlderThan)
        {
            await Repository.DeleteLogsOlderThanAsync(deleteOlderThan);

            await AuditEventLogger.LogEventAsync(new LogsDeletedEvent(deleteOlderThan));
        }
    }
}
