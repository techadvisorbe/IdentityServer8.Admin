#!/bin/bash

# Script parameters with defaults
migration="${1:-DbInit}"
migrationProviderName="${2:-All}"
targetContext="${3:-All}"

projectName="TechAdvisor.IdentityServer8"
currentPath=$(pwd)

cd "../src/$projectName.Admin" || exit 1

# Backup appsettings.json
cp appsettings.json appsettings-backup.json

# Read settings file
settings=$(cat appsettings.json)

# Initialize db context and define the target directory
declare -A targetContexts=(
    [AdminIdentityDbContext]="Migrations/Identity"
    [AdminLogDbContext]="Migrations/Logging"
    [IdentityServerConfigurationDbContext]="Migrations/IdentityServerConfiguration"
    [IdentityServerPersistedGrantDbContext]="Migrations/IdentityServerGrants"
    [AdminAuditLogDbContext]="Migrations/AuditLogging"
    [IdentityServerDataProtectionDbContext]="Migrations/DataProtection"
)

# Initialize the db providers and their respective projects
declare -A dpProviders=(
    [SqlServer]="../../src/$projectName.Admin.EntityFramework.SqlServer/$projectName.Admin.EntityFramework.SqlServer.csproj"
    [PostgreSQL]="../../src/$projectName.Admin.EntityFramework.PostgreSQL/$projectName.Admin.EntityFramework.PostgreSQL.csproj"
    [MySql]="../../src/$projectName.Admin.EntityFramework.MySql/$projectName.Admin.EntityFramework.MySql.csproj"
)

# Update dotnet ef tools
echo "Updating dotnet ef tools"
export PATH="$PATH:$HOME/.dotnet/tools"
dotnet tool update --global dotnet-ef

echo "Start migrate projects"
for provider in "${!dpProviders[@]}"; do

    if [[ "$migrationProviderName" == "All" ]] || [[ "$migrationProviderName" == "$provider" ]]; then
    
        projectPath="${dpProviders[$provider]}"
        echo "Generate migration for db provider: $provider, for project path - $projectPath"

        providerName="\"ProviderType\": \"$provider\""
        settings=$(echo "$settings" | sed "s/\"ProviderType\".*/\"$providerName\"/")
        echo "$settings" > appsettings.json

        if [[ -f "$projectPath" ]]; then
            for context in "${!targetContexts[@]}"; do
                
                if [[ "$targetContext" == "All" ]] || [[ "$context" == "$targetContext" ]]; then

                    echo "Migrating context $context"
                    dotnet ef database update "$migration" -c "$context" -p "$projectPath"
                fi
            done
        fi
        
    fi
done

# Restore original appsettings.json
rm appsettings.json
cp appsettings-backup.json appsettings.json
rm appsettings-backup.json

cd "$currentPath" || exit 1
