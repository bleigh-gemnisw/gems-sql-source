SET PATH=%PATH%;C:\Program Files (x86)\CrSSL\bin;%USERPROFILE%\AppData\Local\Microsoft\WindowsApps;C:\Program Files\Azure Data Studio\bin;%USERPROFILE%\.dotnet\tools;C:\Program Files (x86)\Microsoft Visual Studio\2017\Professional\MSBuild\15.0\Bin\amd64;
msbuild.exe "c:\gems source sql\ia source\gems menus\gems menus.sln" /property:configuration=release
msbuild.exe "c:\gems source sql\ia source\gems sign on\gems sign on.sln" /property:configuration=release
msbuild.exe "c:\gems source sql\ia source\gemsnet_copyvb\gemsnet_copyvb.sln" /property:configuration=release
msbuild.exe "c:\gems source sql\ia source\ia001\ia001.sln" /property:configuration=release
msbuild.exe "c:\gems source sql\ia source\ia002\ia002.sln" /property:configuration=release
msbuild.exe "c:\gems source sql\ia source\ia003\ia003.sln" /property:configuration=release
msbuild.exe "c:\gems source sql\ia source\ia100\ia100.sln" /property:configuration=release
msbuild.exe "c:\gems source sql\ia source\ia101\ia101.sln" /property:configuration=release
msbuild.exe "c:\gems source sql\ia source\splash\splash.sln" /property:configuration=release
msbuild.exe "c:\gems source sql\ia source\sqlpass\sqlpass.sln" /property:configuration=release
msbuild.exe "c:\gems source sql\ia source\utils\utils.sln" /property:configuration=release
pause