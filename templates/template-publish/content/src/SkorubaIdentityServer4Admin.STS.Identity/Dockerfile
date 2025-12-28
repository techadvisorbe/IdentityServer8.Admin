FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["src/SkorubaIdentityServer8Admin.STS.Identity/SkorubaIdentityServer8Admin.STS.Identity.csproj", "src/SkorubaIdentityServer8Admin.STS.Identity/"]
COPY ["src/SkorubaIdentityServer8Admin.Admin.EntityFramework.Shared/SkorubaIdentityServer8Admin.Admin.EntityFramework.Shared.csproj", "src/SkorubaIdentityServer8Admin.Admin.EntityFramework.Shared/"]
COPY ["src/SkorubaIdentityServer8Admin.Shared/SkorubaIdentityServer8Admin.Shared.csproj", "src/SkorubaIdentityServer8Admin.Shared/"]
RUN dotnet restore "src/SkorubaIdentityServer8Admin.STS.Identity/SkorubaIdentityServer8Admin.STS.Identity.csproj"
COPY . .
WORKDIR "/src/src/SkorubaIdentityServer8Admin.STS.Identity"
RUN dotnet build "SkorubaIdentityServer8Admin.STS.Identity.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SkorubaIdentityServer8Admin.STS.Identity.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_FORWARDEDHEADERS_ENABLED=true
ENTRYPOINT ["dotnet", "SkorubaIdentityServer8Admin.STS.Identity.dll"]