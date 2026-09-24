SET PATH=%PATH%;C:\Program Files (x86)\CrSSL\bin;%USERPROFILE%\AppData\Local\Microsoft\WindowsApps;C:\Program Files\Azure Data Studio\bin;%USERPROFILE%\.dotnet\tools;C:\Program Files (x86)\Microsoft Visual Studio\2017\Professional\MSBuild\15.0\Bin\amd64;
msbuild.exe "c:\gems source sql\bd source\bd001\bd001.sln" /property:configuration=release
msbuild.exe "c:\gems source sql\bd source\bd100\bd100.sln" /property:configuration=release
msbuild.exe "c:\gems source sql\bd source\bd101\bd101.sln" /property:configuration=release
msbuild.exe "c:\gems source sql\bd source\bd102\bd102.sln" /property:configuration=release
msbuild.exe "c:\gems source sql\bd source\bd103\bd103.sln" /property:configuration=release
msbuild.exe "c:\gems source sql\bd source\bd104\bd104.sln" /property:configuration=release
msbuild.exe "c:\gems source sql\bd source\bd200\bd200.sln" /property:configuration=release
msbuild.exe "c:\gems source sql\bd source\bd201\bd201.sln" /property:configuration=release
msbuild.exe "c:\gems source sql\bd source\bd202\bd202.sln" /property:configuration=release
pause