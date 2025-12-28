FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["src/Skoruba.IdentityServer8.STS.Identity/Skoruba.IdentityServer8.STS.Identity.csproj", "src/Skoruba.IdentityServer8.STS.Identity/"]
COPY ["src/Skoruba.IdentityServer8.Shared.Configuration/Skoruba.IdentityServer8.Shared.Configuration.csproj", "src/Skoruba.IdentityServer8.Shared.Configuration/"]
COPY ["src/Skoruba.IdentityServer8.Admin.EntityFramework.Shared/Skoruba.IdentityServer8.Admin.EntityFramework.Shared.csproj", "src/Skoruba.IdentityServer8.Admin.EntityFramework.Shared/"]
COPY ["src/Skoruba.IdentityServer8.Admin.EntityFramework.Identity/Skoruba.IdentityServer8.Admin.EntityFramework.Identity.csproj", "src/Skoruba.IdentityServer8.Admin.EntityFramework.Identity/"]
COPY ["src/Skoruba.IdentityServer8.Admin.EntityFramework/Skoruba.IdentityServer8.Admin.EntityFramework.csproj", "src/Skoruba.IdentityServer8.Admin.EntityFramework/"]
COPY ["src/Skoruba.IdentityServer8.Admin.EntityFramework.Extensions/Skoruba.IdentityServer8.Admin.EntityFramework.Extensions.csproj", "src/Skoruba.IdentityServer8.Admin.EntityFramework.Extensions/"]
COPY ["src/Skoruba.IdentityServer8.Admin.EntityFramework.Configuration/Skoruba.IdentityServer8.Admin.EntityFramework.Configuration.csproj", "src/Skoruba.IdentityServer8.Admin.EntityFramework.Configuration/"]
COPY ["src/Skoruba.IdentityServer8.Shared/Skoruba.IdentityServer8.Shared.csproj", "src/Skoruba.IdentityServer8.Shared/"]
COPY ["src/Skoruba.IdentityServer8.Admin.BusinessLogic.Identity/Skoruba.IdentityServer8.Admin.BusinessLogic.Identity.csproj", "src/Skoruba.IdentityServer8.Admin.BusinessLogic.Identity/"]
COPY ["src/Skoruba.IdentityServer8.Admin.BusinessLogic.Shared/Skoruba.IdentityServer8.Admin.BusinessLogic.Shared.csproj", "src/Skoruba.IdentityServer8.Admin.BusinessLogic.Shared/"]
RUN dotnet restore "src/Skoruba.IdentityServer8.STS.Identity/Skoruba.IdentityServer8.STS.Identity.csproj"
COPY . .
WORKDIR "/src/src/Skoruba.IdentityServer8.STS.Identity"
RUN dotnet build "Skoruba.IdentityServer8.STS.Identity.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Skoruba.IdentityServer8.STS.Identity.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_FORWARDEDHEADERS_ENABLED=true
ENTRYPOINT ["dotnet", "Skoruba.IdentityServer8.STS.Identity.dll"]