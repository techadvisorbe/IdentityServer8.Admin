FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["src/SkorubaIdentityServer8Admin.Admin.Api/SkorubaIdentityServer8Admin.Admin.Api.csproj", "src/SkorubaIdentityServer8Admin.Admin.Api/"]
COPY ["src/SkorubaIdentityServer8Admin.Admin.EntityFramework.Shared/SkorubaIdentityServer8Admin.Admin.EntityFramework.Shared.csproj", "src/SkorubaIdentityServer8Admin.Admin.EntityFramework.Shared/"]
COPY ["src/SkorubaIdentityServer8Admin.Admin.EntityFramework.SqlServer/SkorubaIdentityServer8Admin.Admin.EntityFramework.SqlServer.csproj", "src/SkorubaIdentityServer8Admin.Admin.EntityFramework.SqlServer/"]
COPY ["src/SkorubaIdentityServer8Admin.Shared/SkorubaIdentityServer8Admin.Shared.csproj", "src/SkorubaIdentityServer8Admin.Shared/"]
COPY ["src/SkorubaIdentityServer8Admin.Admin.EntityFramework.PostgreSQL/SkorubaIdentityServer8Admin.Admin.EntityFramework.PostgreSQL.csproj", "src/SkorubaIdentityServer8Admin.Admin.EntityFramework.PostgreSQL/"]
COPY ["src/SkorubaIdentityServer8Admin.Admin.EntityFramework.MySql/SkorubaIdentityServer8Admin.Admin.EntityFramework.MySql.csproj", "src/SkorubaIdentityServer8Admin.Admin.EntityFramework.MySql/"]
RUN dotnet restore "src/SkorubaIdentityServer8Admin.Admin.Api/SkorubaIdentityServer8Admin.Admin.Api.csproj"
COPY . .
WORKDIR "/src/src/SkorubaIdentityServer8Admin.Admin.Api"
RUN dotnet build "SkorubaIdentityServer8Admin.Admin.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SkorubaIdentityServer8Admin.Admin.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_FORWARDEDHEADERS_ENABLED=true
ENTRYPOINT ["dotnet", "SkorubaIdentityServer8Admin.Admin.Api.dll"]