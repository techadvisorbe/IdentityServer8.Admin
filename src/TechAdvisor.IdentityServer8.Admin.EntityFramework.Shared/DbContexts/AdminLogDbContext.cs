using Microsoft.EntityFrameworkCore;
using TechAdvisor.IdentityServer8.Admin.EntityFramework.Constants;
using TechAdvisor.IdentityServer8.Admin.EntityFramework.Entities;
using TechAdvisor.IdentityServer8.Admin.EntityFramework.Interfaces;

namespace TechAdvisor.IdentityServer8.Admin.EntityFramework.Shared.DbContexts
{
    public class AdminLogDbContext : DbContext, IAdminLogDbContext
    {
        public DbSet<Log> Logs { get; set; }

        public AdminLogDbContext(DbContextOptions<AdminLogDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            ConfigureLogContext(builder);
        }

        private void ConfigureLogContext(ModelBuilder builder)
        {
            builder.Entity<Log>(log =>
            {
                log.ToTable(TableConsts.Logging);
                log.HasKey(x => x.Id);
                log.Property(x => x.Level).HasMaxLength(128);
            });
        }
    }
}
