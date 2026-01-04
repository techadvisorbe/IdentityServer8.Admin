$packagesOutput = ".\packages"

# Business Logic
dotnet pack .\..\src\TechAdvisor.IdentityServer8.Admin.BusinessLogic\TechAdvisor.IdentityServer8.Admin.BusinessLogic.csproj -c Release -o $packagesOutput
dotnet pack .\..\src\TechAdvisor.IdentityServer8.Admin.BusinessLogic.Identity\TechAdvisor.IdentityServer8.Admin.BusinessLogic.Identity.csproj -c Release -o $packagesOutput
dotnet pack .\..\src\TechAdvisor.IdentityServer8.Admin.BusinessLogic.Shared\TechAdvisor.IdentityServer8.Admin.BusinessLogic.Shared.csproj -c Release -o $packagesOutput
dotnet pack .\..\src\TechAdvisor.IdentityServer8.Shared.Configuration\TechAdvisor.IdentityServer8.Shared.Configuration.csproj -c Release -o $packagesOutput

# EF
dotnet pack .\..\src\TechAdvisor.IdentityServer8.Admin.EntityFramework\TechAdvisor.IdentityServer8.Admin.EntityFramework.csproj -c Release -o $packagesOutput
dotnet pack .\..\src\TechAdvisor.IdentityServer8.Admin.EntityFramework.Extensions\TechAdvisor.IdentityServer8.Admin.EntityFramework.Extensions.csproj -c Release -o $packagesOutput
dotnet pack .\..\src\TechAdvisor.IdentityServer8.Admin.EntityFramework.Identity\TechAdvisor.IdentityServer8.Admin.EntityFramework.Identity.csproj -c Release -o $packagesOutput
dotnet pack .\..\src\TechAdvisor.IdentityServer8.Admin.EntityFramework.Shared\TechAdvisor.IdentityServer8.Admin.EntityFramework.Shared.csproj -c Release -o $packagesOutput
dotnet pack .\..\src\TechAdvisor.IdentityServer8.Admin.EntityFramework.Configuration\TechAdvisor.IdentityServer8.Admin.EntityFramework.Configuration.csproj -c Release -o $packagesOutput

# UI
dotnet pack .\..\src\TechAdvisor.IdentityServer8.Admin.UI\TechAdvisor.IdentityServer8.Admin.UI.csproj -c Release -o $packagesOutput