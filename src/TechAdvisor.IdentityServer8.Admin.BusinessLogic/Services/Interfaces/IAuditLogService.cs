using System;
using System.Threading.Tasks;
using TechAdvisor.IdentityServer8.Admin.BusinessLogic.Dtos.Log;

namespace TechAdvisor.IdentityServer8.Admin.BusinessLogic.Services.Interfaces
{
    public interface IAuditLogService
    {
        Task<AuditLogsDto> GetAsync(AuditLogFilterDto filters);

        Task DeleteLogsOlderThanAsync(DateTime deleteOlderThan);
    }
}
