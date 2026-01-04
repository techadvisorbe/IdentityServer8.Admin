#!/bin/bash

old="${1:?Error: old version argument is required}"
new="${2:?Error: new version argument is required}"

oldVersion="<Version>$old</Version>"
newVersion="<Version>$new</Version>"

oldVersionNuspec="<version>$old</version>"
newVersionNuspec="<version>$new</version>"

# Update project files
while IFS= read -r file; do
    echo "$file"
    sed -i.bak "s|$oldVersion|$newVersion|g" "$file"
    rm -f "$file.bak"
done < <(find ../src -name "*.csproj" -type f)

# Update nuspec files
while IFS= read -r file; do
    echo "$file"
    sed -i.bak "s|$oldVersionNuspec|$newVersionNuspec|g" "$file"
    rm -f "$file.bak"
done < <(find ../templates -name "*.nuspec" -type f)
