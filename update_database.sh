#!/bin/bash

# --project denotes the output directory
# --startupt-project denotes the source directory (This should be the Entity Framework related project)
dotnet ef database update \
    --project "PolestarTracker.EntityFramework" \
    --startup-project "PolestarTracker.EntityFramework"

cp PolestarTracker.EntityFramework/tracking.db PolestarTracker.Tests/tracking.db
