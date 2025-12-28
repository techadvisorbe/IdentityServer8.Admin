using IdentityServer8.EntityFramework.DbContexts;
using IdentityServer8.EntityFramework.Options;
using Microsoft.EntityFrameworkCore;
using Skoruba.IdentityServer8.Admin.EntityFramework.Interfaces;

namespace SkorubaIdentityServer8Admin.Admin.EntityFramework.Shared.DbContexts
{
    public class IdentityServerPersistedGrantDbContext : PersistedGrantDbContext<IdentityServerPersistedGrantDbContext>, IAdminPersistedGrantDbContext
    {
        public IdentityServerPersistedGrantDbContext(DbContextOptions<IdentityServerPersistedGrantDbContext> options, OperationalStoreOptions storeOptions)
            : base(options, storeOptions)
        {
        }
    }
}







