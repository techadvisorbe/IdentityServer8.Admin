param([string] $version)

Set-Location "../"

# build docker images according to docker-compose
docker-compose -f docker-compose.yml build

# rename images with following tag
docker tag techadvisor-identityserver8-admin techadvisor/identityserver8-admin:$version
docker tag techadvisor-identityserver8-sts-identity techadvisor/identityserver8-sts-identity:$version
docker tag techadvisor-identityserver8-admin-api techadvisor/identityserver8-admin-api:$version

# push to docker hub
docker push techadvisor/identityserver8-admin:$version
docker push techadvisor/identityserver8-admin-api:$version
docker push techadvisor/identityserver8-sts-identity:$version