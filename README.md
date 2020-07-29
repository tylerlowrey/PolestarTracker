# PolestarTracker
A productivity tracking application written using C# and WPF .Net Core. 

This is a project for my Software Development Methodology - CPSC 4720 class

## Build Instructions
In order to build the application you will need a recent copy of Visual Studio. Make sure to have the .NET desktop development package installed with Visual Studio.

This project only runs on Windows and has only been tested on Windows 10.

Instructions:
1) Open the PolestarTracker.sln file in the root directory of the repository. 
2) Make sure the Release configuration is checked (You can do this by going to Build > Configuration Manager  and making sure "Active solution configuration" is set to "Release").
3) Make sure that PolestarTracker.WPF is set as the startup project (You can set it as the startup project by right clicking the name in the Solution Explorer and selecting "Set as StartUp Project")
4) After PolestarTracker.WPF is set as the StartUp Project, you can build the project by doing Build > Build Solution. This will generate a .exe file in the Polestar/bin/Release folder named PolestarTracker.WPF.exe
5) Go into the root directory of the project and run the update_database.sh file. If you do not have a bash terminal, you can use the update_database.bat file instead

## Running the program
After following the build instructions above, you can run the program by opening the PolestarTracker.WPF.exe in Polestar/bin/Release folder.