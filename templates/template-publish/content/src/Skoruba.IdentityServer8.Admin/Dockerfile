FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["src/Skoruba.IdentityServer8.Admin/Skoruba.IdentityServer8.Admin.csproj", "src/Skoruba.IdentityServer8.Admin/"]
COPY ["src/Skoruba.IdentityServer8.Admin.EntityFramework.MySql/Skoruba.IdentityServer8.Admin.EntityFramework.MySql.csproj", "src/Skoruba.IdentityServer8.Admin.EntityFramework.MySql/"]
COPY ["src/Skoruba.IdentityServer8.Admin.EntityFramework.Identity/Skoruba.IdentityServer8.Admin.EntityFramework.Identity.csproj", "src/Skoruba.IdentityServer8.Admin.EntityFramework.Identity/"]
COPY ["src/Skoruba.IdentityServer8.Admin.EntityFramework/Skoruba.IdentityServer8.Admin.EntityFramework.csproj", "src/Skoruba.IdentityServer8.Admin.EntityFramework/"]
COPY ["src/Skoruba.IdentityServer8.Admin.EntityFramework.Extensions/Skoruba.IdentityServer8.Admin.EntityFramework.Extensions.csproj", "src/Skoruba.IdentityServer8.Admin.EntityFramework.Extensions/"]
COPY ["src/Skoruba.IdentityServer8.Admin.EntityFramework.Shared/Skoruba.IdentityServer8.Admin.EntityFramework.Shared.csproj", "src/Skoruba.IdentityServer8.Admin.EntityFramework.Shared/"]
COPY ["src/Skoruba.IdentityServer8.Admin.EntityFramework.Configuration/Skoruba.IdentityServer8.Admin.EntityFramework.Configuration.csproj", "src/Skoruba.IdentityServer8.Admin.EntityFramework.Configuration/"]
COPY ["src/Skoruba.IdentityServer8.Admin.BusinessLogic/Skoruba.IdentityServer8.Admin.BusinessLogic.csproj", "src/Skoruba.IdentityServer8.Admin.BusinessLogic/"]
COPY ["src/Skoruba.IdentityServer8.Admin.BusinessLogic.Shared/Skoruba.IdentityServer8.Admin.BusinessLogic.Shared.csproj", "src/Skoruba.IdentityServer8.Admin.BusinessLogic.Shared/"]
COPY ["src/Skoruba.IdentityServer8.Admin.EntityFramework.PostgreSQL/Skoruba.IdentityServer8.Admin.EntityFramework.PostgreSQL.csproj", "src/Skoruba.IdentityServer8.Admin.EntityFramework.PostgreSQL/"]
COPY ["src/Skoruba.IdentityServer8.Admin.BusinessLogic.Identity/Skoruba.IdentityServer8.Admin.BusinessLogic.Identity.csproj", "src/Skoruba.IdentityServer8.Admin.BusinessLogic.Identity/"]
COPY ["src/Skoruba.IdentityServer8.Admin.UI/Skoruba.IdentityServer8.Admin.UI.csproj", "src/Skoruba.IdentityServer8.Admin.UI/"]
COPY ["src/Skoruba.IdentityServer8.Shared.Configuration/Skoruba.IdentityServer8.Shared.Configuration.csproj", "src/Skoruba.IdentityServer8.Shared.Configuration/"]
COPY ["src/Skoruba.IdentityServer8.Shared/Skoruba.IdentityServer8.Shared.csproj", "src/Skoruba.IdentityServer8.Shared/"]
COPY ["src/Skoruba.IdentityServer8.Admin.EntityFramework.SqlServer/Skoruba.IdentityServer8.Admin.EntityFramework.SqlServer.csproj", "src/Skoruba.IdentityServer8.Admin.EntityFramework.SqlServer/"]
RUN dotnet restore "src/Skoruba.IdentityServer8.Admin/Skoruba.IdentityServer8.Admin.csproj"
COPY . .
WORKDIR "/src/src/Skoruba.IdentityServer8.Admin"
RUN dotnet build "Skoruba.IdentityServer8.Admin.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Skoruba.IdentityServer8.Admin.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_FORWARDEDHEADERS_ENABLED=true
ENTRYPOINT ["dotnet", "Skoruba.IdentityServer8.Admin.dll"]