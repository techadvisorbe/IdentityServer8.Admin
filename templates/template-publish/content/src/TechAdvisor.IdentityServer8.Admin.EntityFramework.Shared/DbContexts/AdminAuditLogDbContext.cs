using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TechAdvisor.AuditLogging.EntityFramework.DbContexts;
using TechAdvisor.AuditLogging.EntityFramework.Entities;

namespace TechAdvisor.IdentityServer8.Admin.EntityFramework.Shared.DbContexts
{
    public class AdminAuditLogDbContext : DbContext, IAuditLoggingDbContext<AuditLog>
    {
        public AdminAuditLogDbContext(DbContextOptions<AdminAuditLogDbContext> dbContextOptions)
            : base(dbContextOptions)
        {

        }

        public Task<int> SaveChangesAsync()
        {
            return base.SaveChangesAsync();
        }

        public DbSet<AuditLog> AuditLog { get; set; }
    }
}
