![Logo](docs/Images/TechAdvisor.IdentityServer8.Admin-Logo-ReadMe.png)

# TechAdvisor.IdentityServer8.Admin

> Administration for IdentityServer8 and ASP.NET Core Identity

## 🎉 A .NET 8 Port of IdentityServer4.Admin

This project is a community-driven port of [Skoruba.IdentityServer4.Admin](https://github.com/skoruba/IdentityServer4.Admin) to **.NET 8**, leveraging [IdentityServer8](https://github.com/alexhiggins732/IdentityServer8) - an open-source fork of the original IdentityServer.

**Special thanks to:**
- **[Jan Skoruba](https://github.com/skoruba)** 🙏 - for creating the original IdentityServer4.Admin project and establishing this incredible foundation
- **[Alex Higgins](https://github.com/alexhiggins732)** 🙏 - for developing and maintaining IdentityServer8, enabling this modern .NET 8 version

## Requirements

- [Install](https://www.microsoft.com/net/download/windows#/current) the latest **.NET 8 SDK** (using older versions may lead to 502.5 errors when hosted on IIS or application exiting immediately after starting when self-hosted)

## Installation via dotnet new template

- Install the dotnet new template:

### Version 2.0.0 and higher works with **IdentityServer8 version 4** 🚀

- 🔒 **NOTE:** This version affects your database data if you use the default database migrations that are part of the project - double check the migrations according to your database provider and create a database backup

```sh
dotnet new -i TechAdvisor.IdentityServer8.Admin.Templates::2.1.0
```

### Create new project:

```sh
dotnet new techadvisor.is4admin --name MyProject --title MyProject --adminemail "admin@example.com" --adminpassword "Pa$$word123" --adminrole MyRole --adminclientid MyClientId --adminclientsecret MyClientSecret --dockersupport true
```

Project template options:

```
--name: [string value] for project name
--adminpassword: [string value] admin password
--adminemail: [string value] admin email
--title: [string value] for title and footer of the administration in UI
--adminrole: [string value] for name of admin role, that is used to authorize the administration
--adminclientid: [string value] for client name, that is used in the IdentityServer8 configuration for admin client
--adminclientsecret: [string value] for client secret, that is used in the IdentityServer8 configuration for admin client
--dockersupport: [boolean value] include docker support
```

## How to configure the Administration - IdentityServer8 and Asp.Net Core Identity

- [Follow these steps for setup project to use existing IdentityServer8 and Asp.Net Core Identity](docs/Configure-Administration.md)

### Template uses following list of nuget packages

- [Available nuget packages](https://www.nuget.org/profiles/techadvisor)

### Running in Visual Studio

- Set Startup projects:
  - TechAdvisor.IdentityServer8.Admin
  - TechAdvisor.IdentityServer8.Admin.Api
  - TechAdvisor.IdentityServer8.STS.Identity

## Configuration of Administration for Deployment

- [Configuration of Admin for deploy on Azure](docs/Configure-Azure-Deploy.md)
- [Configuration of Admin on Ubuntu with PostgreSQL database](docs/Configure-Ubuntu-PostgreSQL-Tutorial.md)

## Administration UI preview

- This administration uses bootstrap 4

### Admin UI - Light mode 🌞

![Admin-preview](docs/Images/App/1.PNG)

### Admin UI - Dark mode 🌙

![Admin-preview](docs/Images/App/2.PNG)

### Security token service (STS)

![Admin-preview](docs/Images/App/4.PNG)

### Forms

![Admin-preview-form](docs/Images/App/3.png)

## Cloning

```sh
git clone https://github.com/techadvisor/IdentityServer8.Admin
```

## Running via Docker

- It is possible to run Admin UI through the docker.

### Docker setup

### DNS

We need some resolving capabilities in order for the project to work. The domain `techadvisor.local` is used here to represent the domain this setup is hosted on. The domain-name needs to be FQDN (fully qualified domain name).

Thus first, we need the domain `techadvisor.local` to resolve to the docker-host machine. If you want this to work on your local machine only, use the first option.

#### DNS on docker-host machine only

Edit your hosts file:

- On Linux: `\etc\hosts`
- On Windows: `C:\Windows\system32\drivers\etc\hosts`

and add the following entries:

```custom
127.0.0.1 techadvisor.local sts.techadvisor.local admin.techadvisor.local admin-api.techadvisor.local
```

This way your host machine resolves `techadvisor.local` and its subdomains to itself.

### Certificates

We also need certificates in order to serve on HTTPS. We'll make our own self-signed certificates with [mkcert](https://github.com/FiloSottile/mkcert).

> If the domain is publicly available through DNS, you can use [Let's Encypt](https://letsencrypt.org/). Nginx-proxy has support for that, which is left out in this setup.

#### MkCert

##### Create the root certificate

Use [mkcert](https://github.com/FiloSottile/mkcert) to generate local self-signed certificates.

On windows `mkcert -install` must be executed under elevated Administrator privileges. Then copy over the CA Root certificate over to the project as we want to mount this in later into the containers without using an environment variable.

```bash
cd shared/nginx/certs
mkcert --install
copy $env:LOCALAPPDATA\mkcert\rootCA.pem ./cacerts.pem
copy $env:LOCALAPPDATA\mkcert\rootCA.pem ./cacerts.crt
```

##### Create the `techadvisor.local` certificates

Generate a certificate for `techadvisor.local` with wildcards for the subdomains. The name of the certificate files need to match with actual domain-names in order for the nginx-proxy to pick them up correctly. We want both the crt-key and the pfx version.

```bash
cd shared/nginx/certs
mkcert -cert-file techadvisor.local.crt -key-file techadvisor.local.key techadvisor.local *.techadvisor.local
mkcert -pkcs12 techadvisor.local.pfx techadvisor.local *.techadvisor.local
```

##### This docker setup is come from this [repository](https://github.com/bravecobra/identityserver-ui) - thanks to [bravecobra](https://github.com/bravecobra). 😊

### Run docker-compose

- Project contains the `docker-compose.vs.debug.yml` and `docker-compose.override.yml` to enable debugging with a seeded environment.
- The following possibility to get a running seeded and debug-able (in VS) environment:

```
docker-compose build
docker-compose up -d
```

> It is also possible to set as startup project the project called `docker-compose` in Visual Studio.

### Docker images

- Docker images will be available also in [docker hub](https://hub.docker.com/u/techadvisor)

### Publish Docker images to Docker hub

- Check the script in `build/publish-docker-images.ps1` - change the profile name according to your requirements.

## Installation of the Client Libraries

```sh
cd src/TechAdvisor.IdentityServer8.Admin
npm install

cd src/TechAdvisor.IdentityServer8.STS.Identity
npm install
```

## Bundling and Minification

The following Gulp commands are available:

- `gulp fonts` - copy fonts to the `dist` folder
- `gulp styles` - minify CSS, compile SASS to CSS
- `gulp scripts` - bundle and minify JS
- `gulp clean` - remove the `dist` folder
- `gulp build` - run the `styles` and `scripts` tasks
- `gulp watch` - watch all changes in all sass files

## EF Core & Data Access

- The solution uses these `DbContexts`:

  - `AdminIdentityDbContext`: for Asp.Net Core Identity
  - `AdminLogDbContext`: for logging
  - `IdentityServerConfigurationDbContext`: for IdentityServer configuration store
  - `IdentityServerPersistedGrantDbContext`: for IdentityServer operational store
  - `AdminAuditLogDbContext`: for Audit Logging
  - `IdentityServerDataProtectionDbContext`: for dataprotection

### Run entity framework migrations:

> NOTE: Initial migrations are a part of the repository.

- It is possible to use powershell script in folder `build/add-migrations.ps1`.
- This script take two arguments:

  - --migration (migration name)
  - --migrationProviderName (provider type - available choices: All, SqlServer, MySql, PostgreSQL)

- For example:
  `.\add-migrations.ps1 -migration DbInit -migrationProviderName SqlServer`

### Available database providers:

- SqlServer
- MySql
- PostgreSQL

> It is possible to switch the database provider via `appsettings.json`:

```
"DatabaseProviderConfiguration": {
        "ProviderType": "SqlServer"
    }
```

### Connection strings samples for available db providers:

**PostgreSQL**:

> Server=localhost;Port=5432;Database=IdentityServer8Admin;User Id=sa;Password=#;

**MySql:**

> server=localhost;database=IdentityServer8Admin;user=root;password=#

### We suggest to use seed data:

- In `Program.cs` -> `Main`, uncomment `DbMigrationHelpers.EnsureSeedData(host)` or use dotnet CLI `dotnet run /seed` or via `SeedConfiguration` in `appsettings.json`
- The `Clients` and `Resources` files in `identityserverdata.json` (section called: IdentityServerData) - are the initial data, based on a sample from IdentityServer8
- The `Users` file in `identitydata.json` (section called: IdentityData) contains the default admin username and password for the first login

## Authentication and Authorization

- Change the specific URLs and names for the IdentityServer and Authentication settings in `appsettings.json`
- In the controllers is used the policy which name is stored in - `AuthorizationConsts.AdministrationPolicy`. In the policy - `AuthorizationConsts.AdministrationPolicy` is defined required role stored in - `appsettings.json` - `AdministrationRole`.
- With the default configuration, it is necessary to configure and run instance of IdentityServer8. It is possible to use initial migration for creating the client as it mentioned above

## Azure Key Vault

- It is possible to use Azure Key Vault and configure it in the `appsettings.json` with following configuration:

```
"AzureKeyVaultConfiguration": {
    "AzureKeyVaultEndpoint": "",
    "ClientId": "",
    "ClientSecret": "",
    "UseClientCredentials": true
  }
```

If your application is running in `Azure App Service`, you can specify `AzureKeyVaultEndpoint`. For applications which are running outside of Azure environment it is possible to use the client credentials flow - so it is necesarry to go to Azure portal, register new application and connect this application to Azure Key Vault and setup the client secret.

- It is possible to use Azure Key Vault for following parts of application:

### Application Secrets and Database Connection Strings:

- It is necesarry to configure the connection to Azure Key Vault and allow following settings:

```
"AzureKeyVaultConfiguration": {
    "ReadConfigurationFromKeyVault": true
  }
```

### Dataprotection:

Enable Azure Key Vault for dataprotection with following configuration:

```
"DataProtectionConfiguration": {
    "ProtectKeysWithAzureKeyVault": false
  }
```

The you need specify the key identifier in configuration:

```
"AzureKeyVaultConfiguration": {
    "DataProtectionKeyIdentifier": ""
  }
```

### IdentityServer certificate for signing tokens:

- It is possible to go to Azure Key Vault - generate new certificate and use this certificate name below:

```
"AzureKeyVaultConfiguration": {
    "IdentityServerCertificateName": ""
  }
```

## Logging

- We are using `Serilog` with pre-definded following Sinks - white are available in `serilog.json`:

  - Console
  - File
  - MSSqlServer
  - Seq

```json
{
  "Serilog": {
    "MinimumLevel": {
      "Default": "Error",
      "Override": {
        "Skoruba": "Information"
      }
    },
    "WriteTo": [
      {
        "Name": "Console"
      },
      {
        "Name": "File",
        "Args": {
          "path": "log.txt",
          "rollingInterval": "Day"
        }
      },
      {
        "Name": "MSSqlServer",
        "Args": {
          "connectionString": "...",
          "tableName": "Log",
          "columnOptionsSection": {
            "addStandardColumns": ["LogEvent"],
            "removeStandardColumns": ["Properties"]
          }
        }
      }
    ]
  }
}
```

## Audit Logging

- This solution uses audit logging via - https://github.com/skoruba/AuditLogging (check this link for more detal about this implementation :blush:)
- In the Admin UI project is following setup:

```cs
services.AddAuditLogging(options => { options.Source = auditLoggingConfiguration.Source; })
                .AddDefaultHttpEventData(subjectOptions =>
                    {
                        subjectOptions.SubjectIdentifierClaim = auditLoggingConfiguration.SubjectIdentifierClaim;
                        subjectOptions.SubjectNameClaim = auditLoggingConfiguration.SubjectNameClaim;
                    },
                    actionOptions =>
                    {
                        actionOptions.IncludeFormVariables = auditLoggingConfiguration.IncludeFormVariables;
                    })
                .AddAuditSinks<DatabaseAuditEventLoggerSink<TAuditLog>>();

            // repository for library
            services.AddTransient<IAuditLoggingRepository<TAuditLog>, AuditLoggingRepository<TAuditLoggingDbContext, TAuditLog>>();

            // repository and service for admin
            services.AddTransient<IAuditLogRepository<TAuditLog>, AuditLogRepository<TAuditLoggingDbContext, TAuditLog>>();
            services.AddTransient<IAuditLogService, AuditLogService<TAuditLog>>();
```

### Admin Configuration

Admin and STS can be customized without editing code in `appsettings.json` under AdminConfiguration section

#### Themes

Ui can be customized using themes integrated from [bootswatch](https://bootswatch.com).

From version 2.0.0 is possible to change theme from UI. 🎈

By default, configuration value is null to use default theme. if you want to use a theme, just fill the lowercase theme name as configuration value of `Theme` key.

You can also use your custom theme by integrating it in your project or hosting css on your place to pass the url in `CustomThemeCss` key. (Note that custom theme override standard theme)

- Important Note: Theme can use external resources which caused errors due to CSP. If you get errors, please make sure that you configured correctly CSP section in your `appsettings.json` with thrusted domains for resources.

```json
  "AdminConfiguration": {
    "PageTitle": "TechAdvisor IdentityServer8",
    "HomePageLogoUri": "~/images/techadvisor-icon.png",
    "FaviconUri": "~/favicon.ico",
    "Theme": "united",
    "CustomThemeCss": null,
    ...
  },
```

### Audit Logging Configuration

In `appsettings.json` is following configuration:

```json
"AuditLoggingConfiguration": {
    "Source": "IdentityServer.Admin.Web",
    "SubjectIdentifierClaim": "sub",
    "SubjectNameClaim": "name",
    "IncludeFormVariables": false
  }
```

The `TechAdvisor.IdentityServer8.Admin.BusinessLogic` layer contains folder called `Events` for audit logging. In each method in Services is called function `LogEventAsync` like this:

```
await AuditEventLogger.LogEventAsync(new ClientDeletedEvent(client));
```

Final audit log is available in the table `dbo.AuditLog`.

### Login Configuration

- In `TechAdvisor.IdentityServer8.STS.Identity` - in `appsettings.json` is possible to specify which column will be used for login (`Username` or `Email`):

```
  "LoginConfiguration": {
    "ResolutionPolicy": "Username"
  }
```

or using `Email`:

```
  "LoginConfiguration": {
    "ResolutionPolicy": "Email"
  }
```

### Register Configuration

- In `TechAdvisor.IdentityServer8.STS.Identity` - in `appsettings.json` is possible to disable user registration (`default: true`):

```
 "RegisterConfiguration": {
    "Enabled": false
  }
```

## How to configure API & Swagger

- For development is running on url - `https://localhost:44302` and swagger UI is available on url - `https://localhost:44302/swagger`
- For swagger UI is configured a client and an API in STS:

```
"AdminApiConfiguration": {
  "IdentityServerBaseUrl": "https://localhost:44310",
  "OidcSwaggerUIClientId": "techadvisor_identity_admin_api_swaggerui",
  "OidcApiName": "techadvisor_identity_admin_api"
}
```

- Swagger UI contains following endpoints:

![SwaggerUI-preview](docs/Images/Admin-Swagger-UI.PNG)

## How to configure an external provider in STS

- In `TechAdvisor.IdentityServer8.STS.Identity/Helpers/StartupHelpers.cs` - is method called `AddExternalProviders` which contains the example with `GitHub`, `AzureAD` configured in `appsettings.json`:

```
"ExternalProvidersConfiguration": {
        "UseGitHubProvider": false,
        "GitHubClientId": "",
        "GitHubClientSecret": "",
        "UseAzureAdProvider": false,
        "AzureAdClientId": "",
        "AzureAdTenantId": "",
        "AzureInstance": "",
        "AzureAdSecret": "",
        "AzureAdCallbackPath": "",
        "AzureDomain": ""
}
```

- It is possible to extend `ExternalProvidersConfiguration` with another configuration properties.
- If you use DockerHub built image, you can use appsettings to configure these providers without changing the code
  - GitHub
  - AzureAD

### List of external providers for ASP.NET Core:

- https://github.com/aspnet-contrib/AspNet.Security.OAuth.Providers
- https://docs.microsoft.com/en-us/aspnet/core/security/authentication/social/

### Azure AD

- Great article how to set up Azure AD:
  - https://docs.microsoft.com/en-us/azure/active-directory/develop/quickstart-v2-aspnet-core-webapp

## Email service

- It is possible to set up emails via:

### SendGrid

In STS project - in `appsettings.json`:

```
"SendgridConfiguration": {
        "ApiKey": "",
        "SourceEmail": "",
        "SourceName": ""
    }
```

### SMTP

```
"SmtpConfiguration": {
        "From": "",
        "Host": "",
        "Login": "",
        "Password": ""
    }
```

## CSP - Content Security Policy

- If you want to use favicon or logo not included/hosted on the same place, you need to declare trusted domain where resources are hosted in appsettings.json.

```
  "CspTrustedDomains": [
    "google.com",
    "mydomain.com"
  ],
```

## Health checks

- AdminUI, AdminUI Api and STS contain endpoint `health`, which check databases and IdentityServer.

## Localizations - labels, messages

- The project has following translations:
  - English
  - Chinese
  - Russian
  - Persian
  - Swedish
  - Danish
  - Spanish
  - French
  - Finish
  - German
  - Portuguese

#### Feel free to send a PR with your translation. :blush:

- All labels and messages are stored in the resources `.resx` - locatated in `/Resources`

  - Client label descriptions from - http://docs.identityserver.io/en/latest/reference/client.html
  - Api Resource label descriptions from - http://docs.identityserver.io/en/latest/reference/api_resource.html
  - Identity Resource label descriptions from - http://docs.identityserver.io/en/latest/reference/identity_resource.html

## Tests

- The solution contains unit and integration tests.

Integration tests use StartupTest class which is pre-configured with:

- `DbContext` contains setup for InMemory database
- `Authentication` is setup for `CookieAuthentication` - with fake login url for testing purpose only
- `AuthenticatedTestRequestMiddleware` - middleware for testing of authentication.

## Overview

### Solution structure:

- STS:

  - `TechAdvisor.IdentityServer8.STS.Identity` - project that contains the instance of IdentityServer8 and combine these samples - [Quickstart UI for the IdentityServer8 with Asp.Net Core Identity and EF Core storage](https://github.com/IdentityServer/IdentityServer8/tree/master/samples/Quickstarts/9_Combined_AspId_and_EFStorage) and [damienbod - IdentityServer8 and Identity template](https://github.com/damienbod/IdentityServer8AspNetCoreIdentityTemplate)

- Admin UI Api:

  - `TechAdvisor.IdentityServer8.Admin.Api` - project with Api for managing data of IdentityServer8 and Asp.Net Core Identity, with swagger support as well

- Admin UI:

  - `TechAdvisor.IdentityServer8.Admin.UI` - ASP.NET Core MVC application that contains Admin UI

  - `TechAdvisor.IdentityServer8.Admin` - ASP.NET Core MVC application that uses Admin UI package and it's only for application bootstrap

  - `TechAdvisor.IdentityServer8.Admin.BusinessLogic` - project that contains Dtos, Repositories, Services and Mappers for the IdentityServer8

  - `TechAdvisor.IdentityServer8.Admin.BusinessLogic.Identity` - project that contains Dtos, Repositories, Services and Mappers for the Asp.Net Core Identity

  - `TechAdvisor.IdentityServer8.Admin.BusinessLogic.Shared` - project that contains shared Dtos and ExceptionHandling for the Business Logic layer of the IdentityServer8 and Asp.Net Core Identity

  - `TechAdvisor.IdentityServer8.Shared` - Shared common Identity DTOS for Admin UI, Admin UI Api and STS

  - `TechAdvisor.IdentityServer8.Shared.Configuration` - Shared common layer for Admin UI, Admin UI Api and STS

  - `TechAdvisor.IdentityServer8.Admin.EntityFramework` - EF Core data layer that contains Entities for the IdentityServer8

  - `TechAdvisor.IdentityServer8.Admin.EntityFramework.Configuration` - EF Core data layer that contains configurations

  - `TechAdvisor.IdentityServer8.Admin.EntityFramework.Identity` - EF Core data layer that contains Repositories for the Asp.Net Core Identity

  - `TechAdvisor.IdentityServer8.Admin.EntityFramework.Extensions` - project that contains extensions related to EntityFramework

  - `TechAdvisor.IdentityServer8.Admin.EntityFramework.Shared` - project that contains DbContexts for the IdentityServer8, Logging and Asp.Net Core Identity, inluding shared Identity entities

  - `TechAdvisor.IdentityServer8.Admin.EntityFramework.SqlServer` - project that contains migrations for SqlServer

  - `TechAdvisor.IdentityServer8.Admin.EntityFramework.MySql` - project that contains migrations for MySql

  - `TechAdvisor.IdentityServer8.Admin.EntityFramework.PostgreSQL` - project that contains migrations for PostgreSQL

- Tests:

  - `TechAdvisor.IdentityServer8.Admin.IntegrationTests` - xUnit project that contains the integration tests for AdminUI

  - `TechAdvisor.IdentityServer8.Admin.Api.IntegrationTests` - xUnit project that contains the integration tests for AdminUI Api

  - `TechAdvisor.IdentityServer8.Admin.UnitTests` - xUnit project that contains the unit tests for AdminUI

  - `TechAdvisor.IdentityServer8.STS.IntegrationTests` - xUnit project that contains the integration tests for STS

### The admininistration contains the following sections:

![TechAdvisor.IdentityServer8.Admin App](docs/Images/TechAdvisor.IdentityServer8.Admin-Solution.png)

## IdentityServer8

**Clients**

It is possible to define the configuration according the client type - by default the client types are used:

- Empty
- Web Application - Server side - Authorization Code Flow with PKCE
- Single Page Application - Javascript - Authorization Code Flow with PKCE
- Native Application - Mobile/Desktop - Authorization Code Flow with PKCE
- Machine/Robot - Client Credentials flow
- TV and Limited-Input Device Application - Device flow

- Actions: Add, Update, Clone, Remove
- Entities:
  - Client Cors Origins
  - Client Grant Types
  - Client IdP Restrictions
  - Client Post Logout Redirect Uris
  - Client Properties
  - Client Redirect Uris
  - Client Scopes
  - Client Secrets

**API Resources**

- Actions: Add, Update, Remove
- Entities:
  - Api Claims
  - Api Scopes
  - Api Scope Claims
  - Api Secrets
  - Api Properties

**Identity Resources**

- Actions: Add, Update, Remove
- Entities:
  - Identity Claims
  - Identity Properties

## Asp.Net Core Identity

**Users**

- Actions: Add, Update, Delete
- Entities:
  - User Roles
  - User Logins
  - User Claims

**Roles**

- Actions: Add, Update, Delete
- Entities:
  - Role Claims

## Application Diagram

![TechAdvisor.IdentityServer8.Admin Diagram](docs/Images/TechAdvisor.IdentityServer8.Admin-App-Diagram.png)

## Roadmap & Vision

### 3.0.0

- [ ] Connect Admin Api to the Admin UI
- [ ] Improve Admin UI responsiveness and accessibility

### 8.0.0: .NET 8 & IdentityServer8 Support

**Current Release** - Fully compatible with .NET 8 and IdentityServer8

- [x] Port to .NET 8
- [x] Update to IdentityServer8

### 10.0.0: .NET 10 & Future Enhancements

**Upcoming** - Target support for .NET 10

- [ ] Update to .NET 10
- [ ] Bootstrap 5 upgrade
- [ ] Enhanced Admin UI with modern JavaScript frameworks
- [ ] Performance optimizations

### Future Considerations:

- Add comprehensive UI tests
- Add more unit and integration tests
- Extend administration for additional protocols
- Support for additional external authentication providers
- Enhanced security features and compliance options

## Licence

This repository is licensed under the terms of the [**MIT license**](LICENSE.md).

**NOTE**: This repository uses the source code from https://github.com/IdentityServer/IdentityServer8.Quickstart.UI which is under the terms of the
[**Apache License 2.0**](https://github.com/IdentityServer/IdentityServer8.Quickstart.UI/blob/master/LICENSE).

## Acknowledgements

This project builds upon the excellent work of the original IdentityServer4.Admin project and is based on these key technologies:

**Original Project & Foundations:**
- [Skoruba.IdentityServer4.Admin](https://github.com/skoruba/IdentityServer4.Admin) - Original administration UI
- [IdentityServer4](https://github.com/IdentityServer/IdentityServer4) - Original IdentityServer framework
- [IdentityServer8](https://github.com/alexhiggins732/IdentityServer8) - Modern open-source continuation

**Core Technologies:**
- ASP.NET Core 8
- IdentityServer8 and EntityFramework
- ASP.NET Core Identity
- Entity Framework Core
- XUnit
- Fluent Assertions
- Bogus
- AutoMapper
- Serilog


## Contributing

Contributions of any kind are welcome! 

This is a community-maintained project. If you find bugs, have feature requests, or would like to contribute improvements, please feel free to open an issue or submit a pull request.

## Contact and Suggestion

This is a community-maintained .NET 8 port of the original IdentityServer4.Admin project.

For issues, feedback, or contributions related to this .NET 8 version, please create an issue on this repository.

For the original project and its history, visit [Skoruba.IdentityServer4.Admin](https://github.com/skoruba/IdentityServer4.Admin).

For IdentityServer8 specific questions, check [IdentityServer8](https://github.com/alexhiggins732/IdentityServer8).

## Support and Donation 🕊️

**If you appreciate this project and want to support the original author:**

The original IdentityServer4.Admin project was created by Jan Skoruba. If you found value in that work, please consider supporting Jan:

### Paypal

https://www.paypal.me/techadvisorbe

### Patreon

https://www.patreon.com/techadvisor

---

**Supporting IdentityServer8:**

For IdentityServer8, check out [Alex Higgins' sponsorship options](https://github.com/alexhiggins732/IdentityServer8) to support the continued development of IdentityServer8.
