using System;
using System.Threading.Tasks;
using TechAdvisor.AuditLogging.EntityFramework.Entities;
using TechAdvisor.IdentityServer8.Admin.BusinessLogic.Dtos.Log;
using TechAdvisor.IdentityServer8.Admin.BusinessLogic.Mappers;
using TechAdvisor.IdentityServer8.Admin.BusinessLogic.Services.Interfaces;
using TechAdvisor.IdentityServer8.Admin.EntityFramework.Repositories.Interfaces;

namespace TechAdvisor.IdentityServer8.Admin.BusinessLogic.Services
{
    public class AuditLogService<TAuditLog> : IAuditLogService
        where TAuditLog : AuditLog
    {
        protected readonly IAuditLogRepository<TAuditLog> AuditLogRepository;

        public AuditLogService(IAuditLogRepository<TAuditLog> auditLogRepository)
        {
            AuditLogRepository = auditLogRepository;
        }

        public async Task<AuditLogsDto> GetAsync(AuditLogFilterDto filters)
        {
            var pagedList = await AuditLogRepository.GetAsync(filters.Event, filters.Source, filters.Category, filters.Created, filters.SubjectIdentifier, filters.SubjectName, filters.Page, filters.PageSize);
            var auditLogsDto = pagedList.ToModel();

            return auditLogsDto;
        }

        public virtual async Task DeleteLogsOlderThanAsync(DateTime deleteOlderThan)
        {
            await AuditLogRepository.DeleteLogsOlderThanAsync(deleteOlderThan);
        }
    }
}
