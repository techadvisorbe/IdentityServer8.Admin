using System;
using System.Threading.Tasks;
using Skoruba.IdentityServer8.Admin.BusinessLogic.Dtos.Log;

namespace Skoruba.IdentityServer8.Admin.BusinessLogic.Services.Interfaces
{
    public interface IAuditLogService
    {
        Task<AuditLogsDto> GetAsync(AuditLogFilterDto filters);

        Task DeleteLogsOlderThanAsync(DateTime deleteOlderThan);
    }
}
