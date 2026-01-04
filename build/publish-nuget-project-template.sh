#!/bin/bash

version="${1:?Error: version argument is required}"
key="${2:?Error: nuget key argument is required}"

dotnet nuget push "../templates/TechAdvisor.IdentityServer8.Admin.Templates.$version.nupkg" -k "$key" -s https://api.nuget.org/v3/index.json
