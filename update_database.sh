#!/bin/bash

if [ ! -z "$1" ]; then
    dotnet ef migrations add $1 \
    --project "PolestarTracker.EntityFramework" \
    --startup-project "PolestarTracker.EntityFramework"
else 
    echo "No new migration was added"
fi

# --project denotes the output directory
# --startupt-project denotes the source directory (This should be the Entity Framework related project)
dotnet ef database update \
    --project "PolestarTracker.EntityFramework" \
    --startup-project "PolestarTracker.EntityFramework"

cp PolestarTracker.EntityFramework/tracking.db PolestarTracker.Tests/tracking.db
