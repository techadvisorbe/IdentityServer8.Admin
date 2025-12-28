$packagesOutput = ".\packages"

# Business Logic
dotnet pack .\..\src\Skoruba.IdentityServer8.Admin.BusinessLogic\Skoruba.IdentityServer8.Admin.BusinessLogic.csproj -c Release -o $packagesOutput
dotnet pack .\..\src\Skoruba.IdentityServer8.Admin.BusinessLogic.Identity\Skoruba.IdentityServer8.Admin.BusinessLogic.Identity.csproj -c Release -o $packagesOutput
dotnet pack .\..\src\Skoruba.IdentityServer8.Admin.BusinessLogic.Shared\Skoruba.IdentityServer8.Admin.BusinessLogic.Shared.csproj -c Release -o $packagesOutput
dotnet pack .\..\src\Skoruba.IdentityServer8.Shared.Configuration\Skoruba.IdentityServer8.Shared.Configuration.csproj -c Release -o $packagesOutput

# EF
dotnet pack .\..\src\Skoruba.IdentityServer8.Admin.EntityFramework\Skoruba.IdentityServer8.Admin.EntityFramework.csproj -c Release -o $packagesOutput
dotnet pack .\..\src\Skoruba.IdentityServer8.Admin.EntityFramework.Extensions\Skoruba.IdentityServer8.Admin.EntityFramework.Extensions.csproj -c Release -o $packagesOutput
dotnet pack .\..\src\Skoruba.IdentityServer8.Admin.EntityFramework.Identity\Skoruba.IdentityServer8.Admin.EntityFramework.Identity.csproj -c Release -o $packagesOutput
dotnet pack .\..\src\Skoruba.IdentityServer8.Admin.EntityFramework.Shared\Skoruba.IdentityServer8.Admin.EntityFramework.Shared.csproj -c Release -o $packagesOutput
dotnet pack .\..\src\Skoruba.IdentityServer8.Admin.EntityFramework.Configuration\Skoruba.IdentityServer8.Admin.EntityFramework.Configuration.csproj -c Release -o $packagesOutput

# UI
dotnet pack .\..\src\Skoruba.IdentityServer8.Admin.UI\Skoruba.IdentityServer8.Admin.UI.csproj -c Release -o $packagesOutput