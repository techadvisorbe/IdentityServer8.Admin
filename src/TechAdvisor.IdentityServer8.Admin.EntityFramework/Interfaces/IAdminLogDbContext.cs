using Microsoft.EntityFrameworkCore;
using TechAdvisor.IdentityServer8.Admin.EntityFramework.Entities;

namespace TechAdvisor.IdentityServer8.Admin.EntityFramework.Interfaces
{
    public interface IAdminLogDbContext
    {
        DbSet<Log> Logs { get; set; }
    }
}
