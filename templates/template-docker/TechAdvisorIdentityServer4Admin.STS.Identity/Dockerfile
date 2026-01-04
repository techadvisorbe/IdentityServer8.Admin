FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["src/TechAdvisorIdentityServer8Admin.STS.Identity/TechAdvisorIdentityServer8Admin.STS.Identity.csproj", "src/TechAdvisorIdentityServer8Admin.STS.Identity/"]
COPY ["src/TechAdvisorIdentityServer8Admin.Admin.EntityFramework.Shared/TechAdvisorIdentityServer8Admin.Admin.EntityFramework.Shared.csproj", "src/TechAdvisorIdentityServer8Admin.Admin.EntityFramework.Shared/"]
COPY ["src/TechAdvisorIdentityServer8Admin.Shared/TechAdvisorIdentityServer8Admin.Shared.csproj", "src/TechAdvisorIdentityServer8Admin.Shared/"]
RUN dotnet restore "src/TechAdvisorIdentityServer8Admin.STS.Identity/TechAdvisorIdentityServer8Admin.STS.Identity.csproj"
COPY . .
WORKDIR "/src/src/TechAdvisorIdentityServer8Admin.STS.Identity"
RUN dotnet build "TechAdvisorIdentityServer8Admin.STS.Identity.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TechAdvisorIdentityServer8Admin.STS.Identity.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_FORWARDEDHEADERS_ENABLED=true
ENTRYPOINT ["dotnet", "TechAdvisorIdentityServer8Admin.STS.Identity.dll"]