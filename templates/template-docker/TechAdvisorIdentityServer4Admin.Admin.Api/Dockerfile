FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["src/TechAdvisorIdentityServer8Admin.Admin.Api/TechAdvisorIdentityServer8Admin.Admin.Api.csproj", "src/TechAdvisorIdentityServer8Admin.Admin.Api/"]
COPY ["src/TechAdvisorIdentityServer8Admin.Admin.EntityFramework.Shared/TechAdvisorIdentityServer8Admin.Admin.EntityFramework.Shared.csproj", "src/TechAdvisorIdentityServer8Admin.Admin.EntityFramework.Shared/"]
COPY ["src/TechAdvisorIdentityServer8Admin.Admin.EntityFramework.SqlServer/TechAdvisorIdentityServer8Admin.Admin.EntityFramework.SqlServer.csproj", "src/TechAdvisorIdentityServer8Admin.Admin.EntityFramework.SqlServer/"]
COPY ["src/TechAdvisorIdentityServer8Admin.Shared/TechAdvisorIdentityServer8Admin.Shared.csproj", "src/TechAdvisorIdentityServer8Admin.Shared/"]
COPY ["src/TechAdvisorIdentityServer8Admin.Admin.EntityFramework.PostgreSQL/TechAdvisorIdentityServer8Admin.Admin.EntityFramework.PostgreSQL.csproj", "src/TechAdvisorIdentityServer8Admin.Admin.EntityFramework.PostgreSQL/"]
COPY ["src/TechAdvisorIdentityServer8Admin.Admin.EntityFramework.MySql/TechAdvisorIdentityServer8Admin.Admin.EntityFramework.MySql.csproj", "src/TechAdvisorIdentityServer8Admin.Admin.EntityFramework.MySql/"]
RUN dotnet restore "src/TechAdvisorIdentityServer8Admin.Admin.Api/TechAdvisorIdentityServer8Admin.Admin.Api.csproj"
COPY . .
WORKDIR "/src/src/TechAdvisorIdentityServer8Admin.Admin.Api"
RUN dotnet build "TechAdvisorIdentityServer8Admin.Admin.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TechAdvisorIdentityServer8Admin.Admin.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_FORWARDEDHEADERS_ENABLED=true
ENTRYPOINT ["dotnet", "TechAdvisorIdentityServer8Admin.Admin.Api.dll"]