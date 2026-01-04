#!/bin/bash

version="${1:?Error: version argument is required}"

cd "../" || exit 1

# Build docker images according to docker-compose
docker-compose -f docker-compose.yml build

# Rename images with following tag
docker tag techadvisor-identityserver8-admin "techadvisor/identityserver8-admin:$version"
docker tag techadvisor-identityserver8-sts-identity "techadvisor/identityserver8-sts-identity:$version"
docker tag techadvisor-identityserver8-admin-api "techadvisor/identityserver8-admin-api:$version"

# Push to docker hub
docker push "techadvisor/identityserver8-admin:$version"
docker push "techadvisor/identityserver8-admin-api:$version"
docker push "techadvisor/identityserver8-sts-identity:$version"
