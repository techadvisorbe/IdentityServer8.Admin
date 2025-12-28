using Microsoft.EntityFrameworkCore;
using Skoruba.IdentityServer8.Admin.EntityFramework.Entities;

namespace Skoruba.IdentityServer8.Admin.EntityFramework.Interfaces
{
    public interface IAdminLogDbContext
    {
        DbSet<Log> Logs { get; set; }
    }
}
