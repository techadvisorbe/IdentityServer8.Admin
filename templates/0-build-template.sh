#!/bin/bash

# Script arguments
packagesVersions="${1:?Error: packagesVersions argument is required}"
gitBranchName="${2:-dev}"

# This script contains following steps:
# - Download latest version of TechAdvisor.IdentityServer8.Admin from git repository
# - Use folders src and tests for project template
# - Create db migrations for seed data

gitProject="https://github.com/techadvisorbe/IdentityServer8.Admin"
gitProjectFolder="TechAdvisor.IdentityServer8.Admin"
templateSrc="template-build/content/src"
templateRoot="template-build/content"
templateTests="template-build/content/tests"
templateAdminProject="template-build/content/src/TechAdvisor.IdentityServer8.Admin"

clean_bin_obj_folders() {
    # Clean up after migrations
    dotnet clean "$templateAdminProject"

    # Clean up bin, obj
    find . -type d \( -name "bin" -o -name "obj" \) -exec rm -rf {} + 2>/dev/null || true
}

# Clone the latest version from master branch
git clone "$gitProject" "$gitProjectFolder" -b "$gitBranchName"

# Clean up src, tests folders
[[ -d "$templateSrc" ]] && rm -rf "$templateSrc"
[[ -d "$templateTests" ]] && rm -rf "$templateTests"

# Create src, tests folders
[[ ! -d "$templateSrc" ]] && mkdir -p "$templateSrc"
[[ ! -d "$templateTests" ]] && mkdir -p "$templateTests"

# Copy the latest src and tests to content
cp -r "$gitProjectFolder/src/"* "$templateSrc"
cp -r "$gitProjectFolder/tests/"* "$templateTests"

# Copy Docker files
cp -r "$gitProjectFolder/docker-compose.dcproj" "$templateRoot"
cp -r "$gitProjectFolder/.dockerignore" "$templateRoot"
cp -r "$gitProjectFolder/docker-compose.override.yml" "$templateRoot"
cp -r "$gitProjectFolder/docker-compose.vs.debug.yml" "$templateRoot"
cp -r "$gitProjectFolder/docker-compose.vs.release.yml" "$templateRoot"
cp -r "$gitProjectFolder/docker-compose.yml" "$templateRoot"
cp -r "$gitProjectFolder/shared" "$templateRoot"
cp -r "$gitProjectFolder/package" "$templateRoot"
cp -r "$gitProjectFolder/LICENSE.md" "$templateRoot"

cp -r "$gitProjectFolder/Directory.Build.props" "$templateRoot"

# Clean up created folders
rm -rf "$gitProjectFolder"

# Clean solution and folders bin, obj
clean_bin_obj_folders

# Remove references

# API
dotnet remove "./$templateSrc/TechAdvisor.IdentityServer8.Admin.Api/TechAdvisor.IdentityServer8.Admin.Api.csproj" reference ../TechAdvisor.IdentityServer8.Admin.BusinessLogic.Identity/TechAdvisor.IdentityServer8.Admin.BusinessLogic.Identity.csproj
dotnet remove "./$templateSrc/TechAdvisor.IdentityServer8.Admin.Api/TechAdvisor.IdentityServer8.Admin.Api.csproj" reference ../TechAdvisor.IdentityServer8.Admin.BusinessLogic/TechAdvisor.IdentityServer8.Admin.BusinessLogic.csproj
dotnet remove "./$templateSrc/TechAdvisor.IdentityServer8.Admin.Api/TechAdvisor.IdentityServer8.Admin.Api.csproj" reference ../TechAdvisor.IdentityServer8.Shared.Configuration/TechAdvisor.IdentityServer8.Shared.Configuration.csproj

# Admin
dotnet remove "./$templateSrc/TechAdvisor.IdentityServer8.Admin/TechAdvisor.IdentityServer8.Admin.csproj" reference ../TechAdvisor.IdentityServer8.Admin.BusinessLogic/TechAdvisor.IdentityServer8.Admin.BusinessLogic.csproj
dotnet remove "./$templateSrc/TechAdvisor.IdentityServer8.Admin/TechAdvisor.IdentityServer8.Admin.csproj" reference ../TechAdvisor.IdentityServer8.Admin.UI/TechAdvisor.IdentityServer8.Admin.UI.csproj

