dotnet ef database update ^
    --project "PolestarTracker.EntityFramework" ^
    --startup-project "PolestarTracker.EntityFramework"

copy /Y PolestarTracker.EntityFramework/tracking.db PolestarTracker/bin/Release/netcoreapp3.1
copy /Y PolestarTracker.EntityFramework/tracking.db PolestarTracker.Tests/tracking.db
copy /Y PolestarTracker.EntityFramework/tracking.db PolestarTracker/bin/Debug/netcoreapp3.1