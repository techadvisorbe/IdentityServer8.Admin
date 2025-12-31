using System;
using System.Threading.Tasks;
using Skoruba.IdentityServer8.Admin.BusinessLogic.Dtos.Log;

namespace Skoruba.IdentityServer8.Admin.BusinessLogic.Services.Interfaces
{
    public interface ILogService
    {
        Task<LogsDto> GetLogsAsync(string search, int page = 1, int pageSize = 10);

        Task DeleteLogsOlderThanAsync(DateTime deleteOlderThan);
    }
}