# STS
dotnet remove "./$templateSrc/TechAdvisor.IdentityServer8.STS.Identity/TechAdvisor.IdentityServer8.STS.Identity.csproj" reference ../TechAdvisor.IdentityServer8.Shared.Configuration/TechAdvisor.IdentityServer8.Shared.Configuration.csproj
dotnet remove "./$templateSrc/TechAdvisor.IdentityServer8.STS.Identity/TechAdvisor.IdentityServer8.STS.Identity.csproj" reference ../TechAdvisor.IdentityServer8.Admin.EntityFramework.Configuration/TechAdvisor.IdentityServer8.Admin.EntityFramework.Configuration.csproj

# EF Shared
dotnet remove "./$templateSrc/TechAdvisor.IdentityServer8.Admin.EntityFramework.Shared/TechAdvisor.IdentityServer8.Admin.EntityFramework.Shared.csproj" reference ../TechAdvisor.IdentityServer8.Admin.EntityFramework.Configuration/TechAdvisor.IdentityServer8.Admin.EntityFramework.Configuration.csproj

# Shared
dotnet remove "./$templateSrc/TechAdvisor.IdentityServer8.Shared/TechAdvisor.IdentityServer8.Shared.csproj" reference ../TechAdvisor.IdentityServer8.Admin.BusinessLogic.Identity/TechAdvisor.IdentityServer8.Admin.BusinessLogic.Identity.csproj

# Add nuget packages
# Admin
dotnet add "./$templateSrc/TechAdvisor.IdentityServer8.Admin/TechAdvisor.IdentityServer8.Admin.csproj" package TechAdvisor.IdentityServer8.Admin.BusinessLogic -v "$packagesVersions"
dotnet add "./$templateSrc/TechAdvisor.IdentityServer8.Admin/TechAdvisor.IdentityServer8.Admin.csproj" package TechAdvisor.IdentityServer8.Admin.BusinessLogic.Identity -v "$packagesVersions"
dotnet add "./$templateSrc/TechAdvisor.IdentityServer8.Admin/TechAdvisor.IdentityServer8.Admin.csproj" package TechAdvisor.IdentityServer8.Admin.UI -v "$packagesVersions"

# STS
dotnet add "./$templateSrc/TechAdvisor.IdentityServer8.STS.Identity/TechAdvisor.IdentityServer8.STS.Identity.csproj" package TechAdvisor.IdentityServer8.Shared.Configuration -v "$packagesVersions"
dotnet add "./$templateSrc/TechAdvisor.IdentityServer8.STS.Identity/TechAdvisor.IdentityServer8.STS.Identity.csproj" package TechAdvisor.IdentityServer8.Admin.EntityFramework.Configuration -v "$packagesVersions"

# API
dotnet add "./$templateSrc/TechAdvisor.IdentityServer8.Admin.Api/TechAdvisor.IdentityServer8.Admin.Api.csproj" package TechAdvisor.IdentityServer8.Admin.BusinessLogic -v "$packagesVersions"
dotnet add "./$templateSrc/TechAdvisor.IdentityServer8.Admin.Api/TechAdvisor.IdentityServer8.Admin.Api.csproj" package TechAdvisor.IdentityServer8.Admin.BusinessLogic.Identity -v "$packagesVersions"
dotnet add "./$templateSrc/TechAdvisor.IdentityServer8.Admin.Api/TechAdvisor.IdentityServer8.Admin.Api.csproj" package TechAdvisor.IdentityServer8.Shared.Configuration -v "$packagesVersions"

# EF Shared
dotnet add "./$templateSrc/TechAdvisor.IdentityServer8.Admin.EntityFramework.Shared/TechAdvisor.IdentityServer8.Admin.EntityFramework.Shared.csproj" package TechAdvisor.IdentityServer8.Admin.EntityFramework.Configuration -v "$packagesVersions"

# Shared
dotnet add "./$templateSrc/TechAdvisor.IdentityServer8.Shared/TechAdvisor.IdentityServer8.Shared.csproj" package TechAdvisor.IdentityServer8.Admin.BusinessLogic.Identity -v "$packagesVersions"
# Clean solution and folders bin, obj
clean_bin_obj_folders

