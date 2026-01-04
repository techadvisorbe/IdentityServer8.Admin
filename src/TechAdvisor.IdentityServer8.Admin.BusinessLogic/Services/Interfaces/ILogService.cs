using System;
using System.Threading.Tasks;
using TechAdvisor.IdentityServer8.Admin.BusinessLogic.Dtos.Log;

namespace TechAdvisor.IdentityServer8.Admin.BusinessLogic.Services.Interfaces
{
    public interface ILogService
    {
        Task<LogsDto> GetLogsAsync(string search, int page = 1, int pageSize = 10);

        Task DeleteLogsOlderThanAsync(DateTime deleteOlderThan);
    }
}