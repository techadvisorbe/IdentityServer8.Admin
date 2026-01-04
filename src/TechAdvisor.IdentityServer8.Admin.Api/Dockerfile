FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["src/TechAdvisor.IdentityServer8.Admin.Api/TechAdvisor.IdentityServer8.Admin.Api.csproj", "src/TechAdvisor.IdentityServer8.Admin.Api/"]
COPY ["src/TechAdvisor.IdentityServer8.Admin.EntityFramework.MySql/TechAdvisor.IdentityServer8.Admin.EntityFramework.MySql.csproj", "src/TechAdvisor.IdentityServer8.Admin.EntityFramework.MySql/"]
COPY ["src/TechAdvisor.IdentityServer8.Admin.EntityFramework.Identity/TechAdvisor.IdentityServer8.Admin.EntityFramework.Identity.csproj", "src/TechAdvisor.IdentityServer8.Admin.EntityFramework.Identity/"]
COPY ["src/TechAdvisor.IdentityServer8.Admin.EntityFramework/TechAdvisor.IdentityServer8.Admin.EntityFramework.csproj", "src/TechAdvisor.IdentityServer8.Admin.EntityFramework/"]
COPY ["src/TechAdvisor.IdentityServer8.Admin.EntityFramework.Extensions/TechAdvisor.IdentityServer8.Admin.EntityFramework.Extensions.csproj", "src/TechAdvisor.IdentityServer8.Admin.EntityFramework.Extensions/"]
COPY ["src/TechAdvisor.IdentityServer8.Admin.EntityFramework.Shared/TechAdvisor.IdentityServer8.Admin.EntityFramework.Shared.csproj", "src/TechAdvisor.IdentityServer8.Admin.EntityFramework.Shared/"]
COPY ["src/TechAdvisor.IdentityServer8.Admin.EntityFramework.Configuration/TechAdvisor.IdentityServer8.Admin.EntityFramework.Configuration.csproj", "src/TechAdvisor.IdentityServer8.Admin.EntityFramework.Configuration/"]
COPY ["src/TechAdvisor.IdentityServer8.Admin.BusinessLogic/TechAdvisor.IdentityServer8.Admin.BusinessLogic.csproj", "src/TechAdvisor.IdentityServer8.Admin.BusinessLogic/"]
COPY ["src/TechAdvisor.IdentityServer8.Admin.BusinessLogic.Shared/TechAdvisor.IdentityServer8.Admin.BusinessLogic.Shared.csproj", "src/TechAdvisor.IdentityServer8.Admin.BusinessLogic.Shared/"]
COPY ["src/TechAdvisor.IdentityServer8.Admin.EntityFramework.PostgreSQL/TechAdvisor.IdentityServer8.Admin.EntityFramework.PostgreSQL.csproj", "src/TechAdvisor.IdentityServer8.Admin.EntityFramework.PostgreSQL/"]
COPY ["src/TechAdvisor.IdentityServer8.Shared.Configuration/TechAdvisor.IdentityServer8.Shared.Configuration.csproj", "src/TechAdvisor.IdentityServer8.Shared.Configuration/"]
COPY ["src/TechAdvisor.IdentityServer8.Admin.BusinessLogic.Identity/TechAdvisor.IdentityServer8.Admin.BusinessLogic.Identity.csproj", "src/TechAdvisor.IdentityServer8.Admin.BusinessLogic.Identity/"]
COPY ["src/TechAdvisor.IdentityServer8.Shared/TechAdvisor.IdentityServer8.Shared.csproj", "src/TechAdvisor.IdentityServer8.Shared/"]
COPY ["src/TechAdvisor.IdentityServer8.Admin.EntityFramework.SqlServer/TechAdvisor.IdentityServer8.Admin.EntityFramework.SqlServer.csproj", "src/TechAdvisor.IdentityServer8.Admin.EntityFramework.SqlServer/"]
RUN dotnet restore "src/TechAdvisor.IdentityServer8.Admin.Api/TechAdvisor.IdentityServer8.Admin.Api.csproj"
COPY . .
WORKDIR "/src/src/TechAdvisor.IdentityServer8.Admin.Api"
RUN dotnet build "TechAdvisor.IdentityServer8.Admin.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TechAdvisor.IdentityServer8.Admin.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_FORWARDEDHEADERS_ENABLED=true
ENTRYPOINT ["dotnet", "TechAdvisor.IdentityServer8.Admin.Api.dll"]