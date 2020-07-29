# PolestarTracker
A productivity tracking application written using C# and WPF .Net Core

This is a project for my Software Development Methodology - CPSC 4720 class

## Build Instructions
In order to build the application you will need a recent copy of Visual Studio. Make sure to have the .NET desktop development package installed with Visual Studio.

From Visual Studio you can build the project by first opening the PolestarTracker.sln file in the root directory of the repository. 
Once you have done this, make sure the Release configuration is checked (You can do this by going to Build > Configuration Manager  and making sure "Active solution configuration" is set to "Release").
Once the configuration is set, make sure that PolestarTracker.WPF is set as the startup project (You can set it as the startup project by right clicking the name in the Solution Explorer and selecting "Set as StartUp Project")
After PolestarTracker.WPF is set as the StartUp Project, you can build the project by doing Build > Build Solution. This will generate a .exe file in the Polestar/bin/Release folder named PolestarTracker.WPF.exe

## Running the program
After following the build instructions above, you can run the program by opening the PolestarTracker.WPF.exe in Polestar/bin/Release folder.
