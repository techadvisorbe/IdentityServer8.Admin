param([string] $version)

Set-Location "../"

# build docker images according to docker-compose
docker-compose -f docker-compose.yml build

# rename images with following tag
docker tag skoruba-identityserver8-admin skoruba/identityserver8-admin:$version
docker tag skoruba-identityserver8-sts-identity skoruba/identityserver8-sts-identity:$version
docker tag skoruba-identityserver8-admin-api skoruba/identityserver8-admin-api:$version

# push to docker hub
docker push skoruba/identityserver8-admin:$version
docker push skoruba/identityserver8-admin-api:$version
docker push skoruba/identityserver8-sts-identity:$version