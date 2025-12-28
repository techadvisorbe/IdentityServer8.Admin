using System;
using System.Reflection;
using Skoruba.IdentityServer8.Admin.EntityFramework.Configuration.Configuration;
using SqlMigrationAssembly = SkorubaIdentityServer8Admin.Admin.EntityFramework.SqlServer.Helpers.MigrationAssembly;
using MySqlMigrationAssembly = SkorubaIdentityServer8Admin.Admin.EntityFramework.MySql.Helpers.MigrationAssembly;
using PostgreSQLMigrationAssembly = SkorubaIdentityServer8Admin.Admin.EntityFramework.PostgreSQL.Helpers.MigrationAssembly;

namespace SkorubaIdentityServer8Admin.Admin.Configuration.Database
{
    public static class MigrationAssemblyConfiguration
    {
        public static string GetMigrationAssemblyByProvider(DatabaseProviderConfiguration databaseProvider)
        {
            return databaseProvider.ProviderType switch
            {
                DatabaseProviderType.SqlServer => typeof(SqlMigrationAssembly).GetTypeInfo().Assembly.GetName().Name,
                DatabaseProviderType.PostgreSQL => typeof(PostgreSQLMigrationAssembly).GetTypeInfo()
                    .Assembly.GetName()
                    .Name,
                DatabaseProviderType.MySql => typeof(MySqlMigrationAssembly).GetTypeInfo().Assembly.GetName().Name,
                _ => throw new ArgumentOutOfRangeException()
            };
        }
    }
}