# Clean up projects which will be installed via nuget packages
rm -rf "./$templateSrc/TechAdvisor.IdentityServer8.Admin.BusinessLogic"
rm -rf "./$templateSrc/TechAdvisor.IdentityServer8.Admin.BusinessLogic.Identity"
rm -rf "./$templateSrc/TechAdvisor.IdentityServer8.Admin.BusinessLogic.Shared"
rm -rf "./$templateSrc/TechAdvisor.IdentityServer8.Admin.EntityFramework"
rm -rf "./$templateSrc/TechAdvisor.IdentityServer8.Admin.EntityFramework.Identity"
rm -rf "./$templateSrc/TechAdvisor.IdentityServer8.Admin.EntityFramework.Extensions"
rm -rf "./$templateSrc/TechAdvisor.IdentityServer8.Admin.EntityFramework.Configuration"
rm -rf "./$templateSrc/TechAdvisor.IdentityServer8.Shared.Configuration"
rm -rf "./$templateSrc/TechAdvisor.IdentityServer8.Admin.UI"
rm -rf "./$templateTests"

######################################
# Step 2
templateNuspecPath="template-build/TechAdvisor.IdentityServer8.Admin.Templates.nuspec"
nuget pack "$templateNuspecPath" -NoDefaultExcludes

######################################
# Step 3
templateLocalName="TechAdvisor.IdentityServer8.Admin.Templates.$packagesVersions.nupkg"

dotnet new --uninstall TechAdvisor.IdentityServer8.Admin.Templates
dotnet new -i "$templateLocalName"

######################################
# Step 4
# Create template for fixing project name
dotnet new techadvisor.is8admin --name TechAdvisorIdentityServer8Admin --title "TechAdvisor IdentityServer8 Admin" --adminrole TechAdvisorIdentityAdminAdministrator --adminclientid techadvisor_identity_admin --adminclientsecret techadvisor_admin_client_secret

######################################
# Step 5
# Replace files

clean_bin_obj_folders

# Find and replace in template files
while IFS= read -r file; do
    echo "$file"
    
    # Use sed for in-place replacement (compatible with both GNU sed and BSD sed)
    sed -i.bak 's|TechAdvisorIdentityServer8Admin\.Shared\.Configuration|TechAdvisor.IdentityServer8.Shared.Configuration|g' "$file"
    sed -i.bak 's|TechAdvisorIdentityServer8Admin\.Admin\.UI|TechAdvisor.IdentityServer8.Admin.UI|g' "$file"
    sed -i.bak 's|TechAdvisorIdentityServer8Admin\.Admin\.BusinessLogic|TechAdvisor.IdentityServer8.Admin.BusinessLogic|g' "$file"
    sed -i.bak 's|TechAdvisorIdentityServer8Admin\.Admin\.EntityFramework|TechAdvisor.IdentityServer8.Admin.EntityFramework|g' "$file"
    sed -i.bak 's|TechAdvisor\.IdentityServer8\.Admin\.EntityFramework\.Shared|TechAdvisorIdentityServer8Admin.Admin.EntityFramework.Shared|g' "$file"
    sed -i.bak 's|TechAdvisor\.IdentityServer8\.Admin\.EntityFramework\.MySql|TechAdvisorIdentityServer8Admin.Admin.EntityFramework.MySql|g' "$file"
    sed -i.bak 's|TechAdvisor\.IdentityServer8\.Admin\.EntityFramework\.PostgreSQL|TechAdvisorIdentityServer8Admin.Admin.EntityFramework.PostgreSQL|g' "$file"
    sed -i.bak 's|TechAdvisor\.IdentityServer8\.Admin\.EntityFramework\.SqlServer|TechAdvisorIdentityServer8Admin.Admin.EntityFramework.SqlServer|g' "$file"
    
    # Remove backup files
    rm -f "$file.bak"
done < <(find ./TechAdvisorIdentityServer8Admin/src -type f \( -name "*.cs" -o -name "*.csproj" -o -name "*.cshtml" \))

clean_bin_obj_folders